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
	/// IsMissing attribute
	/// </summary>
	[Serializable]
	internal class FunctionFieldIsMissing : FunctionField
	{
		/// <summary>
		/// Determine if value of Field is available
		/// </summary>
		public FunctionFieldIsMissing(Field fld) : base(fld)
		{
		}
		public FunctionFieldIsMissing(string method) : base(method)
		{
		}

		public override TypeCode GetTypeCode()
		{
			return TypeCode.Boolean;
		}

		public override bool IsConstant()
		{
			return false;
		}

		public override IExpr ConstantOptimization()
		{	
			return this;	// not a constant
		}

		// 
		public override object Evaluate(Runtime.Report rpt, Row row)
		{
			return EvaluateBoolean(rpt, row);
		}
		
		public override double EvaluateDouble(Runtime.Report rpt, Row row)
		{
			return EvaluateBoolean(rpt, row)? 1: 0;
		}
		
		public override decimal EvaluateDecimal(Runtime.Report rpt, Row row)
		{
			return EvaluateBoolean(rpt, row)? 1m: 0m;
		}

		public override string EvaluateString(Runtime.Report rpt, Row row)
		{
			return EvaluateBoolean(rpt, row)? "True": "False";
		}

		public override DateTime EvaluateDateTime(Runtime.Report rpt, Row row)
		{
			return DateTime.MinValue;
		}

		public override bool EvaluateBoolean(Runtime.Report rpt, Row row)
		{
			object o = base.Evaluate(rpt, row);
			if(o is double)
				return double.IsNaN((double)o) ? true : false;
			else
				return o == null? true: false;
		}
	}
}
