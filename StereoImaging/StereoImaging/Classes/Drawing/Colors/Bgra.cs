using System;
using System.Drawing;

namespace DevilVision.Drawing.Colors
{
	/// <summary>
	/// BGRA цвят
	/// </summary>
	public struct Bgra : IColor
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

		/// <summary>
		/// Алфа
		/// </summary>
		public byte Alpha;

		#endregion

		#region Properties

		/// <summary>
		/// Размер
		/// </summary>
		public int Size
		{
			get
			{
				return 4;
			}
		}

		/// <summary>
		/// Цвят
		/// </summary>
		public System.Drawing.Color Color
		{
			get
			{
				return System.Drawing.Color.FromArgb(this.Alpha, this.Red, this.Green, this.Blue);
			}

			set
			{
				this.Blue  = value.B;
				this.Green = value.G;
				this.Red   = value.R;
				this.Alpha = value.A;
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
		/// <param name="alpha">Алфа</param>
		public Bgra(byte blue, byte green, byte red, byte alpha)
		{
			this.Blue  = blue;
			this.Green = green;
			this.Red   = red;
			this.Alpha = alpha;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="color">Цвят</param>
		public Bgra(Color color) : this(color.B, color.G, color.R, color.A)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgb">Цвят</param>
		public Bgra(Rgb rgb) : this(rgb.Blue, rgb.Green, rgb.Red, 255)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgba">Цвят</param>
		public Bgra(Rgba rgba) : this(rgba.Blue, rgba.Green, rgba.Red, rgba.Alpha)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgra">Цвят</param>
		public Bgra(Bgra bgra) : this(bgra.Blue, bgra.Green, bgra.Red, bgra.Alpha)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgr">Цвят</param>
		public Bgra(Bgr bgr) : this(bgr.Blue, bgr.Green, bgr.Red, 255)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="gray">Цвят</param>
		public Bgra(Gray gray) : this(gray.Intensity, gray.Intensity, gray.Intensity, 255)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="intensity">Интензитет</param>
		public Bgra(byte intensity)	: this(intensity, intensity, intensity, 255)
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
			return new byte[] { this.Blue, this.Green, this.Red, this.Alpha };
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
			this.Alpha = bytes[++index];
		}

		#endregion

		#region To String

		/// <summary>
		/// Вземане на цвета като стринг
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("Bgra [Blue={0}, Green={1}, Red={2}, Alpha={3}]", this.Blue, this.Green, this.Red, this.Alpha);
		}

		#endregion

	}
}
