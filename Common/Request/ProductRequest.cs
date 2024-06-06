using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Request
{
	public class ProductRequest
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal? UnitPrice { get; set; }
		public short? UnitsInStock { get; set; }
	}
}
