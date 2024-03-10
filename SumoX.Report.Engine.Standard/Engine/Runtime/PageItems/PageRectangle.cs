using System;

namespace SumoX.Report.Engine.Runtime.PageItems
{
	public class PageRectangle : PageItem, ICloneable
	{
		public PageRectangle()
		{
		}
		#region ICloneable Members

		new public object Clone()
		{
			return this.MemberwiseClone();
		}

		#endregion
	}
}