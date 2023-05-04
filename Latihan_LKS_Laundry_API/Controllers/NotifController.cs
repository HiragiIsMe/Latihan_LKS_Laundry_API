
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
    public class NotifController : ApiController
    {
        SqlConnection conn = new SqlConnection(Connect.conn);
        List<NotifModel> models = new List<NotifModel>();
        public List<NotifModel> get()
        {
            SqlCommand cmd = new SqlCommand("select * from headertransaction join detailtransaction on headertransaction.id_header_transaction = detailtransaction.id_header_transaction join package on detailtransaction.id_package = package.id_package where complete_datetime_detail_transaction is not null order by complete_datetime_detail_transaction desc", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                models.Add(new NotifModel
                {
                    id_employee = Convert.ToInt32(reader["id_employee"]),
                    name_package = reader["name_package"].ToString(),
                    complete_datetime = reader["complete_datetime_detail_transaction"].ToString()
                });
            }
            conn.Close();
            return models.ToList();

        }
    }
}
