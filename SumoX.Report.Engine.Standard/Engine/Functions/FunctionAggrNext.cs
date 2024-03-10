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
using System.Collections.Generic;
using System.Threading;
using SumoX.Report.Engine.Definition;
using SumoX.Report.Engine.ExprParser;

namespace SumoX.Report.Engine.Functions
{
	/// <summary>
	/// Aggregate function: next
	/// </summary>
	[Serializable]
	internal class FunctionAggrNext : FunctionAggr, IExpr, ICacheData
	{
		private TypeCode _tc;		// type of result: depends on type of argument
		private string _key;
		/// <summary>
		/// Aggregate function: next returns the next value in a group
		///	Return type is same as input expression	
		/// </summary>
        public FunctionAggrNext(List<ICacheData> dataCache, IExpr e, object scp)
            : base(e, scp) 
		{
			_key = "aggrnext" + Interlocked.Increment(ref Parser.Counter).ToString();

			// Determine the result
			_tc = e.GetTypeCode();
			dataCache.Add(this);
		}

		public TypeCode GetTypeCode()
		{
			return _tc;
		}

		public object Evaluate(Runtime.Report rpt, Row row)
		{
			object v = null;
			if (row == null)
				return null;
			bool bSave=true;
			RowEnumerable re = this.GetDataScope(rpt, row, out bSave);
			if (re == null)
				return null;

			Row crow=null;
			bool bNext=false;
			foreach (Row r in re)
			{
				if (bNext)
				{
					crow = r;
					break;
				}
				if (r.RowNumber == row.RowNumber)
					bNext = true;
			}
			if (crow != null)
				v = _Expr.Evaluate(rpt, crow);
			return v;
		}

		public override bool EvaluateBoolean(Runtime.Report rpt,Row row)
		{
			object result = Evaluate(rpt, row);
			return result == null? false: Convert.ToBoolean(result);
		}
		
		public double EvaluateDouble(Runtime.Report rpt, Row row)
		{
			object result = Evaluate(rpt, row);
			return result == null? double.MinValue: Convert.ToDouble(result);
		}
		
		public decimal EvaluateDecimal(Runtime.Report rpt, Row row)
		{
			object result = Evaluate(rpt, row);
			return result == null? decimal.MinValue: Convert.ToDecimal(result);
		}

        public int EvaluateInt32(Runtime.Report rpt, Row row)
        {
            object result = Evaluate(rpt, row);
            return result == null ? int.MinValue : Convert.ToInt32(result);
        }

		public string EvaluateString(Runtime.Report rpt, Row row)
		{
			object result = Evaluate(rpt, row);
			return result == null? null: Convert.ToString(result);
		}

		public DateTime EvaluateDateTime(Runtime.Report rpt, Row row)
		{
			object result = Evaluate(rpt, row);
			return result == null? DateTime.MinValue: Convert.ToDateTime(result);
		}

		private object GetValue(Runtime.Report rpt)
		{
			return rpt.Cache.Get(_key);
		}

		private void SetValue(Runtime.Report rpt, object o)
		{
			rpt.Cache.AddReplace(_key, o);
		}

		#region ICacheData Members

		public void ClearCache(Runtime.Report rpt)
		{
			rpt.Cache.Remove(_key);
		}

		#endregion
	}
}
