using System;
using DevilVision.Detection;

namespace DevilVision.Detection.Masks
{
	/// <summary>
	/// Маска за движение
	/// </summary>
	public class MotionMask : Mask
	{

		#region Constructors

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="previous">Предишни блокове</param>
		/// <param name="current">Текущи блокове</param>
		public MotionMask(Blocks previous, Blocks current)
		{
			//Проверка дали двата блока са съвместими
			if (previous.Width != current.Width || previous.Height != current.Height)
			{
				throw new Exception("Blocks are not compatible");
			}
			
			//Локализиране на блоковете
			byte[,,] p_data = previous.Data;
			byte[,,] c_data = current.Data;
			//Локализиране на размерите
			int width  = current.Width;
			int height = current.Height;
			//Локализиране на компонентите
			int components = current.Components;
			//Създаване на масива за маската
			byte[,] mask = new byte[height, width];

			//Създаване на самата маска
			for (int y = 1; y < height - 1; y++)
			{
				for (int x = 1; x < width - 1; x++)
				{

					//byte m1 = (byte)((p_data[y, x, 2] == c_data[y - 1, x - 1, 2]) ? 255 : 0);
					//byte m2 = (byte)((p_data[y, x, 2] == c_data[y - 1, x, 2]) ? 255 : 0);
					//byte m3 = (byte)((p_data[y, x, 2] == c_data[y - 1, x + 1, 2]) ? 255 : 0);

					byte m0 = (byte)Math.Abs(p_data[y, x, 2] - c_data[y, x, 2]);
					byte m1 = (byte)Math.Abs(p_data[y, x, 2] - c_data[y - 1, x - 1, 2]);
					byte m2 = (byte)Math.Abs(p_data[y, x, 2] - c_data[y - 1, x, 2]);
					byte m3 = (byte)Math.Abs(p_data[y, x, 2] - c_data[y - 1, x + 1, 2]);

					//byte m1 = (byte)(p_data[y, x, 2] / Math.Max(c_data[y - 1, x - 1, 2], (byte)1));
					//byte m2 = (byte)(p_data[y, x, 2] / Math.Max(c_data[y - 1, x , 2], (byte)1));
					//byte m3 = (byte)(p_data[y, x, 2] / Math.Max(c_data[y - 1, x + 1, 2], (byte)1));
					//Вземане на трите варианта
					//byte m1 = (byte)(Math.Min(p_data[y, x, 2], c_data[y - 1, x - 1, 2]) / Math.Max(Math.Max(p_data[y, x, 2], c_data[y - 1, x - 1, 2]), (byte)1));
					//byte m2 = (byte)(Math.Min(p_data[y, x, 2], c_data[y - 1, x, 2]) / Math.Max(Math.Max(p_data[y, x, 2], c_data[y - 1, x, 2]), (byte)1));
					//byte m3 = (byte)(Math.Min(p_data[y, x, 2], c_data[y - 1, x + 1, 2]) / Math.Max(Math.Max(p_data[y, x, 2], c_data[y - 1, x + 1, 2]), (byte)1));
					//Вземане на максималната валута
					mask[y, x] = (byte)((Math.Min(Math.Min(Math.Min(m0, m1), m2), m3) > 10) ? 255 : 0);
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
