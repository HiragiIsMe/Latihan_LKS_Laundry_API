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
    public class CustomerController : ApiController
    {
        SqlConnection conn = new SqlConnection(Connect.conn);
        List<CustomerModel> models = new List<CustomerModel>();
        public List<CustomerModel> get()
        {
            SqlCommand cmd = new SqlCommand("select * from customer", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                models.Add(new CustomerModel
                {
                    id = Convert.ToInt32(reader["id_customer"]),
                    name = reader["name_customer"].ToString(),
                    phone = reader["phone_number_customer"].ToString(),
                    address = reader["address_customer"].ToString()
                });
            }
            conn.Close();

            return models.ToList();
        }
    }
}
