using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
	public class ExtendingMethods : IDisposable
	{
		private readonly ProductionDataContext context = new ProductionDataContext();

		public List<Product> GetProductsWithoutCategoryQ(List<Product> products)
		{
			IEnumerable<Product> productsWithoutCategory =
				from product in products where product.ProductSubcategory == null select product;
			return productsWithoutCategory.ToList();
		}

		public List<Product> GetProductWithoutCategoryM(List<Product> products)
		{
			IEnumerable<Product> productsWithoutCategory =
				products.Where(product => product.ProductSubcategory == null);
			return productsWithoutCategory.ToList();
		}

		public List<Product> GetProductsAsPageWithSize(List<Product> products, int count, int pgNumber)
		{
			List<Product> productsPage = products.Skip((pgNumber - 1) * count).Take(count).ToList();
			return productsPage;
		}

		public string GetProductsWithVendorNameQ(List<Product> products)
		{
			var productWithVendor = from product in products
									from productVendor in context.ProductVendor
									where productVendor.ProductID == product.ProductID
									select new
									{
										ProductName = productVendor.Product.Name,
										VendorName = productVendor.Vendor.Name
									};
			IEnumerable<string> lines = productWithVendor.Select(prod => prod.ProductName + " - " + prod.VendorName);
			return String.Join("\n", lines.ToArray());
		}

		public string GetProductsNamesWithVendorNameM(List<Product> products)
		{
			var productWithVendor = products.Join(
				context.ProductVendor,
				product => product.ProductID,
				productVendor => productVendor.ProductID,
				(product, productVendor) => new
				{
					ProductName = product.Name,
					VendorName = productVendor.Vendor.Name
				});
			IEnumerable<string> lines = productWithVendor
				.Select(p => p.ProductName + " - " + p.VendorName);
			return String.Join("\n", lines.ToArray());
		}

		public void Dispose()
		{
			if (context.DatabaseExists())
			{
				context.Dispose();
			}
		}
	}
}
