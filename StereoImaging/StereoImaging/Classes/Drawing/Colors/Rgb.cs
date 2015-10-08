using System;
using System.Drawing;

namespace DevilVision.Drawing.Colors
{
	/// <summary>
	/// RGB цвят
	/// </summary>
	public struct Rgb : IColor
	{

		#region Variables

		/// <summary>
		/// Червено
		/// </summary>
		public byte Red;
		
		/// <summary>
		/// Зелено
		/// </summary>
		public byte Green;
		
		/// <summary>
		/// Синьо
		/// </summary>
		public byte Blue;

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
				this.Red   = value.R;
				this.Green = value.G;
				this.Blue  = value.B;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="red">Червено</param>
		/// <param name="green">Зелено</param>
		/// <param name="blue">Синьо</param>
		public Rgb(byte red, byte green, byte blue)
		{
			this.Red   = red;
			this.Green = green;
			this.Blue  = blue;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="color">Цвят</param>
		public Rgb(Color color) : this(color.R, color.G, color.B)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgba">Цвят</param>
		public Rgb(Rgba rgba) : this(rgba.Red, rgba.Green, rgba.Blue)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgb">Цвят</param>
		public Rgb(Rgb rgb) : this(rgb.Red, rgb.Green, rgb.Blue)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgra">Цвят</param>
		public Rgb(Bgra bgra) : this(bgra.Red, bgra.Green, bgra.Blue)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgr">Цвят</param>
		public Rgb(Bgr bgr) : this(bgr.Red, bgr.Green, bgr.Blue)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="gray">Цвят</param>
		public Rgb(Gray gray) : this(gray.Intensity, gray.Intensity, gray.Intensity)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="intensity">Интензитет</param>
		public Rgb(byte intensity) : this(intensity, intensity, intensity)
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
			return new byte[] { this.Red, this.Green, this.Blue };
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
			this.Red   = bytes[index];
			this.Green = bytes[++index];
			this.Blue  = bytes[++index];
		}

		#endregion

		#region To String

		/// <summary>
		/// Вземане на цвета като стринг
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("Rgb [Red={0}, Green={1}, Blue={2}]", this.Red, this.Green, this.Blue);
		}

		#endregion

	}
}
