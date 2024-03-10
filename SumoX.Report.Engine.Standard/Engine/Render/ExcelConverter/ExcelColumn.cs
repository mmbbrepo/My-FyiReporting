using System.Collections.Generic;
using System.Linq;

namespace SumoX.Report.Engine.Render.ExcelConverter
{
	internal class ExcelColumn
	{
		public float XPosition { get; set; }
		public List<ExcelCell> Cells { get; set; }

		public ExcelColumn(float xPos)
		{
			Cells = new List<ExcelCell>();
			XPosition = xPos;
		}

		public bool IsEmpty {
			get{
				return !Cells.Any();
			}
		}
	}
}
