using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Methods
    {
        private static ProductionDataContext context = new ProductionDataContext();

        public static List<Product> GetProductsByName(string namePart)
        {
            List<Product> products = context.Product.Where(product => product.Name.Contains(namePart)).ToList();
            return products;
        }
    }
}
