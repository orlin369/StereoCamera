using System;
using System.Drawing;

namespace DevilVision.Drawing.Colors
{
	/// <summary>
	/// Сив цвят
	/// </summary>
	public struct Gray : IColor
	{

		#region Variables

		/// <summary>
		/// Интензитет
		/// </summary>
		public byte Intensity;

		#endregion

		#region Properties

		/// <summary>
		/// Размер
		/// </summary>
		public int Size
		{
			get
			{
				return 1;
			}
		}

		/// <summary>
		/// Цвят
		/// </summary>
		public System.Drawing.Color Color
		{
			get
			{
				return System.Drawing.Color.FromArgb(this.Intensity, this.Intensity, this.Intensity);
			}

			set
			{
				this.Intensity = (byte)((value.R + value.G + value.B) / 3);
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="intensity">Интензитет</param>
		public Gray(byte intensity)
		{
			this.Intensity = intensity;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="red">Червено</param>
		/// <param name="green">Зелено</param>
		/// <param name="blue">Синьо</param>
		public Gray(byte red, byte green, byte blue)
		{
			//Формулата може и да се смени
			//защото е приета друга формула
			//за конвертирането, но в момента
			//се използва тази защото е по-бърза
			this.Intensity = (byte)((red + green + blue) / 3);
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="color">Цвят</param>
		public Gray(Color color) : this(color.R, color.G, color.B)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgb">Цвят</param>
		public Gray(Rgb rgb) : this(rgb.Red, rgb.Green, rgb.Blue)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="rgba">Цвят</param>
		public Gray(Rgba rgba) : this(rgba.Red, rgba.Green, rgba.Blue)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgra">Цвят</param>
		public Gray(Bgra bgra) : this(bgra.Red, bgra.Green, bgra.Blue)
		{
			//Всичко е в горната линия
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="bgr">Цвят</param>
		public Gray(Bgr bgr) : this(bgr.Red, bgr.Green, bgr.Blue)
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
			return new byte[] { this.Intensity };
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
			this.Intensity = bytes[index];
		}

		#endregion

		#region To String

		/// <summary>
		/// Вземане на цвета като стринг
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("Gray [Intensity={0}]", this.Intensity);
		}

		#endregion

	}
}
