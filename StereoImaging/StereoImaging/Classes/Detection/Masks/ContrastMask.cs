using System;
using DevilVision.Detection;

namespace DevilVision.Detection.Masks
{
	/// <summary>
	/// Маска за контраст
	/// </summary>
	public class ContrastMask : Mask
	{

		#region Constructor

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="blocks">Блокове</param>
		public ContrastMask(Blocks blocks)
		{
			//Локализиране на данните
			byte[, ,] data = blocks.Data;
			//Локализиране на размерите
			int width  = blocks.Width;
			int height = blocks.Height;
			//Създаване на масива за маската
			byte[,] mask = new byte[height, width];

			//Задаване на валута за средната стойност
			int average = 0;
			//Валута за текущия компонент
			byte cur;

			//Създаване на самата маска
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					cur = (byte)((double)((double)data[y, x, 0] / data[y, x, 1]) * 255);
					mask[y, x] = cur;
					average += cur;
				}
			}

			average /= (width * height);

			//Презадаване на валутите
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (mask[y, x] > average) mask[y, x] = 255; else mask[y, x] = 0;
				}
			}

			//Задаване на размерите
			this.Width = width;
			this.Height = height;
			//Задаване на маската
			this.Data = mask;
		}

		#endregion

	}
}
