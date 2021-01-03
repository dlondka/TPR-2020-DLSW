using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03    
{
    public class MyProduct
    {
        public string Name { get; set; }
        public MyCategory Category { get; set; }
        public MyVendor Vendor { get; set; }
    }
}
