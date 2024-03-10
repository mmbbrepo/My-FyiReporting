using System.Collections.Generic;
using System.Linq;

namespace SumoX.Report.Engine.Render.ExcelConverter
{
	internal class ExcelRow
	{
		public float YPosition { get; set; }
		public float yOffset { get; set; }
		public List<ExcelCell> Cells { get; set; }

		public ExcelRow(float yPos)
		{
			Cells = new List<ExcelCell>();
			YPosition = yPos;
			yOffset = 0;
		}

		public bool IsEmpty {
			get {
				return !Cells.Any();
			}
		}
	}
}
