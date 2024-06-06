using Common.BLL;
using Common.Request;
using Common.Response;
using DAL;
using DAL.Models;
using System.Linq;

namespace BLL
{
	public class ProductService : GenericService<ProductResponse, Product>
	{
		/// <summary>
		///		BLL (class ProductService) -> DAL (class ProductResponse).
		/// </summary>
		private ProductResponse productResponse;
		public ProductService()
		{
			productResponse = new ProductResponse();
		}
		#region -- Overrides
		public override SingleResponse Read(int id)
		{
			var res = new SingleResponse();
			var product = _rep.Read(id);
			res.Data = product;
			return res;
		}
		public override SingleResponse Update(Product m)
		{
			var res = new SingleResponse();

			var m1 = m.CategoryId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductId);
			if (m1 == null)
			{
				res.SetError("EZ103", "No data.");
			}
			else
			{
				res = base.Update(m);
				res.Data = m;
			}

			return res;
		}
		#endregion
		/// <summary>
		///		Insert dữ liệu Product.
		/// </summary>
		/// <param name="productRequest"></param>
		/// <returns></returns>
		public SingleResponse CreateProduct(ProductRequest productRequest)
		{
			var res = new SingleResponse();
			Product product = new Product();
			product.ProductId = productRequest.ProductId;
			product.ProductName = productRequest.ProductName;
			product.UnitPrice = productRequest.UnitPrice;
			product.UnitsInStock = productRequest.UnitsInStock;
			res = productResponse.CreateProduct(product);
			return res;
		}

		/// <summary>
		///		Tìm sản phẩm theo phân trang.
		///		Từ BLL (class ProductService) -> DAL (class ProductResponse).
		/// </summary>
		/// <param name="searchProductRequest"></param>
		/// <returns></returns>
		public object SearchProductRequest(SearchProductRequest searchProductRequest)
		{
			// Gọi đến DAL để truy vấn dữ liệu theo phân trang.
			var products = productResponse.SearchProduct(searchProductRequest.KeyWord);
			// Phân trang.
			int pCount, totalPages, offset;
			offset = searchProductRequest.PageSize * (searchProductRequest.PageNumber - 1);
			pCount = products.Count;
			totalPages = (pCount % searchProductRequest.PageSize == 0)
				? (pCount / searchProductRequest.PageSize) : (pCount / searchProductRequest.PageSize) + 1;

			var temp = new
			{
				Data = products.Skip(offset).Take(searchProductRequest.PageSize).ToList(),
				Page = searchProductRequest.PageNumber,
				Total = searchProductRequest.PageSize
			};
			return temp;
		}
	}
}
