using System;
using NUnit.Framework;
using SumoX.Report.DataProviders;

namespace ReportTests
{
	public class ExampleTest
	{

		[Test()]
		public void Test1()
		{

			var conn = new XmlConnection("RdlEngineconfig.Linux.xml");
			Assert.True(conn.Database == null);

		}

	}
}

