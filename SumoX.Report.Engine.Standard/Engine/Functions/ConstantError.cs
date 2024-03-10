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
	/// Error in expression;  don't want iexpr to be null so this is returned.
	/// </summary>
	[Serializable]
	internal class ConstantError : IExpr
	{
		string _Value;
		/// <summary>
		/// Constant - as opposed to an expression
		/// </summary>
		public ConstantError(string v) 
		{
			_Value = v;
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.String;
		}

		public bool IsConstant()
		{
			return true;
		}

		public IExpr ConstantOptimization()
		{	// already constant expression
			return this;
		}

		public object Evaluate(Runtime.Report rpt, Row row)
		{
			return _Value;
		}

		public string EvaluateString(Runtime.Report rpt, Row row)
		{
			return _Value;
		}
		
		public double EvaluateDouble(Runtime.Report rpt, Row row)
		{
			return Convert.ToDouble(_Value);
		}

        public int EvaluateInt32(Runtime.Report rpt, Row row)
        {
            return Convert.ToInt32(_Value);
        }

        public decimal EvaluateDecimal(Runtime.Report rpt, Row row)
		{
			return Convert.ToDecimal(_Value);
		}

		public DateTime EvaluateDateTime(Runtime.Report rpt, Row row)
		{
			return Convert.ToDateTime(_Value);
		}

		public bool EvaluateBoolean(Runtime.Report rpt, Row row)
		{
			return Convert.ToBoolean(_Value);
		}
	}
}