using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Request
{
	public class SearchProductRequest
	{
		public string KeyWord { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
