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
	/// Total Pages
	/// </summary>
	[Serializable]
	internal class FunctionTotalPages : IExpr
	{
		/// <summary>
		/// Total page count; relys on PageHeader, PageFooter to set Report.TotalPages
		/// </summary>
		public FunctionTotalPages() 
		{
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		public bool IsConstant()
		{
			return false;
		}

		public IExpr ConstantOptimization()
		{	// not a constant expression
			return this;
		}

		// Evaluate is for interpretation  
		public object Evaluate(Runtime.Report rpt, Row row)
		{
            return rpt == null ? (int) 1 : (int) rpt.TotalPages;
		}
		
		public double EvaluateDouble(Runtime.Report rpt, Row row)
		{	
			return rpt == null? 1: rpt.TotalPages;
		}

        public int EvaluateInt32(Runtime.Report rpt, Row row)
        {
            return rpt == null ? 1 : rpt.TotalPages;
        }
		
		public decimal EvaluateDecimal(Runtime.Report rpt, Row row)
		{
			int result = EvaluateInt32(rpt, row);

			return Convert.ToDecimal(result);
		}

		public string EvaluateString(Runtime.Report rpt, Row row)
		{
			int result = EvaluateInt32(rpt, row);
			return result.ToString();
		}

		public DateTime EvaluateDateTime(Runtime.Report rpt, Row row)
		{
			int result = EvaluateInt32(rpt, row);
			return Convert.ToDateTime(result);
		}

		public bool EvaluateBoolean(Runtime.Report rpt, Row row)
		{
			int result = EvaluateInt32(rpt, row);
			return Convert.ToBoolean(result);
		}
		
	}
}
