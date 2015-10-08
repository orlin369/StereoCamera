using System;

namespace DevilVision.Drawing
{
	using Colors;

	/// <summary>
	/// Изображение
	/// </summary>
	public interface IImage
	{

		#region Properties

		/// <summary>
		/// Байтове
		/// </summary>
		byte[] Bytes
		{
			get;
		}

		/// <summary>
		/// Широчина
		/// </summary>
		int Width
		{
			get;
		}

		/// <summary>
		/// Височина
		/// </summary>
		int Height
		{
			get;
		}

		/// <summary>
		/// Линия
		/// </summary>
		int Stride
		{
			get;
		}

		/// <summary>
		/// Дължина
		/// </summary>
		int Length
		{
			get;
		}

		/// <summary>
		/// Дълбочина
		/// </summary>
		int Depth
		{
			get;
		}

		#endregion

		#region To Bitmap

		/// <summary>
		/// Вземане на изображението като битмап
		/// </summary>
		/// <returns></returns>
		System.Drawing.Bitmap ToBitmap();

		#endregion

	}
}
