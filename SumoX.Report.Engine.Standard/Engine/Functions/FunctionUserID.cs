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
	/// User ID- Report.UserID must be set by the client to be accurate in multi-user case
	/// </summary>
	[Serializable]
	internal class FunctionUserID : IExpr
	{
		/// <summary>
		/// Client user id
		/// </summary>
		public FunctionUserID() 
		{
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.String;
		}

		public bool IsConstant()
		{
			return false;
		}

		public IExpr ConstantOptimization()
		{	
			return this;
		}

		// Evaluate is for interpretation  
		public object Evaluate(Runtime.Report rpt, Row row)
		{
			return EvaluateString(rpt, row);
		}
		
		public double EvaluateDouble(Runtime.Report rpt, Row row)
		{	
			string result = EvaluateString(rpt, row);
			return Convert.ToDouble(result);		
		}
		
		public decimal EvaluateDecimal(Runtime.Report rpt, Row row)
		{
			string result = EvaluateString(rpt, row);

			return Convert.ToDecimal(result);
		}

        public int EvaluateInt32(Runtime.Report rpt, Row row)
        {
            string result = EvaluateString(rpt, row);

            return Convert.ToInt32(result);
        }
		public string EvaluateString(Runtime.Report rpt, Row row)
		{
			if (rpt == null || rpt.UserID == null)
				return Environment.UserName;
			else
				return rpt.UserID;
		}

		public DateTime EvaluateDateTime(Runtime.Report rpt, Row row)
		{
			string result = EvaluateString(rpt, row);
			return Convert.ToDateTime(result);
		}

		public bool EvaluateBoolean(Runtime.Report rpt, Row row)
		{
			return false;
		}
	}
}
