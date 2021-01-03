using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class MyDataContext
    {
        public List<MyCategory> Categories;
        public List<MyProduct> Products;
        public List<MyVendor> Vendors;

        public MyDataContext()
        {
            Categories = new List<MyCategory>();
            Products = new List<MyProduct>();
            Vendors = new List<MyVendor>();
            Fill();
        }

        private void Fill()
        {
            MyCategory c1 = new MyCategory();
            c1.Name = "Books";
            MyCategory c2 = new MyCategory();
            c2.Name = "Sweets";

            MyVendor v1 = new MyVendor();
            v1.Name = "Altenberg";
            MyVendor v2 = new MyVendor();
            v2.Name = "E.Wedel";

            MyProduct p1 = new MyProduct();
            p1.Name = "Przepis na człowieka";
            p1.Category = c1;
            p1.Vendor = v1;

            MyProduct p2 = new MyProduct();
            p2.Name = "Włam się do mózgu";
            p2.Vendor = v1;
            p2.Category = c1;

            MyProduct p3 = new MyProduct();
            p3.Name = "Milka";
            p3.Vendor = v2;
            p3.Category = c2;

            MyProduct p4 = new MyProduct();
            p4.Name = "Piernik";
            p4.Category = c2;
            p4.Vendor = v2;
        }
    }
}
