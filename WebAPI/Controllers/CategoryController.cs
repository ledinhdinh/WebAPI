using BLL;
using Common.Request;
using Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		/*
		 1. Controller tiếp nhận Request từ tầng Web -> BLL (qua lớp CategorySevice).
		 */
		private CategoryService categoryService;
		public CategoryController() { categoryService = new CategoryService(); }
		[HttpPost("get-by-id")]
		public IActionResult GetCategoryByID([FromBody] SimpleRequest simpleRequest)
		{
			var res = new SingleResponse();
			res = categoryService.Read(simpleRequest.Id);
			return Ok(res);
		}
	}
}
