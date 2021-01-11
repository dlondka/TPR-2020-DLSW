using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Methods
    {
        private ProductionDataContext context = new ProductionDataContext();

        public List<Product> GetProductsByName(string namePart)
        {
            List<Product> products = context.Product.Where(product => product.Name.Contains(namePart)).ToList();
            return products;
        }

        public List<Product> GetProductsByVendorName(string vendorName)
        {
            List<Product> products = context.ProductVendor
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(prodctVendor => prodctVendor.Product).ToList();
            return products;
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            List<string> productNames = context.ProductVendor
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(productVendor => productVendor.Product.Name)
                .ToList();
            return productNames;
        }

        public string GetProductVendorByProductName(string productName)
        {
            string vendor = context.ProductVendor
                .Where(productVendor => productVendor.Product.Name.Equals(productName))
                .Select(productVendor => productVendor.Vendor.Name)
                .FirstOrDefault();
            return vendor;
        }

        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            List<Product> products = context.ProductReview
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyReviews)
                .Distinct()
                .ToList();
            return products;
        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> products = context.ProductReview
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyProducts)
                .ToList();
            return products;
        }

        public List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            List<Product> products = context.Product
                .Where(product => product.ProductSubcategory.ProductCategory.Name.Equals(categoryName))
                .OrderBy(product => product.Name)
                .Take(n)
                .ToList();
            return products;
        }

        public int GetTotalStandardCostByCategory(ProductCategory category)
        {
            decimal cost = context.Product
                .Where(product => product.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID)
                .Select(product => product.StandardCost)
                .Sum();
            return Decimal.ToInt32(cost);
        }

        public ProductCategory GetProductCategoryByName(string productCategoryString)
		{
            ProductCategory productCategory = context.ProductCategory
                .Where(prodCategory => prodCategory.Name.Equals(productCategoryString))
                .FirstOrDefault();

            return productCategory;
        }

        public void CloseConnection()
		{
            if (context.DatabaseExists())
            {
                context.Dispose();
            }
        }
    }
}
