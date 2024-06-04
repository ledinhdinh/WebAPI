using Common.BLL;
using Common.Response;
using DAL;
using DAL.Models;

namespace BLL
{
	// Kế thừa lớp GenericService mục BLL tầng Common. 
	public class CategoryService : GenericService<CategoryResponse, Category>
	{
		// Khởi tạo đối tượng từ tầng DAL.
		private CategoryResponse categoryResponse;
		public CategoryService()
		{
			categoryResponse = new CategoryResponse();
		}

		public override SingleResponse Read(int id)
		{
			var singleRes = new SingleResponse();
			singleRes.Data = _rep.Read(id);
			return base.Read(id);
		}
	}
}
