using System;
using System.Drawing;

namespace DevilVision.Drawing.Colors
{
	/// <summary>
	/// Цвят
	/// </summary>
	public interface IColor
	{

		#region Properties

		/// <summary>
		/// Размер на цвета
		/// </summary>
		int Size
		{
			get;
		}

		/// <summary>
		/// Цвят
		/// </summary>
		Color Color
		{
			set;
			get;
		}

		#endregion

		#region Set Bytes

		/// <summary>
		/// Задаване на байтовете
		/// </summary>
		/// <param name="bytes">Байтове</param>
		/// <param name="index">Начален индекс</param>
		void SetBytes(byte[] bytes, int index = 0);

		#endregion

		#region Get Bytes

		/// <summary>
		/// Иземване на байтовете
		/// </summary>
		/// <returns>Байтове</returns>
		byte[] GetBytes();

		#endregion

	}
}
