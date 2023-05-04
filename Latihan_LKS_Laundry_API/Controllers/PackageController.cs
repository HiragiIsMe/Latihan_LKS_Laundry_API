using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Latihan_LKS_Laundry_API.Models;
namespace Latihan_LKS_Laundry_API.Controllers
{
    public class PackageController : ApiController
    {
        SqlConnection conn = new SqlConnection(Connect.conn);
        List<PackageModel> models = new List<PackageModel>();

        public List<PackageModel> get()
        {
            SqlCommand cmd = new SqlCommand("select * from package", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                models.Add(new PackageModel
                {
                    id = Convert.ToInt32(reader["id_package"]),
                    name_package = reader["name_package"].ToString(),
                    price_package = Convert.ToInt32(reader["price_package"])
                });
            }

            conn.Close();
            return models.ToList();
        }

    }
}
