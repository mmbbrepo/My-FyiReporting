/* ====================================================================
   Copyright (C) 2004-2008  fyiReporting Software, LLC
   Copyright (C) 2011  Peter Gill <peter@majorsilence.com>

   This file is part of the fyiReporting RDL project.
	
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.


   For additional information, email info@fyireporting.com or visit
   the website www.fyiReporting.com.
*/


using System;
using SumoX.Report.Engine.Definition;

namespace SumoX.Report.Engine.Functions
{
	/// <summary>
	/// Aggregate function: CountRows
	/// </summary>
	[Serializable]
	internal class FunctionAggrCountRows : FunctionAggr, IExpr
	{
		/// <summary>
		/// Aggregate function: CountRows
		/// 
		///	Return type is double
		/// </summary>
		public FunctionAggrCountRows(object scp):base(null, scp) 
		{
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		// Evaluate is for interpretation
		public object Evaluate(Runtime.Report rpt, Row row)
		{
			return (object) EvaluateInt32(rpt, row);
		}
		
		public int EvaluateInt32(Runtime.Report rpt, Row row)
		{
			bool bSave=true;
			RowEnumerable re = this.GetDataScope(rpt, row, out bSave);
			if (re == null)
				return 0;

			int count = re.LastRow - re.FirstRow + 1;

			return count;
		}

        public double EvaluateDouble(Runtime.Report rpt, Row row)
        {
            int d = EvaluateInt32(rpt, row);

            return Convert.ToDouble(d);
        }
		
		public decimal EvaluateDecimal(Runtime.Report rpt, Row row)
		{
			int d = EvaluateInt32(rpt, row);

			return Convert.ToDecimal(d);
		}

		public string EvaluateString(Runtime.Report rpt, Row row)
		{
			double result = EvaluateDouble(rpt, row);
			return Convert.ToString(result);
		}

		public DateTime EvaluateDateTime(Runtime.Report rpt, Row row)
		{
			object result = Evaluate(rpt, row);
			return Convert.ToDateTime(result);
		}
	}
}
