using EmployeeLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeLogin.Controllers
{
    public class EmployeeController : ApiController
    {
        String connectionString = "Server=RAED_COMPUTER\\SQLEXPRESS;Database=EmployeeManagement;Trusted_Connection=True;";
        [HttpGet]
        public Employee EmployeLogin(string username, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand command = new SqlCommand("EmployeLogin", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("Username", username);
            command.Parameters.AddWithValue("Password", password);


            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(reader["Id"]);
            employee.Name = reader["Name"].ToString();
            employee.Age = Convert.ToInt32(reader["Age"]);
            employee.Salary = Convert.ToInt32(reader["Salary"]);



            reader.Close();
            con.Close();
            return employee;
            




        }
    }
}
