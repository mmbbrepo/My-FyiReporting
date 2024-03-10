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
	/// IdentifierKey
	/// </summary>
	public enum IdentifierKeyEnum
	{
		/// <summary>
		/// Recursive
		/// </summary>
		Recursive,
		/// <summary>
		/// Simple
		/// </summary>
		Simple	
	}

	[Serializable]
	internal class IdentifierKey : IExpr
	{
		IdentifierKeyEnum _Value;		// value of the identifier

		/// <summary>
		/// 
		/// </summary>
		public IdentifierKey(IdentifierKeyEnum v) 
		{
			_Value = v;
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Object;			
		}

		public bool IsConstant()
		{
			return false;
		}

		public IdentifierKeyEnum Value
		{
			get {return _Value;}
		}

		public IExpr ConstantOptimization()
		{	
			return this;
		}

		public object Evaluate(Runtime.Report rpt, Row row)
		{	
			return _Value;
		}

		public double EvaluateDouble(Runtime.Report rpt, Row row)
		{
			return Double.NaN;
		}
		
		public decimal EvaluateDecimal(Runtime.Report rpt, Row row)
		{
			return Decimal.MinValue;
		}

        public int EvaluateInt32(Runtime.Report rpt, Row row)
        {
            return int.MinValue;
        }

		public string EvaluateString(Runtime.Report rpt, Row row)
		{
			return null;
		}

		public DateTime EvaluateDateTime(Runtime.Report rpt, Row row)
		{
			return DateTime.MinValue;
		}

		public bool EvaluateBoolean(Runtime.Report rpt, Row row)
		{
			return false;
		}
	}
}
