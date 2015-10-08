using System;
using System.Drawing;
using System.Runtime;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace DevilVision.Video
{
	/// <summary>
	/// Четец за AVI файлове
	/// </summary>
	public class AviReader : IDisposable
	{

		#region Variables

		/// <summary>
		/// Файл
		/// </summary>
		private IntPtr file;
		
		/// <summary>
		/// Стреам
		/// </summary>
		private IntPtr stream;
		
		/// <summary>
		/// Фрейм
		/// </summary>
		private IntPtr frame;

		/// <summary>
		/// Широчина на видеото
		/// </summary>
		private int width;

		/// <summary>
		/// Височина на видеото
		/// </summary>
		private int height;

		/// <summary>
		/// Текуща позиция във стрема
		/// </summary>
		private int position;
		
		/// <summary>
		/// Стартова позиция
		/// </summary>
		private int start;
		
		/// <summary>
		/// Дължина
		/// </summary>
		private int length;
		
		/// <summary>
		/// Бързина
		/// </summary>
		private float rate;
		
		/// <summary>
		/// Кодек
		/// </summary>
		private string codec;

		/// <summary>
		/// Обект за синхронизация
		/// </summary>
		private object sync = new object();

		#endregion

		#region Properties

		/// <summary>
		/// Широчина на фрейма
		/// </summary>
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		/// <summary>
		/// Височина на фрейма
		/// </summary>
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		/// <summary>
		/// Позиция
		/// </summary>
		public int Position
		{
			get
			{
				return this.position;
			}

			set
			{
				this.position = ((value < this.start) || (value >= this.start + this.length)) ? this.start : value;
			}
		}

		/// <summary>
		/// Стартова позиция
		/// </summary>
		public int Start
		{
			get
			{
				return this.start;
			}
		}

		/// <summary>
		/// Дължина
		/// </summary>
		public int Length
		{
			get
			{
				return this.length;
			}
		}

		/// <summary>
		/// Фреймове за секунда
		/// </summary>
		public float FrameRate
		{
			get
			{
				return rate;
			}
		}

		/// <summary>
		/// Кодек
		/// </summary>
		public string Codec
		{
			get
			{
				return codec;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор
		/// </summary>
		public AviReader()
        {
            Win32.AVIFileInit();
        }

		#endregion

		#region Destructors

		/// <summary>
		/// Деструктор
		/// </summary>
		~AviReader( )
        {
            this.Dispose(false);
        }

		#endregion

		#region Dispose

		/// <summary>
		/// Унищожаване
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			// remove me from the Finalization queue 
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Унищожаване
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose managed resources
			}
			// close current AVI file if any opened and uninitialize AVI library
			this.Close();
			Win32.AVIFileExit();
		}

		#endregion

		#region Open

		/// <summary>
		/// Отваряне на файл
		/// </summary>
		/// <param name="fileName"></param>
		public void Open(string filename)
		{
			// close previous file
			this.Close();

			bool success = false;

			try
			{
				lock (sync)
				{
					// open AVI file
					if (Win32.AVIFileOpen(out file, filename, Win32.OpenFileMode.ShareDenyWrite, IntPtr.Zero) != 0)
						throw new System.IO.IOException("Failed opening the specified AVI file.");

					// get first video stream
					if (Win32.AVIFileGetStream(file, out stream, Win32.mmioFOURCC("vids"), 0) != 0)
						throw new Exception("Failed getting video stream.");

					// get stream info
					Win32.AVISTREAMINFO info = new Win32.AVISTREAMINFO();
					Win32.AVIStreamInfo(stream, ref info, Marshal.SizeOf(info));

					width = info.rectFrame.right;
					height = info.rectFrame.bottom;
					position = info.start;
					start = info.start;
					length = info.length;
					rate = (float)info.rate / (float)info.scale;
					codec = Win32.decode_mmioFOURCC(info.handler);

					// prepare decompressor
					Win32.BITMAPINFOHEADER bitmapInfoHeader = new Win32.BITMAPINFOHEADER();

					bitmapInfoHeader.size = Marshal.SizeOf(bitmapInfoHeader.GetType());
					bitmapInfoHeader.width = width;
					bitmapInfoHeader.height = height;
					bitmapInfoHeader.planes = 1;
					bitmapInfoHeader.bitCount = 24;
					bitmapInfoHeader.compression = 0; // BI_RGB

					// get frame object
					if ((frame = Win32.AVIStreamGetFrameOpen(stream, ref bitmapInfoHeader)) == IntPtr.Zero)
					{
						bitmapInfoHeader.height = -height;

						if ((frame = Win32.AVIStreamGetFrameOpen(stream, ref bitmapInfoHeader)) == IntPtr.Zero)
							throw new Exception("Failed initializing decompressor.");
					}

					success = true;
				}
			}
			finally
			{
				if (!success)
				{
					this.Close();
				}
			}
		}

		#endregion

		#region Close

		/// <summary>
		/// Затваряне
		/// </summary>
		public void Close()
		{
			lock (sync)
			{
				// release get frame object
				if (frame != IntPtr.Zero)
				{
					Win32.AVIStreamGetFrameClose(frame);
					frame = IntPtr.Zero;
				}

				// release stream
				if (stream != IntPtr.Zero)
				{
					Win32.AVIStreamRelease(stream);
					stream = IntPtr.Zero;
				}

				// release file
				if (file != IntPtr.Zero)
				{
					Win32.AVIFileRelease(file);
					file = IntPtr.Zero;
				}
			}
		}

		#endregion

		#region Get Next Frame

		/// <summary>
		/// Вземане на следващия фрейм
		/// </summary>
		/// <returns></returns>
		public Bitmap GetNextFrame()
		{
			lock (sync)
			{
				if (file == IntPtr.Zero)
				{
					throw new System.IO.IOException("Cannot read video frames since video file is not open.");
				}

				// get frame at specified position
				IntPtr DIB = Win32.AVIStreamGetFrame(frame, position);

				if (DIB == IntPtr.Zero)
					throw new Exception("Failed getting frame.");

				Win32.BITMAPINFOHEADER bitmapInfoHeader;

				// copy BITMAPINFOHEADER from unmanaged memory
				bitmapInfoHeader = (Win32.BITMAPINFOHEADER)Marshal.PtrToStructure(DIB, typeof(Win32.BITMAPINFOHEADER));

				// create new bitmap
				Bitmap image = new Bitmap(width, height, PixelFormat.Format24bppRgb);

				// lock bitmap data
				BitmapData imageData = image.LockBits(
					new Rectangle(0, 0, width, height),
					ImageLockMode.ReadWrite,
					PixelFormat.Format24bppRgb);

				// copy image data
				int srcStride = imageData.Stride;
				int dstStride = imageData.Stride;

				// check image direction
				if (bitmapInfoHeader.height > 0)
				{
					// it`s a bottom-top image
					int dst = imageData.Scan0.ToInt32() + dstStride * (height - 1);
					int src = DIB.ToInt32() + Marshal.SizeOf(typeof(Win32.BITMAPINFOHEADER));

					for (int y = 0; y < height; y++)
					{
						Win32.memcpy(dst, src, srcStride);
						dst -= dstStride;
						src += srcStride;
					}
				}
				else
				{
					// it`s a top bootom image
					int dst = imageData.Scan0.ToInt32();
					int src = DIB.ToInt32() + Marshal.SizeOf(typeof(Win32.BITMAPINFOHEADER));

					// copy the whole image
					Win32.memcpy(dst, src, srcStride * height);
				}

				// unlock bitmap data
				image.UnlockBits(imageData);

				// move position to the next frame
				position++;

				return image;
			}
		}

		#endregion

	}
}
