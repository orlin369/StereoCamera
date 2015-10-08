using System;
using System.Runtime;
using System.Runtime.InteropServices;
using DevilVision.Drawing.Colors;

namespace DevilVision.Runtime
{

	/// <summary>
	/// Клас за забота със паметта
	/// </summary>
	public static class Memory
	{

		#region Imports

		[DllImport("ntdll.dll", CallingConvention=CallingConvention.Cdecl)]
		private static extern IntPtr memcpy(IntPtr dst, IntPtr src, int count);

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int memcmp(byte[] b1, byte[] b2, int count);

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int memcmp(IntPtr b1, IntPtr b2, int count);

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int memcmp(IntPtr b1, byte[] b2, int count);

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int memcmp(byte[] b1, IntPtr b2, int count);

		#endregion

		#region Copy

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		public static void Copy(byte[] source, byte[] destination)
		{
			//Намиране на дължината за копиранес
			int length = Math.Min(source.Length, destination.Length);
			//Копиране на данните
			Memory.Copy(source, destination, length);
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		public static void Copy(byte[] source, IntPtr destination)
		{
			Memory.Copy(source, destination, source.Length);
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		public static void Copy(IntPtr source, byte[] destination)
		{
			Memory.Copy(source, destination, destination.Length);
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="length">Дължина на данните</param>
		public static void Copy(IntPtr source, IntPtr destination, int length)
		{
			memcpy(destination, source, length);
		}

		/// <summary>
		/// Копиране на данните от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="length">Дължина на данните</param>
		public static unsafe void Copy(byte[] source, IntPtr destination, int length)
		{
			fixed (byte* _source = source)
			{
				memcpy(destination, (IntPtr)_source, length);
			}
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="length">Дължина на данните</param>
		public static unsafe void Copy(IntPtr source, byte[] destination, int length)
		{
			fixed (byte* _destination = destination)
			{
				memcpy((IntPtr)_destination, source, length);
			}
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="length">Дължина на данните</param>
		public static unsafe void Copy(byte[] source, byte[] destination, int length)
		{
			fixed (byte* _source = source, _destination = destination)
			{
				memcpy((IntPtr)_destination, (IntPtr)_source, length);
			}
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="source_index">Стартов индекс на сорса</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="destination_index">Стартов индекс на дестинацията</param>
		/// <param name="length">Дължина на данните</param>
		public static unsafe void Copy(IntPtr source, int source_index, IntPtr destination, int destination_index, int length)
		{
			//Задаване на адреса на сорса
			byte* source_ptr = (byte*)source;
			//Добавяне на отместването
			source_ptr += source_index;
			//Задаване на адреса на дестинацията
			byte* destination_ptr = (byte*)destination;
			//Добавяне на отместването
			destination_ptr += destination_index;
			//Копиране на данните
			memcpy((IntPtr)destination_ptr, (IntPtr)source_ptr, length);
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="sorce">Сорс</param>
		/// <param name="source_index">Стартов индекс на сорса</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="destination_index">Стартов индекс на дестинацията</param>
		/// <param name="length">Дължина на данните</param>
		public static unsafe void Copy(byte[] source, int source_index, IntPtr destination, int destination_index, int length)
		{
			fixed (byte* _source = source)
			{
				//Задаване на нефиксиран адрес
				byte* source_ptr = _source;
				//Добавяне на отместването
				source_ptr += source_index;
				//Задаване на адреса на дестинацията
				byte* destination_ptr = (byte*)destination;
				//Добавяне на отместването
				destination_ptr += destination_index;
				//Копиране на данните
				memcpy((IntPtr)destination_ptr, (IntPtr)source_ptr, length);
			}
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="source_index">Стартов индекс на сорса</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="destination_index">Стартов индекс на дестинацията</param>
		/// <param name="length">Дължина на данните</param>
		public static unsafe void Copy(IntPtr source, int source_index, byte[] destination, int destination_index, int length)
		{
			fixed (byte* _destination = destination)
			{
				//Задаване на нефиксиран адрес
				byte* source_ptr = (byte*)source;
				//Добавяне на отместването
				source_ptr += source_index;
				//Задаване на адреса на дестинацията
				byte* destination_ptr = _destination;
				//Добавяне на отместването
				destination_ptr += destination_index;
				//Копиране на данните
				memcpy((IntPtr)destination_ptr, (IntPtr)source_ptr, length);
			}
		}

		/// <summary>
		/// Копиране на данни от паметта
		/// </summary>
		/// <param name="source">Сорс</param>
		/// <param name="source_index">Стартов индекс на сорса</param>
		/// <param name="destination">Дестинация</param>
		/// <param name="destination_index">Стартов индекс на дестинацияа</param>
		/// <param name="length">Дължина на данните</param>
		public static unsafe void Copy(byte[] source, int source_index, byte[] destination, int destination_index, int length)
		{
			fixed (byte* _source = source, _destination = destination)
			{
				//Задаване на нефиксиран адрес
				byte* source_ptr = _source;
				//Добавяне на отместването
				source_ptr += source_index;
				//Задаване на адреса на дестинацията
				byte* destination_ptr = (byte*)_destination;
				//Добавяне на отместването
				destination_ptr += destination_index;
				//Копиране на данните
				memcpy((IntPtr)destination_ptr, (IntPtr)source_ptr, length);
			}
		}

		#endregion

		#region Compare

		/// <summary>
		/// Сравняване на два байт масива
		/// </summary>
		/// <param name="b1">Масив 1</param>
		/// <param name="b2">Масив 2</param>
		/// <returns></returns>
		public static bool Compare(byte[] b1, byte[] b2)
		{
			return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
		}

		/// <summary>
		/// Сравняване на част от два байт масива
		/// </summary>
		/// <param name="b1">Масив 1</param>
		/// <param name="b2">Масив 2</param>
		/// <param name="count">Размер на сравняваната част</param>
		/// <returns></returns>
		public static bool Compare(byte[] b1, byte[] b2, int count)
		{
			return memcmp(b1, b2, count) == 0;
		}

		/// <summary>
		/// Сравняване на поинтер с байт масив
		/// </summary>
		/// <param name="p">Пойнтер</param>
		/// <param name="b">Масив</param>
		/// <param name="count">Размер на сравняваната част</param>
		/// <returns></returns>
		public static bool Compare(IntPtr p, byte[] b, int count)
		{
			return memcmp(p, b, count) == 0;
		}

		/// <summary>
		/// Сравняване на поинтер с байт масив
		/// </summary>
		/// <param name="b">Масив</param>
		/// <param name="p">Пойнтер</param>
		/// <param name="count">Размер на сравняваната част</param>
		/// <returns></returns>
		public static bool Compare(byte[] b, IntPtr p, int count)
		{
			return memcmp(b, p, count) == 0;
		}

		/// <summary>
		/// Сравняване на два пойнтера
		/// </summary>
		/// <param name="p1">Пойнтер 1</param>
		/// <param name="p2">Пойнтер 2</param>
		/// <param name="count">Размер на сравняваната част</param>
		/// <returns></returns>
		public static bool Compare(IntPtr p1, IntPtr p2, int count)
		{
			return memcmp(p1, p2, count) == 0;
		}

		#endregion

	}
}
