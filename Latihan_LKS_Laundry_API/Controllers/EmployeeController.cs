using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Latihan_LKS_Laundry_API.Models;
namespace Latihan_LKS_Laundry_API.Controllers
{
    public class EmployeeController : ApiController
    {
        LaundryEntities ent = new LaundryEntities();

        [HttpPost]
        public IHttpActionResult post(employee e)
        {
            if(e != null)
            {
                string sql = "select * from employee where email_employee = '" + e.email_employee + "' and password_employee = '" + Encrypt.Pass(e.password_employee) + "'";
                var employ = ent.employees.SqlQuery(sql).FirstOrDefault();
                if(employ != null)
                {
                    EmployeeModel emp = new EmployeeModel();
                    emp.Id = Convert.ToInt32(employ.id_employee);
                    emp.Name = employ.name_employee.ToString();
                    emp.Email = employ.email_employee.ToString();

                    
                    return Ok(emp);
                }

                return Ok(employ);
            }
            else
            {
                return null;
            }
        }
    }
}
