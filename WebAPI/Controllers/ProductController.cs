using BLL;
using Common.Request;
using Common.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private ProductService productService;
		public ProductController() { productService = new ProductService(); }

		/// <summary>
		///		Controller (ProductController) -> BLL (class ProductService) through function CreateProduct.
		/// </summary>
		/// <param name="productRequest"></param>
		/// <returns></returns>
		[HttpPost("Create-Product")]
		public IActionResult GetProductByID([FromBody] ProductRequest productRequest)
		{
			var res = new SingleResponse();
			res = productService.CreateProduct(productRequest);
			return Ok(res);
		}

		/// <summary>
		///		Controller (ProductController) -> BLL (class ProductService) qua function SearchProductRequest
		/// </summary>
		/// <param name="searchProductRequest"></param>
		/// <returns></returns>
		[HttpPost("Search-Product")]
		public IActionResult SearchProduct([FromBody] SearchProductRequest searchProductRequest)
		{
			var res = new SingleResponse();
			res.Data = productService.SearchProductRequest(searchProductRequest);
			return Ok(res);
		}
	}
}
