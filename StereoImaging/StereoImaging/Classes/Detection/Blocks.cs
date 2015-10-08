using System;
using DevilVision.Drawing;
using DevilVision.Drawing.Colors;

namespace DevilVision.Detection
{
	/// <summary>
	/// Блокове на изображение
	/// </summary>
	public class Blocks
	{

		#region Properties

		/// <summary>
		/// Размер на един блок
		/// Да се има в предвид че един блок е квадратен
		/// </summary>
		public int BlockSize
		{
			get;
			protected set;
		}

		/// <summary>
		/// Броя на компонентите
		/// </summary>
		public int Components
		{
			get;
			protected set;
		}

		/// <summary>
		/// Широчина на блоковете
		/// </summary>
		public int Width
		{
			get;
			protected set;
		}

		/// <summary>
		/// Височина на блоковете
		/// </summary>
		public int Height
		{
			get;
			protected set;
		}

		/// <summary>
		/// Изображение
		/// </summary>
		public Image<Gray> Image
		{
			get;
			protected set;
		}

		/// <summary>
		/// Данни за блоковете
		/// </summary>
		public byte[,,] Data
		{
			get;
			protected set;
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Създаване на блокове от изображение
		/// </summary>
		/// <param name="image">Изображение</param>
		public Blocks(IImage image) : this(new Image<Gray>(image))
		{
			//Конверсията е в горната линия
		}

		/// <summary>
		/// Създаване на блокове от изображение
		/// </summary>
		/// <param name="image">Изображение</param>
		public Blocks(Image<Gray> image)
		{
			//Променливи за настройките
			int width, height, block_size;
			//Задаване на размера на блоковете
			if (image.Width >= 640 && image.Height >= 480)
			{
				block_size = 8;
			}
			else
			{
				block_size = 2;
			}

			//Изчисляване на размерите
			width  = image.Width / block_size;
			height = image.Height / block_size;
			//Пресмятане на броя на компонентите
			int components = block_size * block_size;
			//Създаване на масив за пълните данни
			byte[, ,] data = new byte[height, width, components];
			//Задаване на индексите
			int x_index, y_index, cx_index, cy_index;
			//Задаване на размера който можем да обходим
			int image_width = width * block_size;
			int image_height = height * block_size;
			//Намиране на размера на линията
			int stride = image.Stride;
			//Локализиране на данните за изображението
			byte[] image_data = image.Bytes;
			//Обхождане на данните
			for (int y = 0; y < image_height; y++)
			{
				//Задаване на индекса по Y
				y_index = y / block_size;
				//Задаване на индекса на компонента
				cy_index = (y % block_size) * block_size;

				for (int x = 0; x < image_width; x++)
				{
					//Задаване на индекса по X
					x_index = x / block_size;
					//Задаване на индекса на компонента
					cx_index = cy_index + x % block_size;
					//Попълване на данните
					data[y_index, x_index, cx_index] = image_data[stride * y + x];
				}
			}

			//Създаване на масив с данни за минимум и максимум
			byte[, ,] mm_data = new byte[height, width, 3];

			//Задаване на минимум и максимум данните
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					byte min = data[y,x,0];
					byte max = min;
					uint avg = 0;
					byte cur;
					//
					for (int c = 1; c < components; c++)
					{
						cur = data[y, x, c];
						//
						avg += cur;
						//
						if (cur < min) min = cur;
						if (cur > max) max = cur;
					}
					//
					mm_data[y, x, 0] = min;
					mm_data[y, x, 1] = max;
					mm_data[y, x, 2] = (byte)(avg / components);
				}
			}

			/*
			//Задаване на масив за усреднените данни
			byte[,] average_data = new byte[height, width];
			
			//Задаване на данните с усреднените
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					int average = 0;
					//
					for (int c = 0; c < components; c++)
					{
						average += data[y, x, c];
					}
					//
					average_data[y, x] = (byte)(average / components);
				}
			}
			*/

			//Задаване на данните
			this.Data = mm_data;
			//Задаване на изображението
			this.Image = image;
			//Задаване на размерите
			this.Width = width;
			this.Height = height;
			//Задаване на броя на компонентите
			this.Components = components;
			//Задаване на размера на блоковете
			this.BlockSize = block_size;
		}

		#endregion

		#region To Image

		/// <summary>
		/// Вземане на блоковете като изображение
		/// </summary>
		/// <returns></returns>
		public Image<Gray> ToImage()
		{
			return new Image<Gray>(this.Width * 2, this.Height, this.Data);
		}

		#endregion

		#region To Bitmap

		/// <summary>
		/// Конвертиране в битмап
		/// </summary>
		/// <returns></returns>
		public System.Drawing.Bitmap ToBitmap()
		{
			return this.ToImage().ToBitmap();
		}

		#endregion

	}
}
