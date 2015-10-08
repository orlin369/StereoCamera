using System;
using System.Drawing;

namespace DevilVision.Drawing.Colors
{
	/// <summary>
	/// RGBA цвят
	/// </summary>
	public struct Rgba : IColor
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
				this.Red   = value.R;
				this.Green = value.G;
				this.Blue  = value.B;
				this.Alpha = value.A;
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
		/// <param name="alpha">Алфа</param>
		public Rgba(byte red, byte green, byte blue, byte alpha)
		{
			this.Red   = red;
			this.Green = green;
			this.Blue  = blue;
			this.Alpha = alpha;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="color">Цвят</param>
		public Rgba(Color color)
		{
			this.Red   = color.R;
			this.Green = color.G;
			this.Blue  = color.B;
			this.Alpha = color.A;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgb">Цвят</param>
		public Rgba(Rgb rgb)
		{
			this.Red   = rgb.Red;
			this.Green = rgb.Green;
			this.Blue  = rgb.Blue;
			this.Alpha = 255;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgba">Цвят</param>
		public Rgba(Rgba rgba)
		{
			this.Red   = rgba.Red;
			this.Green = rgba.Green;
			this.Blue  = rgba.Blue;
			this.Alpha = rgba.Alpha;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgra">Цвят</param>
		public Rgba(Bgra bgra)
		{
			this.Red   = bgra.Red;
			this.Green = bgra.Green;
			this.Blue  = bgra.Blue;
			this.Alpha = bgra.Alpha;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgr">Цвят</param>
		public Rgba(Bgr bgr)
		{
			this.Red   = bgr.Red;
			this.Green = bgr.Green;
			this.Blue  = bgr.Blue;
			this.Alpha = 255;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="gray">Цвят</param>
		public Rgba(Gray gray)
		{
			this.Red   = gray.Intensity;
			this.Green = gray.Intensity;
			this.Blue  = gray.Intensity;
			this.Alpha = 255;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="intensity">Интензитет</param>
		public Rgba(byte intensity)
		{
			this.Red   = intensity;
			this.Green = intensity;
			this.Blue  = intensity;
			this.Alpha = 255;
		}

		#endregion

		#region Get Bytes

		/// <summary>
		/// Вземане на байтовете
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			return new byte[] { this.Red, this.Green, this.Blue, this.Alpha };
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
			return String.Format("Rgba [Red={0}, Green={1}, Blue={2}, Alpha={3}]", this.Red, this.Green, this.Blue, this.Alpha);
		}

		#endregion

	}
}
