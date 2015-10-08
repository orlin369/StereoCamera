using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DevilVision.Drawing.Colors
{
	/// <summary>
	/// BGR цвят
	/// </summary>
	public struct Bgr : IColor
	{

		#region Variables

		/// <summary>
		/// Синьо
		/// </summary>
		public byte Blue;

		/// <summary>
		/// Зелено
		/// </summary>
		public byte Green;

		/// <summary>
		/// Червено
		/// </summary>
		public byte Red;

		#endregion

		#region Properties

		/// <summary>
		/// Размер
		/// </summary>
		public int Size
		{
			get
			{
				return 3;
			}
		}

		/// <summary>
		/// Цвят
		/// </summary>
		public System.Drawing.Color Color
		{
			get
			{
				return System.Drawing.Color.FromArgb(this.Red, this.Green, this.Blue);
			}

			set
			{
				this.Blue  = value.B;
				this.Green = value.G;
				this.Red   = value.R;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="blue">Синьо</param>
		/// <param name="green">Зелено</param>
		/// <param name="red">Червено</param>
		public Bgr(byte blue, byte green, byte red)
		{
			this.Blue  = blue;
			this.Green = green;
			this.Red   = red;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="color">Цвят</param>
		public Bgr(Color color) : this(color.B, color.G, color.R)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgba">Цвят</param>
		public Bgr(Rgba rgba) : this(rgba.Blue, rgba.Green, rgba.Red)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgb">Цвят</param>
		public Bgr(Rgb rgb) : this(rgb.Blue, rgb.Green, rgb.Red)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgra">Цвят</param>
		public Bgr(Bgra bgra) : this(bgra.Blue, bgra.Green, bgra.Red)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgr">Цвят</param>
		public Bgr(Bgr bgr) : this(bgr.Blue, bgr.Green, bgr.Red)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="gray">Цвят</param>
		public Bgr(Gray gray) : this(gray.Intensity, gray.Intensity, gray.Intensity)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="intensity">Интензитет</param>
		public Bgr(byte intensity) : this(intensity, intensity, intensity)
		{
			//Всичко е в горната линия
		}

		#endregion

		#region Get Bytes

		/// <summary>
		/// Вземане на байтовете
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			return new byte[] { this.Blue, this.Green, this.Red };
		}

		#endregion

		#region Set Bytes

		/// <summary>
		/// Задаване на байтовете
		/// </summary>
		/// <param name="bytes">Байтове</param>
		/// <param name="index">Начален индекс</param>
		public void SetBytes(byte[] bytes, int index = 0)
		{
			this.Blue  = bytes[index];
			this.Green = bytes[++index];
			this.Red   = bytes[++index];
		}

		#endregion

		#region To String

		/// <summary>
		/// Вземане на цвета като стринг
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("Bgr [Blue={0}, Green={1}, Red={2}]", this.Blue, this.Green, this.Red);
		}

		#endregion

	}
}
