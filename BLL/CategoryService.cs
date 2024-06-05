using Common.BLL;
using Common.Response;
using DAL;
using DAL.Models;

namespace BLL
{
	// Kế thừa lớp GenericService mục BLL tầng Common. 
	public class CategoryService : GenericService<CategoryResponse, Category>
	{
		/*
		 1. Từ tầng BLL gửi request đến DAL (qua lớp CategoryResponse).
			- CategoryResponse sẽ truy vấn dữ liệu thông qua Model.
		 */
		private CategoryResponse categoryResponse;
		public CategoryService()
		{
			categoryResponse = new CategoryResponse();
		}

		public override SingleResponse Read(int id)
		{
			var singleRes = new SingleResponse();
			singleRes.Data = _rep.Read(id);
			return singleRes;
		}
	}
}
