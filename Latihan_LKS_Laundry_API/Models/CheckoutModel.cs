using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Latihan_LKS_Laundry_API.Models
{
    public class CheckoutModel
    {
        public int id_employee { set; get; }
        public int id_customer { set; get; }
        public int id_package { set; get; }
    }
}