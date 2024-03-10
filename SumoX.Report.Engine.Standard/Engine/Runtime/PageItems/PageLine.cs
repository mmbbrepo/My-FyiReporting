using System;

namespace SumoX.Report.Engine.Runtime.PageItems
{
	public class PageLine : PageItem, ICloneable
	{
		public PageLine()
		{
		}

		public float X2
		{
			get { return W; }
			set { W = value; }
		}

		public float Y2
		{
			get { return H; }
			set { H = value; }
		}
		#region ICloneable Members

		new public object Clone()
		{
			return this.MemberwiseClone();
		}

		#endregion
	}
}