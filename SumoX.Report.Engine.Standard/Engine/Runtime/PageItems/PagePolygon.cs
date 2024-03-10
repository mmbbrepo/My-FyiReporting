using System;
using System.Drawing;

namespace SumoX.Report.Engine.Runtime.PageItems
{
	public class PagePolygon : PageItem, ICloneable
	{
		PointF[] Ps;
		public PagePolygon()
		{
		}
		public PointF[] Points
		{
			get { return Ps; }
			set { Ps = value; }
		}
	}
}