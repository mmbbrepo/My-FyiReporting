using System;

namespace SumoX.Report.Engine.Runtime.PageItems
{
	public class PageEllipse : PageItem, ICloneable
	{
		public PageEllipse()
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