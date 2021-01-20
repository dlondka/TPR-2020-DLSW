using System.Collections.Generic;

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
			MyCategory c1 = new MyCategory
			{
				Name = "Books"
			};
			MyCategory c2 = new MyCategory
			{
				Name = "Sweets"
			};

			MyVendor v1 = new MyVendor
			{
				Name = "Altenberg"
			};
			MyVendor v2 = new MyVendor
			{
				Name = "E.Wedel"
			};

			MyProduct p1 = new MyProduct
			{
				Name = "Przepis na człowieka",
				Category = c1,
				Vendor = v1
			};

			MyProduct p2 = new MyProduct
			{
				Name = "Włam się do mózgu",
				Vendor = v1,
				Category = c1
			};

			MyProduct p3 = new MyProduct
			{
				Name = "Milka",
				Vendor = v2,
				Category = c2
			};

			MyProduct p4 = new MyProduct
			{
				Name = "Piernik",
				Category = c2,
				Vendor = v2
			};

			Categories.Add(c1);
			Categories.Add(c2);
			Vendors.Add(v1);
			Vendors.Add(v2);
			Products.Add(p1);
			Products.Add(p2);
			Products.Add(p3);
			Products.Add(p4);
		}
	}
}
