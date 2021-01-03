using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public static class ExtendingMethods
    {
        private static ProductionDataContext context = new ProductionDataContext();

        public static List<Product> GetProductsWithoutCategoryQ(this List<Product> products)
        {
            IEnumerable<Product> productsWithoutCategory =
                from product in products where product.ProductSubcategory == null select product;
            return productsWithoutCategory.ToList();
        }

        public static List<Product> GetProductWithoutCategoryM(this List<Product> products)
        {
            IEnumerable<Product> productsWithoutCategory =
                products.Where(product => product.ProductSubcategory == null);
            return productsWithoutCategory.ToList();
        }

        public static List<Product> GetProductsAsPageWithSize(this List<Product> products, int count, int pgNumber)
        {
            List<Product> productsPage = products.Skip((pgNumber - 1) * count).Take(count).ToList();
            return productsPage;
        }

        public static string GetProductsWithVendorNameQ(this List<Product> products)
        {
            var productWithVendor = from product in products 
                                    from productVendor in context.ProductVendor 
                                    where productVendor.ProductID == product.ProductID 
                                    select new { ProductName = productVendor.Product.Name,
                                        VendorName = productVendor.Vendor.Name };
            IEnumerable<string> lines = productWithVendor.Select(prod => prod.ProductName + " - " + prod.VendorName);
            return String.Join("\n", lines.ToArray());
        }
    }
}
