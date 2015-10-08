using System;
using DevilVision.Drawing;

namespace DevilVision.Detection
{
	using Masks;

	/// <summary>
	/// Детектор за пушек
	/// </summary>
	class SmokeDetector
	{

		#region Variables

		/// <summary>
		/// Текущи блокове
		/// </summary>
		protected Blocks current_blocks;

		/// <summary>
		/// Предишни блокове
		/// </summary>
		protected Blocks previous_blocks;

		/// <summary>
		/// Текущата маска за контраста
		/// </summary>
		protected Mask current_contrast_mask;

		/// <summary>
		/// Предишната маска за контраста
		/// </summary>
		protected Mask previous_contrast_mask;

		/// <summary>
		/// Временна контрастна маска
		/// </summary>
		protected Mask temporary_contrast_mask;

		/// <summary>
		/// Маска за движенията
		/// </summary>
		protected Mask motion_mask;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор
		/// </summary>
		public SmokeDetector()
		{

		}

		#endregion

		#region Process Frame

		/// <summary>
		/// Обработка на фрейм
		/// </summary>
		/// <param name="frame">Фрейм</param>
		public void ProccessFrame(IImage frame)
		{
			/*
			//Презадаване на текущите блокове като предишни
			this.previous_blocks = this.current_blocks;
			//Презадаване на текущата маска като предишна
			this.previous_contrast_mask = this.current_contrast_mask;
			//Създаване на новите блокове
			this.current_blocks = new Blocks(frame);
			//Създаване на новата временна маска
			this.temporary_contrast_mask = new ContrastMask(this.previous_blocks);
			//Създаване на новата контрастна маска
			this.current_contrast_mask = new ContrastMask(this.previous_blocks) & new ContrastMask(this.current_blocks);

			*/
		}

		#endregion


	}
}
