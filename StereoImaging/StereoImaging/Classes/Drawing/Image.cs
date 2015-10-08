using System;
using System.Runtime.InteropServices;

namespace DevilVision.Drawing
{
	using Colors;

	/// <summary>
	/// Изображение
	/// </summary>
	public class Image<T> : IImage where T : struct, IColor
	{

		#region Properties

		/// <summary>
		/// Байтове на изображението
		/// </summary>
		public byte[] Bytes
		{
			get;
			protected set;
		}

		/// <summary>
		/// Широчина на изображението
		/// </summary>
		public int Width
		{
			get;
			protected set;
		}

		/// <summary>
		/// Височина на изображението
		/// </summary>
		public int Height
		{
			get;
			protected set;
		}

		/// <summary>
		/// Дължина на хоризонталната линия
		/// </summary>
		public int Stride
		{
			get;
			protected set;
		}

		/// <summary>
		/// Дължина на изображението
		/// </summary>
		public int Length
		{
			get;
			protected set;
		}

		/// <summary>
		/// Дълбочина на изображението
		/// </summary>
		public int Depth
		{
			get;
			protected set;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Създаване на изображение
		/// </summary>
		/// <param name="size">Размер</param>
		public Image(System.Drawing.Size size) : this(size.Width, size.Height)
		{
			//Отгоре е всичко нужно
		}

		/// <summary>
		/// Създаване на изображение
		/// </summary>
		/// <param name="width">Широчина</param>
		/// <param name="height">Височина</param>
		public Image(int width, int height)
		{
			//Намиране и задаване на дълбочината
			this.Depth = default(T).Size;
			//Пресмятане на линията
			this.Stride = width * this.Depth;
			//Пресмятане на размера
			this.Length = this.Stride * height;
			//Задаване на размерите
			this.Width = width;
			this.Height = height;
			//Създаване на буфера
			this.Bytes = new byte[this.Length];
		}

		/// <summary>
		/// Създаване на изображение
		/// </summary>
		/// <param name="width">Широчина</param>
		/// <param name="height">Височина</param>
		/// <param name="bytes">Данни</param>
		public Image(int width, int height, Array bytes)
		{
			//Намиране и задаване на дълбочината
			this.Depth = default(T).Size;
			//Пресмятане на линията
			this.Stride = width * this.Depth;
			//Пресмятане на размера
			this.Length = this.Stride * height;
			//Задаване на размерите
			this.Width = width;
			this.Height = height;
			//Проверка дали буфера е с валиден размер
			if (bytes.Length != this.Length)
			{
				//Може грешката да се смени
				//Не е точно за тази цел
				throw new BadImageFormatException();
			}
			//Създаване на буфера
			this.Bytes = new byte[this.Length];
			//Задаване на буфера
			Buffer.BlockCopy(bytes, 0, this.Bytes, 0, this.Length);
		}

		/// <summary>
		/// Създаване на изображение от системно изображение
		/// </summary>
		/// <param name="image">Системно изображение</param>
		public Image(System.Drawing.Image image) : this(new System.Drawing.Bitmap(image))
		{
			//Отгоре е всичко нужно
		}

		/// <summary>
		/// Създаване на изображение от подаден път на такова
		/// </summary>
		/// <param name="filename">Път до изображението</param>
		public Image(string filename) : this(new System.Drawing.Bitmap(filename))
		{
			//Отгоре е всичко нужно
		}

		/// <summary>
		/// Създаване на изображение от друго изображение
		/// </summary>
		/// <param name="image"></param>
		public Image(IImage image)
		{
			//Създаване на семпъл за сорса
			IColor source_sample = (IColor)Activator.CreateInstance(image.GetType().GetGenericArguments()[0]);
			//Създаване на семпъл за дестинацията
			T destination_sample = default(T);
			//Намиране и задаване на дълбочината
			this.Depth = destination_sample.Size;
			//Задаване на размерите
			this.Width  = image.Width;
			this.Height = image.Height;
			//Пресмятане на линията
			this.Stride = this.Width * this.Depth;
			//Пресмятане на размера
			this.Length = this.Stride * this.Height;
			//Създаване на буфера
			this.Bytes = new byte[this.Length];
			//Проверка нужно ли е конвертиране
			if (source_sample.GetType() == destination_sample.GetType())
			{
				//Изкопиране на буфера
				Runtime.Memory.Copy(image.Bytes, this.Bytes, this.Length);
			}
			else
			{
				//Конвертиране
				unsafe
				{
					fixed (byte* _source = image.Bytes, _destination = this.Bytes)
					{
						this.Convert(_source, _destination, this.Width, this.Height, 0, 0, source_sample, destination_sample);
					}
				}
			}
		}

		/// <summary>
		/// Създаване на изображение от Bitmap
		/// </summary>
		/// <param name="bitmap">Bitmap</param>
		public Image(System.Drawing.Bitmap bitmap)
		{
			//Декларация на семпъл за сорса
			IColor source_sample;
			//Създаване на семпъл за дестинацията
			T destination_sample = default(T);
			//Намиране и задаване на дълбочината
			this.Depth  = destination_sample.Size;
			//Задаване на размерите
			this.Width  = bitmap.Width;
			this.Height = bitmap.Height;
			//Проверка на формата на пиксела
			switch(bitmap.PixelFormat)
			{
				case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
					//Задаване на 24 битов цвят
					source_sample = new Bgr();
					//Излизане от проверката
					break;
				case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
					//Задаване на 32 битов цвят
					source_sample = new Bgra();
					//Излизане от проверката
					break;
				case System.Drawing.Imaging.PixelFormat.Format8bppIndexed:
					//Валута показваща дали палитрата е черно-бяла
					bool grayscale_pallete = true;
					//Проверка дали индекса е за черно-бяло изображение
					foreach (System.Drawing.Color color in bitmap.Palette.Entries)
					{
						if (color.R != color.B || color.R != color.G)
						{
							grayscale_pallete = false;
							//
							break;
						}
					}
					//Проверка дали палетата е черно бяла
					if (grayscale_pallete)
					{
						//Задаване на 8 битов цвят
						source_sample = new Gray();
						//TODO: Допълнителни обработки за фиксиране на палитрата
					}
					else
					{
						//Задаване на 32 битов цвят
						source_sample = new Bgra();
						//Създаване на ново 32 битово изображение
						System.Drawing.Bitmap i32bit = new System.Drawing.Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
						//Изрусуване на старото изображение върху новото
						using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(i32bit))
						{
							gr.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, i32bit.Width, i32bit.Height));
						}
						//Замяна на инстанцията на старото с клонинга
						bitmap = i32bit;
					}
					//Излизане от проверката
					break;
				default:
					//Задаване на 32 битов цвят
					source_sample = new Bgra();
					//Създаване на ново 32 битово изображение
					System.Drawing.Bitmap clone = new System.Drawing.Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					//Изрусуване на старото изображение върху новото
					using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(clone))
					{
						gr.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, clone.Width, clone.Height));
					}
					//Замяна на инстанцията на старото с клонинга
					bitmap = clone;
					//Излизане от проверката
					break;
			}

			//Пресмятане на линията
			this.Stride = this.Width * this.Depth;
			//Пресмятане на размера
			this.Length = this.Stride * this.Height;
			//Създаване на буфера
			this.Bytes = new byte[this.Length];

			//Заключване на изображението
			System.Drawing.Imaging.BitmapData bitData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
			//Вземане на адреса на първата линия от изображението
			IntPtr ptr = bitData.Scan0;
			//Намиране на паддинга
			int padding = bitData.Stride - bitData.Width * source_sample.Size;

			//Проверка дали типа съвпада
			if (source_sample.GetType() == destination_sample.GetType())
			{
				//Проверка имаме ли отместване
				if (padding == 0)
				{
					//Копиране на данните от изображението в масива
					Runtime.Memory.Copy(ptr, this.Bytes, this.Length);
				}
				else
				{
					//Индекс в сорса
					int src_index = 0;
					//Индекс в дестинацията
					int dst_index = 0;
					//Копиране на байтовете в масива
					for (int y = 0; y < this.Height; y++)
					{
						//Копиране на линията
						Runtime.Memory.Copy(ptr, src_index, this.Bytes, dst_index, this.Stride);
						//Задаване на индексите
						src_index += bitData.Stride;
						dst_index += this.Stride;
					}
				}
			}
			else
			{
				unsafe
				{
					fixed (byte* _bytes = this.Bytes)
					{
						this.Convert((byte*)ptr, _bytes, this.Width, this.Height, padding, 0, source_sample, destination_sample);
					}
				}
			}

			//Отключване на изображението
			bitmap.UnlockBits(bitData);
		}

		#endregion

		#region Convert

		/// <summary>
		/// Конвертиране на изображението в друг тип
		/// </summary>
		/// <typeparam name="T2">Тип на изображението</typeparam>
		public Image<T2> Convert<T2>() where T2 : struct, IColor
		{
			return new Image<T2>((IImage)this);
		}

		/// <summary>
		/// Конвертиране на подадените байтове
		/// </summary>
		/// <typeparam name="S">Тип на данните</typeparam>
		/// <param name="bytes">Байтове за конвертиране</param>
		/// <returns>Конвертирани байтове</returns>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, IColor source_sample, IColor destination_sample)
		{
			//Вземане на двата дипа
			Type source_type      = source_sample.GetType();
			Type destination_type = destination_sample.GetType();

			//Намиране на най-подходящия кандидат за конверсия
			if (source_type == typeof(Rgb))
			{
				if (destination_type == typeof(Gray))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Rgb)source_sample, (Gray)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Bgr))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Rgb)source_sample, (Bgr)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Rgba))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Rgb)source_sample, (Rgba)destination_sample);
					//
					return;
				}
			}

			if (source_type == typeof(Rgba))
			{
				if (destination_type == typeof(Gray))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Rgba)source_sample, (Gray)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Rgb))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Rgba)source_sample, (Rgb)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Bgr))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Rgba)source_sample, (Bgr)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Bgra))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Rgba)source_sample, (Bgra)destination_sample);
					//
					return;
				}
			}

			if (source_type == typeof(Gray))
			{
				if (destination_type == typeof(Rgb))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Gray)source_sample, (Rgb)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Rgba))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Gray)source_sample, (Rgba)destination_sample);
					//
					return;
				}
			}

			if (source_type == typeof(Bgr))
			{
				if (destination_type == typeof(Rgb))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Bgr)source_sample, (Rgb)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Rgba))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Bgr)source_sample, (Rgba)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Gray))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Bgr)source_sample, (Gray)destination_sample);
					//
					return;
				}
			}

			if (source_type == typeof(Bgra))
			{
				if (destination_type == typeof(Rgb))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Bgra)source_sample, (Rgb)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Rgba))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Bgra)source_sample, (Rgba)destination_sample);
					//
					return;
				}

				if (destination_type == typeof(Gray))
				{
					this.Convert(source, destination, width, height, source_padding, destination_padding, (Bgra)source_sample, (Gray)destination_sample);
					//
					return;
				}
			}
		}

		/// <summary>
		/// Конвертиране от RGB към RGBA
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Rgb source_sample, Rgba destination_sample)
		{
			Rgb*  source_ptr      = (Rgb*)source;
			Rgba* destination_ptr = (Rgba*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue = source_ptr->Blue;
					destination_ptr->Alpha = 255;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Rgb*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgba*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от Gray към RGBA
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Gray source_sample, Rgba destination_sample)
		{
			Gray* source_ptr = (Gray*)source;
			Rgba* destination_ptr = (Rgba*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red = source_ptr->Intensity;
					destination_ptr->Green = source_ptr->Intensity;
					destination_ptr->Blue = source_ptr->Intensity;
					destination_ptr->Alpha = 255;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Gray*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgba*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от Gray към RGB
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Gray source_sample, Rgb destination_sample)
		{
			Gray* source_ptr = (Gray*)source;
			Rgb* destination_ptr = (Rgb*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red = source_ptr->Intensity;
					destination_ptr->Green = source_ptr->Intensity;
					destination_ptr->Blue = source_ptr->Intensity;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Gray*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgb*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от RGBA към RGB
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Rgba source_sample, Rgb destination_sample)
		{
			Rgba* source_ptr = (Rgba*)source;
			Rgb* destination_ptr = (Rgb*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue = source_ptr->Blue;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Rgba*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgb*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от BGR към RGB
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Bgr source_sample, Rgb destination_sample)
		{
			Bgr* source_ptr      = (Bgr*)source;
			Rgb* destination_ptr = (Rgb*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red   = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue  = source_ptr->Blue;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Bgr*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgb*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от BGRA към RGB
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Bgra source_sample, Rgb destination_sample)
		{
			Bgra* source_ptr      = (Bgra*)source;
			Rgb*  destination_ptr = (Rgb*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue = source_ptr->Blue;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Bgra*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgb*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от BGR към RGBA
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Bgr source_sample, Rgba destination_sample)
		{
			Bgr* source_ptr = (Bgr*)source;
			Rgba* destination_ptr = (Rgba*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red   = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue  = source_ptr->Blue;
					destination_ptr->Alpha = 255;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Bgr*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgba*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от BGRA към RGBA
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Bgra source_sample, Rgba destination_sample)
		{
			Bgra* source_ptr = (Bgra*)source;
			Rgba* destination_ptr = (Rgba*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red   = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue  = source_ptr->Blue;
					destination_ptr->Alpha = source_ptr->Alpha;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Bgra*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Rgba*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от RGB към BGR
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Rgb source_sample, Bgr destination_sample)
		{
			Rgb* source_ptr      = (Rgb*)source;
			Bgr* destination_ptr = (Bgr*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red   = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue  = source_ptr->Blue;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Rgb*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Bgr*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от RGBA към BGR
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Rgba source_sample, Bgr destination_sample)
		{
			Rgba* source_ptr      = (Rgba*)source;
			Bgr*  destination_ptr = (Bgr*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue = source_ptr->Blue;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Rgba*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Bgr*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от RGBA към BGRA
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Rgba source_sample, Bgra destination_sample)
		{
			Rgba* source_ptr      = (Rgba*)source;
			Bgra* destination_ptr = (Bgra*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Red   = source_ptr->Red;
					destination_ptr->Green = source_ptr->Green;
					destination_ptr->Blue  = source_ptr->Blue;
					destination_ptr->Alpha = source_ptr->Alpha;
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Rgba*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Bgra*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от RGB към Gray
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Rgb source_sample, Gray destination_sample)
		{
			Rgb*  source_ptr      = (Rgb*)source;
			Gray* destination_ptr = (Gray*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{
				
					//Конвертиране на данните
					destination_ptr->Intensity = (byte)((source_ptr->Red + source_ptr->Green + source_ptr->Blue) / 3);
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Rgb*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Gray*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от BGR към Gray
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Bgr source_sample, Gray destination_sample)
		{
			Bgr* source_ptr       = (Bgr*)source;
			Gray* destination_ptr = (Gray*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Intensity = (byte)((source_ptr->Blue + source_ptr->Green + source_ptr->Red) / 3);
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Bgr*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Gray*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от RGBA към Gray
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Rgba source_sample, Gray destination_sample)
		{
			Rgba* source_ptr = (Rgba*)source;
			Gray* destination_ptr = (Gray*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Intensity = (byte)((source_ptr->Red + source_ptr->Green + source_ptr->Blue) / 3);
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Rgba*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Gray*)destination;
				}
			}
		}

		/// <summary>
		/// Конвертиране от BGRA към Gray
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="source_sample">Сорс пример</param>
		/// <param name="destination_sample">Дестинационен пример</param>
		protected unsafe virtual void Convert(byte* source, byte* destination, int width, int height, int source_padding, int destination_padding, Bgra source_sample, Gray destination_sample)
		{
			Bgra* source_ptr      = (Bgra*)source;
			Gray* destination_ptr = (Gray*)destination;

			//Обхождане по Y
			for (int y = 0; y < height; y++)
			{
				//Обхождане по X
				for (int x = 0; x < width; x++)
				{

					//Конвертиране на данните
					destination_ptr->Intensity = (byte)((source_ptr->Red + source_ptr->Green + source_ptr->Blue) / 3);
					//Минаване към следващия пиксел
					source_ptr++;
					destination_ptr++;
				}

				//Отместване
				if (source_padding > 0)
				{
					source = (byte*)source_ptr;
					source += source_padding;
					source_ptr = (Bgra*)source;
				}

				if (destination_padding > 0)
				{
					destination = (byte*)destination_ptr;
					destination += destination_padding;
					destination_ptr = (Gray*)destination;
				}
			}
		}

		#endregion

		#region To Bitmap

		/// <summary>
		/// Вземане на изображението като Bitmap
		/// </summary>
		/// <returns>Bitmap</returns>
		public System.Drawing.Bitmap ToBitmap()
		{
			//Декларация на семпъл за дестинацията
			IColor destination_sample = null;
			//Създаване на семпъл за сорса
			T source_sample = default(T);
			//Деклариране на битмап
			System.Drawing.Bitmap bitmap = null;
			//Деклариране на битовете за изображението
			System.Drawing.Imaging.BitmapData bitData = null;
			//Създаване на съвместим битмап
			switch(this.Depth)
			{
				case 1:
					//Задаване на битмап данните
					bitmap  = new System.Drawing.Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
					bitData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, this.Width, this.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
					//Задаване на дестинационния семпъл
					destination_sample = new Gray();
					//Иземване на палитрата
					System.Drawing.Imaging.ColorPalette cp = bitmap.Palette;
					//Инициализиране на палитрата
					for (int i = 0; i < 256; i++)
					{
						cp.Entries[i] = System.Drawing.Color.FromArgb(i, i, i);
					}
					//Презадаване на палитрата
					bitmap.Palette = cp;
					break;
				case 3:
					//Задаване на битмап данните
					bitmap  = new System.Drawing.Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
					bitData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, this.Width, this.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
					//Задаване на дестинационния семпъл
					destination_sample = new Bgr();
					break;
				case 4:
					//Задаване на битмап данните
					bitmap  = new System.Drawing.Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					bitData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, this.Width, this.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					//Задаване на дестинационния семпъл
					destination_sample = new Bgra();
					break;
			}
			//Пресмятане на паддинга
			int padding = bitData.Stride - this.Width * this.Depth;
			//Вземане на адреса на първата линия от изображението
			IntPtr ptr = bitData.Scan0;
			//Намиране на голимината на масива в байтове
			int size   = bitData.Stride * this.Height;

			//Проверка нужно ли е конвертиране
			if (source_sample.GetType() == destination_sample.GetType())
			{
				//Проверка дали ни е нужно отместване
				if (padding == 0)
				{
					//Копиране на валутите в изображението
					Runtime.Memory.Copy(this.Bytes, ptr, size);
				}
				else
				{
					//Индекс в сорса
					int src_index = 0;
					//Индекс в дестинацията
					int dst_index = 0;
					//Копиране на байтовете в масива
					for (int y = 0; y < this.Height; y++)
					{
						//Копиране на линията
						Runtime.Memory.Copy(this.Bytes, src_index, ptr, dst_index, this.Stride);
						//Задаване на индексите
						src_index += this.Stride;
						dst_index += bitData.Stride;
					}
				}
			}
			else
			{
				//Конвертиране
				unsafe
				{
					fixed (byte* source = this.Bytes)
					{
						this.Convert(source, (byte*)ptr, this.Width, this.Height, 0, padding, source_sample, destination_sample);
					}
				}
			}

			//Отключване на изображението
			bitmap.UnlockBits(bitData);

			//Връщане на полученото изображение
			return bitmap;
		}

		#endregion

		#region Get Pixel

		/// <summary>
		/// Иземване на пиксел
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		/// <returns>Цвят</returns>
		public T GetPixel(int x, int y)
		{
			return this[x, y];
		}

		#endregion

		#region Set Pixel

		/// <summary>
		/// Задаване на пиксел
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		/// <param name="color">Цвят</param>
		public void SetPixel(int x, int y, T color)
		{
			this[x, y] = color;
		}

		#endregion

		#region Get Average

		/// <summary>
		/// Вземане на средния цвят
		/// </summary>
		/// <returns>Цвят</returns>
		public unsafe T GetAverage()
		{
			//Декларация на броя на компонентите
			int components = this.Width * this.Height;
			//Декларация на компонентите
			double a = 0, b = 0, c = 0, d = 0;
			//Вземане на пойнтера
			fixed (byte* _bytes = this.Bytes)
			{
				//Презадаване на пойнтера
				byte* bytes = _bytes;
				//Проверка на броя на компонентите
				switch (this.Depth)
				{
					case 1:
						//Обхождане по Y
						for (int y = 0; y < this.Height; y++)
						{
							//Обхождане по X
							for (int x = 0; x < this.Width; x++)
							{
								a += *bytes++;
							}
						}
						break;
					case 3:
						//Обхождане по Y
						for (int y = 0; y < this.Height; y++)
						{
							//Обхождане по X
							for (int x = 0; x < this.Width; x++)
							{
								a += *bytes++;
								b += *bytes++;
								c += *bytes++;
							}
						}
						break;
					case 4:
						//Обхождане по Y
						for (int y = 0; y < this.Height; y++)
						{
							//Обхождане по X
							for (int x = 0; x < this.Width; x++)
							{
								a += *bytes++;
								b += *bytes++;
								c += *bytes++;
								d += *bytes++;
							}
						}
						break;
				}
			}
			//Пресмятане на средните валути
			a /= components;
			b /= components;
			c /= components;
			d /= components;
			//Създаване на резултатния цвят
			T color = new T();
			//Задаване на байтовете
			color.SetBytes(new byte[] { (byte)a, (byte)b, (byte)c, (byte)d });
			//Връщане на резултата
			return color;
		}

		#endregion

		#region Crop

		/// <summary>
		/// Направа на сряз на изображението
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		/// <param name="width">Дължина</param>
		/// <param name="height">Височина</param>
		/// <returns>Срязано изображение</returns>
		public unsafe Image<T> Crop(int x, int y, int width, int height)
		{
			//Проверка възможен ли е сряза
			if (x < 0 || y < 0 || x + width >= this.Width || y + height >= this.Height)
			{
				throw new IndexOutOfRangeException();
			}

			//Създаване на новото изображение
			Image<T> cropped = new Image<T>(width, height);
			//Презадаване на размерите да отговарят към сорса
			width  = width + x;
			height = height + y;
			//Задаване на броя на компонентите
			int components = this.Depth;
			//Вземане на дължината на линията
			int stride = this.Stride;
			//Задаване на местата за прескачане
			int width_offset = x * components;
			int height_offset = y * stride;
			int width_padding = (this.Width - width) * components;
			//Вземане на началните пойнтери
			fixed (byte* _source = this.Bytes, _destination = cropped.Bytes)
			{
				//Презадаване на пойнтерите
				byte* source = _source;
				byte* destination = _destination;
				//Прескачане на началото на линията по Y
				source += height_offset;
				//Обхождане по Y
				for (int sy = y; sy < height; sy++)
				{
					//Прескачане на началото на линията по X
					source += width_offset;
					//Обхождане по X
					for (int sx = x; sx < width; sx++)
					{
						for (int sc = 0; sc < components; sc++)
						{
							//Задаване на компонентите
							*destination++ = *source++;
						}
					}
					//Прескачане на остатъка от линията по X
					source += width_padding;
				}
			}

			//Връщане на резултата
			return cropped;
		}

		/// <summary>
		/// Направа на сряз на изображението
		/// </summary>
		/// <param name="width">Дължина</param>
		/// <param name="height">Височина</param>
		/// <returns>Изрязано изображение</returns>
		public Image<T> Crop(int width, int height)
		{
			return this.Crop(0, 0, width, height);
		}

		#endregion

		#region Indexes

		/// <summary>
		/// Достъпване като масив
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		/// <returns>Цвят</returns>
		public T this[int x, int y]
		{
			get
			{
				//Проверка за валидни X и Y - бави
				if (x < 0 || x >= this.Width || y < 0 || y >= this.Height)
				{
					//Връщане на празен пиксел
					return default(T);
				}
				//Намиране на индекса
				int index = (y * this.Width + x) * this.Depth;
				//Създаване на пиксела
				T pixel = new T();
				//Задаване на байтовете
				pixel.SetBytes(this.Bytes, index);
				//Връщане на пиксела
				return pixel;
			}

			set
			{
				//Проверка за валидни X и Y - бави
				if (x < 0 || x >= this.Width || y < 0 || y >= this.Height)
				{
					//Излизане от функцията
					return;
				}
				//Намиране на индекса
				int index = (y * this.Width + x) * this.Depth;
				//Вземане на байтовете
				byte[] bytes = value.GetBytes();
				//Копиране на байтовете
				Runtime.Memory.Copy(bytes, 0, this.Bytes, index, bytes.Length);
			}
		}

		/// <summary>
		/// Достъпаване като масив
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		/// <param name="c">Компонент</param>
		/// <returns></returns>
		public byte this[int x, int y, int c]
		{
			get
			{
				//Намиране на индекса
				int index = ((y * this.Width + x) * this.Depth) + c;
				//Проверка дали съществува - забавяния
				if (index >= this.Length) return 0;
				//Връщане на компонента
				return this.Bytes[index];
			}

			set
			{
				//Намиране на индекса
				int index = ((y * this.Width + x) * this.Depth) + c;
				//Проверка дали съществува - забавяния
				if (index >= this.Length) return;
				//Задаване на компонента
				this.Bytes[index] = value;
			}
		}

		#endregion

	}
}
