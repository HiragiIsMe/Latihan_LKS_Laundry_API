using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Latihan_LKS_Laundry_API.Models
{
    class Encrypt
    {
        public static string Pass(string pass)
        {
            using (SHA256Managed managed = new SHA256Managed())
            {
                byte[] encode = managed.ComputeHash(Encoding.UTF8.GetBytes(pass));
                string getPass = Convert.ToBase64String(encode);

                return getPass;
            }
        }
    }

    class Connect
    {
        public static string conn = @"Data Source=DESKTOP-HUJGH1E\SQLEXPRESS;Initial Catalog=Latian_LKS_Laundry;Integrated Security=True";
    }
}