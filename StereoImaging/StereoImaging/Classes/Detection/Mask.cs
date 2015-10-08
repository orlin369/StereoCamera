using System;
using DevilVision.Drawing;
using DevilVision.Drawing.Colors;

namespace DevilVision.Detection
{
	using Masks;

	/// <summary>
	/// Маска
	/// </summary>
	public abstract class Mask
	{

		#region Properties

		/// <summary>
		/// Данни на маската
		/// </summary>
		public byte[,] Data
		{
			get;
			protected set;
		}

		/// <summary>
		/// Широчина на маската
		/// </summary>
		public int Width
		{
			get;
			protected set;
		}

		/// <summary>
		/// Височина на маската
		/// </summary>
		public int Height
		{
			get;
			protected set;
		}

		#endregion

		#region To Image

		/// <summary>
		/// Вземане на маската като изображение
		/// </summary>
		/// <returns></returns>
		public Image<Gray> ToImage()
		{
			return new Image<Gray>(this.Width, this.Height, this.Data);
		}

		#endregion

		#region To Bitmap

		/// <summary>
		/// Вземане като битмап
		/// </summary>
		/// <returns></returns>
		public System.Drawing.Bitmap ToBitmap()
		{
			return this.ToImage().ToBitmap();
		}

		#endregion

		#region Operators

		/// <summary>
		/// Бинарен И оператор
		/// </summary>
		/// <param name="a">Маска А</param>
		/// <param name="b">Маска Б</param>
		/// <returns></returns>
		public static GenericMask operator &(Mask a, Mask b)
		{
			//Проверка дали маските са идентични
			if (a.Width != b.Width || a.Height != b.Height)
			{
				throw new Exception("Masks are not compatible");
			}

			//Локализиране на размерите
			int width  = a.Width;
			int height = a.Height;
			//Локализиране на данните на маските
			byte[,] mask_a = a.Data;
			byte[,] mask_b = b.Data;
			//Направа на масив за даните
			byte[,] mask = new byte[height, width];

			//Създаване на самата маска
			for (int y = 1; y < height - 1; y++)
			{
				for (int x = 1; x < width - 1; x++)
				{
					mask[y, x] = (byte)(mask_a[y, x] & mask_b[y, x]);
				}
			}

			//Връщане на маската
			return new GenericMask(width, height, mask);
		}

		/// <summary>
		/// Бинарен ИЛИ оператор
		/// </summary>
		/// <param name="a">Маска А</param>
		/// <param name="b">Маска Б</param>
		/// <returns></returns>
		public static GenericMask operator |(Mask a, Mask b)
		{
			//Проверка дали маските са идентични
			if (a.Width != b.Width || a.Height != b.Height)
			{
				throw new Exception("Masks are not compatible");
			}

			//Локализиране на размерите
			int width = a.Width;
			int height = a.Height;
			//Локализиране на данните на маските
			byte[,] mask_a = a.Data;
			byte[,] mask_b = b.Data;
			//Направа на масив за даните
			byte[,] mask = new byte[height, width];

			//Създаване на самата маска
			for (int y = 1; y < height - 1; y++)
			{
				for (int x = 1; x < width - 1; x++)
				{
					mask[y, x] = (byte)(mask_a[y, x] | mask_b[y, x]);
				}
			}

			//Връщане на маската
			return new GenericMask(width, height, mask);
		}

		/// <summary>
		/// Изваждане на две маски
		/// </summary>
		/// <param name="a">Маска А</param>
		/// <param name="b">Маска Б</param>
		/// <returns></returns>
		public static GenericMask operator -(Mask a, Mask b)
		{
			//Проверка дали маските са идентични
			if (a.Width != b.Width || a.Height != b.Height)
			{
				throw new Exception("Masks are not compatible");
			}

			//Локализиране на размерите
			int width = a.Width;
			int height = a.Height;
			//Локализиране на данните на маските
			byte[,] mask_a = a.Data;
			byte[,] mask_b = b.Data;
			//Направа на масив за даните
			byte[,] mask = new byte[height, width];

			//Създаване на самата маска
			for (int y = 1; y < height - 1; y++)
			{
				for (int x = 1; x < width - 1; x++)
				{
					mask[y, x] = (byte)Math.Abs(mask_a[y, x] - mask_b[y, x]);
				}
			}

			//Връщане на маската
			return new GenericMask(width, height, mask);
		}

		/// <summary>
		/// Събиране на две маски
		/// </summary>
		/// <param name="a">Маска А</param>
		/// <param name="b">Маска Б</param>
		/// <returns></returns>
		public static GenericMask operator +(Mask a, Mask b)
		{
			//Проверка дали маските са идентични
			if (a.Width != b.Width || a.Height != b.Height)
			{
				throw new Exception("Masks are not compatible");
			}

			//Локализиране на размерите
			int width = a.Width;
			int height = a.Height;
			//Локализиране на данните на маските
			byte[,] mask_a = a.Data;
			byte[,] mask_b = b.Data;
			//Направа на масив за даните
			byte[,] mask = new byte[height, width];

			//Създаване на самата маска
			for (int y = 1; y < height - 1; y++)
			{
				for (int x = 1; x < width - 1; x++)
				{
					mask[y, x] = (byte)Math.Min(mask_a[y, x] + mask_b[y, x], 255);
				}
			}

			//Връщане на маската
			return new GenericMask(width, height, mask);
		}

		#endregion

	}
}
