using Common.DAL;
using Common.Response;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
	public class ProductResponse : GenericResponse<NorthwindContext, Product>
	{
		#region

		/// <summary>
		///		Đọc sản phẩm.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public override Product Read(int id)
		{
			var res = All.FirstOrDefault(p => p.ProductId == id);
			return res;
		}

		/// <summary>
		///		Xóa sản phẩm.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int Remove(int id)
		{
			var m = base.All.First(i => i.ProductId == id);
			m = base.Delete(m);
			return m.ProductId;
		}
		#endregion

		#region -- Methods
		public SingleResponse CreateProduct(Product product)
		{
			var res = new SingleResponse();
			using (var context = new NorthwindContext())
			{
				using (var tran = context.Database.BeginTransaction())
				{
					try
					{
						var p = context.Products.Add(product);
						context.SaveChanges();
						tran.Commit();
					}
					catch (Exception ex)
					{
						tran.Rollback();
						res.SetError(ex.StackTrace);
					}
				}
			}
			return res;
		}
		public SingleResponse UpdateProduct(Product product)
		{
			var res = new SingleResponse();
			using (var context = new NorthwindContext())
			{
				using (var tran = context.Database.BeginTransaction())
				{
					try
					{
						var p = context.Products.Update(product);
						context.SaveChanges();
						tran.Commit();
					}
					catch (Exception ex)
					{
						tran.Rollback();
						res.SetError(ex.StackTrace);
					}
				}
			}
			return res;
		}
		public List<Product> SearchProduct(string keyWord)
		{
			return All.Where(x => x.ProductName.Contains(keyWord)).ToList();
		}

		#endregion
	}
}
