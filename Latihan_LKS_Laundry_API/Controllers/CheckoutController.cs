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
    public class CheckoutController : ApiController
    {
        SqlConnection conn = new SqlConnection(Connect.conn);
        
        public bool post(CheckoutModel c)
        {
            if(c != null)
            {
                SqlCommand command = new SqlCommand("select price_package, duration_package from package where id_package = '" + c.id_package + "'", conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int price = Convert.ToInt32(reader["price_package"]);
                    conn.Close();
                    SqlCommand command1 = new SqlCommand("insert into headertransaction values('" + c.id_employee + "', '" + c.id_customer + "', getdate(), getdate())", conn);
                    try
                    {
                        conn.Open();
                        command1.ExecuteNonQuery();
                        conn.Close();

                        SqlCommand command2 = new SqlCommand("select top(1) * from headertransaction order by id_header_transaction desc", conn);
                        try
                        {
                            conn.Open();
                            SqlDataReader reader1 = command2.ExecuteReader();
                            reader1.Read();
                            int id_header = Convert.ToInt32(reader1["id_header_transaction"]);
                            conn.Close();

                            SqlCommand command3 = new SqlCommand("insert into detailtransaction (id_header_transaction, id_package, price_detail_transaction, total_unit_detail_transaction) values("+ id_header +", "+ c.id_package +", "+ price +", 1)", conn);
                            try
                            {
                                conn.Open();
                                command3.ExecuteNonQuery();
                                conn.Close();

                                return true;
                            }catch (Exception ex)
                            {
                                throw;
                            }
                        }catch (Exception ex)
                        {
                            throw;
                        }
                    }catch (Exception ex)
                    {
                        throw;
                    }
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
