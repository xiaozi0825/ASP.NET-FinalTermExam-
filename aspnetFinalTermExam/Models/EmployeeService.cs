using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace aspnetFinalTermExam.Models
{
    public class EmployeeService
    {
        private string GetconnectionStrings()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }
        public List<Employees> GetEmployeesName(Employees selectitem)
        {
            DataTable result = new DataTable();
            string sql = @"select EmployeeID,FirstName+LastName as LastName,Title,CONVERT(varchar(10) ,HireDate, 111 ) AS HireDate,Gender,2016-SUBSTRING(CONVERT(varchar(10) ,BirthDate, 112 ),1,4) AS BirthDate from HR.Employees where (EmployeeID LIKE @EmployeeID OR @EmployeeID = '') AND (FirstName+LastName LIKE '%'+@LastName+'%' OR @LastName = '') AND (Title LIKE @Title OR @Title = '')";

            using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@EmployeeID", selectitem.EmployeeID == null ? string.Empty : selectitem.EmployeeID));
                command.Parameters.Add(new SqlParameter("@LastName", selectitem.LastName == null ? string.Empty : selectitem.LastName));
                command.Parameters.Add(new SqlParameter("@Title", selectitem.Title == null ? string.Empty : selectitem.Title));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(result);
                conn.Close();

            }
            return this.MapEmployeeIDList(result);
        }

        private List<Employees> MapEmployeeIDList(DataTable orderData)
        {
            List<Employees> result = new List<Employees>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Employees()
                {
                    EmployeeID = row["EmployeeID"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Title = row["Title"].ToString(),
                    HireDate = row["HireDate"].ToString(),
                    Gender = row["Gender"].ToString(),
                    BirthDate = row["BirthDate"].ToString()
                });
            }
            return result;
        }
        public void DeleteEmployeeByID(string EmployeeID)
        {
            try
            {
                string sql = "Delete FROM HR.Employeess Where EmployeeID=@EmployeeID";
                using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertEmployees(Models.Employees Employees)
        {
            string sql = @"INSERT INTO HR.Employees(LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Country,Phone,ManagerID,Gender,MonthlyPayment,YearlyPayment) 
                        VALUES (@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Country,@Phone,@ManagerID,@Gender,@MonthlyPayment,@YearlyPayment)";
            
            using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@LastName", Employees.LastName));
                command.Parameters.Add(new SqlParameter("@FirstName", Employees.FirstName));
                command.Parameters.Add(new SqlParameter("@Title", Employees.Title));
                command.Parameters.Add(new SqlParameter("@TitleOfCourtesy", Employees.TitleOfCourtesy));
                command.Parameters.Add(new SqlParameter("@BirthDate", Employees.BirthDate));
                command.Parameters.Add(new SqlParameter("@HireDate", Employees.HireDate));
                command.Parameters.Add(new SqlParameter("@Address", Employees.Address));
                command.Parameters.Add(new SqlParameter("@City", Employees.City));
                command.Parameters.Add(new SqlParameter("@Country", Employees.Country));
                command.Parameters.Add(new SqlParameter("@Phone", Employees.Phone));
                command.Parameters.Add(new SqlParameter("@ManagerID", Employees.ManagerID == null ? string.Empty : Employees.ManagerID));
                command.Parameters.Add(new SqlParameter("@Gender", Employees.Gender));
                command.Parameters.Add(new SqlParameter("@MonthlyPayment", Employees.MonthlyPayment == null ? string.Empty : Employees.MonthlyPayment));
                command.Parameters.Add(new SqlParameter("@YearlyPayment", Employees.YearlyPayment == null ? string.Empty : Employees.YearlyPayment));
                command.ExecuteNonQuery();
                conn.Close();
            }
            return null;
        }

        public List<Employees> GetCountry()
        {
            DataTable result = new DataTable();
            string sql = @"select Country from HR.Employees group by Country";

            using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(result);
                conn.Close();

            }
            return this.MapCountry(result);
        }

        private List<Employees> MapCountry(DataTable orderData)
        {
            List<Employees> result = new List<Employees>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Employees()
                {
                    Country = row["Country"].ToString()
                });
            }
            return result;
        }

        public List<Employees> GetCity()
        {
            DataTable result = new DataTable();
            string sql = @"select City from HR.Employees group by City";

            using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(result);
                conn.Close();

            }
            return this.MapGetCity(result);
        }

        private List<Employees> MapGetCity(DataTable orderData)
        {
            List<Employees> result = new List<Employees>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Employees()
                {
                    City = row["City"].ToString()
                });
            }
            return result;
        }
        public List<Employees> GetGender()
        {
            DataTable result = new DataTable();
            string sql = @"select Gender from HR.Employees group by Gender";

            using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(result);
                conn.Close();

            }
            return this.MapGetGender(result);
        }

        private List<Employees> MapGetGender(DataTable orderData)
        {
            List<Employees> result = new List<Employees>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Employees()
                {
                    Gender = row["Gender"].ToString()
                });
            }
            return result;
        }

        public List<Employees> GetManagerID()
        {
            DataTable result = new DataTable();
            string sql = @"select ManagerID from HR.Employees group by ManagerID";

            using (SqlConnection conn = new SqlConnection(this.GetconnectionStrings()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
                sqlAdapter.Fill(result);
                conn.Close();

            }
            return this.MapGetManagerID(result);
        }

        private List<Employees> MapGetManagerID(DataTable orderData)
        {
            List<Employees> result = new List<Employees>();


            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Employees()
                {
                    ManagerID = row["ManagerID"].ToString()
                });
            }
            return result;
        }

    }
}