using System.Collections.Generic;
using System.Linq;

namespace Task03
{
	public class MyMethods
	{
		private static readonly MyDataContext context = new MyDataContext();

		public static List<MyProduct> GetProductsByName(string namePart)
		{
			List<MyProduct> products = context.Products
				.Where(product => product.Name.Contains(namePart))
				.ToList();
			return products;
		}
		public static List<MyProduct> GetProductsByVendorName(string vendorName)
		{
			List<MyProduct> products = context.Products
				.Where(product => product.Vendor.Name.Equals(vendorName))
				.ToList();
			return products;
		}

		public static List<MyProduct> GetNProductsFromCategory(string categoryName, int count)
		{
			List<MyProduct> products = context.Products
				.Where(product => product.Category.Name.Equals(categoryName))
				.OrderBy(product => product.Name)
				.Take(count)
				.ToList();
			return products;
		}
	}
}
