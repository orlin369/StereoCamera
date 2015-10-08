using System;
using DevilVision.Detection;


namespace DevilVision.Detection.Masks
{
	/// <summary>
	/// Генерирана маска
	/// </summary>
	public class GenericMask : Mask
	{

		#region Constructors

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="width">Широчина</param>
		/// <param name="height">Височина</param>
		/// <param name="data">Данни</param>
		public GenericMask(int width, int height, byte[,] data)
		{
			//Проверка дали размерите отговарят на данните
			if (width * height != data.Length)
			{
				throw new Exception("Data is not compatible with this width and height");
			}

			//Задаване на размерите
			this.Width = width;
			this.Height = height;
			//Задаване на данните
			this.Data = data;
		}

		#endregion

	}
}
