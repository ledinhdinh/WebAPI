using Common.BLL;
using Common.Response;
using DAL;
using DAL.Models;

namespace BLL
{
	// Kế thừa lớp GenericService mục BLL tầng Common. 
	public class CategoryService : GenericService<CategoryResponse, Category>
	{
		private CategoryResponse categoryResponse;
		public CategoryService()
		{
			categoryResponse = new CategoryResponse();
		}
		/*
			1. BLL (class CategoryService) send request to DAL (class CategoryResponse) through function Read.
			2. Kế thừa lại phương thức gọi hàm từ tầng Common.
		*/
		public override SingleResponse Read(int id)
		{
			var singleRes = new SingleResponse();
			singleRes.Data = _rep.Read(id);
			return singleRes;
		}
	}
}
