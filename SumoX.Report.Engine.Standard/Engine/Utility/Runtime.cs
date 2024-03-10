using System;

namespace SumoX.Report.Engine.Utility
{
	public class Runtime
	{
		public Runtime ()
		{
		}
		
		public static bool IsMono
		{
			get
			{
				Type t = Type.GetType("Mono.Runtime");
				if (t != null)
				{
					return true;
				}
				
				return false;
			}
		}
	}
}

