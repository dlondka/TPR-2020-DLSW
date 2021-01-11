using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Queries
    {
        private ProductionDataContext context = new ProductionDataContext();

        public List<Product> GetProductsByName(string namePart)
        {
            IEnumerable<Product> products = from product in context.Product
                                            where product.Name.Contains(namePart)
                                            select product;

            return new List<Product>(products.ToArray());
        }

        public List<Product> GetProductsByVendorName(string vendorName)
        {
            IEnumerable<Product> products = from productVendor in context.ProductVendor
                                            where productVendor.Vendor.Name.Equals(vendorName)
                                            select productVendor.Product;

            return new List<Product>(products.ToArray());
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            IEnumerable<string> productNames = from productVendor in context.ProductVendor
                                               where productVendor.Vendor.Name.Equals(vendorName)
                                               select productVendor.Product.Name;

            return new List<string>(productNames.ToArray());
        }

        public string GetProductVendorByProductName(string productName)
        {
            IEnumerable<string> vendor = from productVendor in context.ProductVendor
                                         where productVendor.Product.Name.Equals(productName)
                                         select productVendor.Vendor.Name;

            return vendor.First();
        }

        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            IEnumerable<Product> products = from productReview in context.ProductReview
                                            orderby productReview.ReviewDate
                                            select productReview.Product;

            return new List<Product>(products.Take(howManyReviews).Distinct().ToArray());
        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            IEnumerable<Product> products = from productReview in context.ProductReview
                                            orderby productReview.ReviewDate
                                            select productReview.Product;

            return new List<Product>(products.ToArray().Take(howManyProducts));
        }

        public List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            IEnumerable<Product> products = from product in context.Product
                                            where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                            orderby product.Name
                                            select product;

            return products.Take(n).ToList();
        }

        public int GetTotalStandardCostByCategory(ProductCategory category)
        {
            IEnumerable<decimal> costs = from product in context.Product
                                         where product.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID
                                         select product.StandardCost;

            return Decimal.ToInt32(costs.Sum());
        }

        public ProductCategory GetProductCategoryByName(string name)
        {
            IEnumerable<ProductCategory> categories = from category in context.ProductCategory
                                                      where category.Name.Equals(name)
                                                      select category;
            return categories.First();
        }

        public void closeConnection()
		{
            context.Dispose();
		}
    }
}
