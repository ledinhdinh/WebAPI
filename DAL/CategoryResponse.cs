using Common.DAL;
using DAL.Models;
using System.Linq;

namespace DAL
{
	// Kế thừa từ tầng Common.
	public class CategoryResponse : GenericResponse<NorthwindContext, Category>
	{
		public CategoryResponse() { }
		public override Category Read(int id)
		{
			// Trả về phần tử đầu tiên.
			var res = All.FirstOrDefault(x => x.CategoryId == id);
			return res;
		}
	}
}
