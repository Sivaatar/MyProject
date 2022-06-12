using System;
using System.Collections.Generic;
using System.Linq;
using CurrentProject.model;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CurrentProject.model
{
    public class Db
    {
        static string siva = @"Data Source=DESKTOP-QJJ7RI4;Initial Catalog=office;Integrated Security=True";
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(siva);

        public string EmployeeOpt(Employee emp)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("Employee_details",con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);

                com.Parameters.AddWithValue("@EmployeeEmail", emp.EmployeeEmail);

                com.Parameters.AddWithValue("@EmployeeDepartmentId", emp.EmployeeDepartmentId);
                com.Parameters.AddWithValue("@type", emp.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet EmployeeGet(Employee emp,out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Employee_details", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);

                com.Parameters.AddWithValue("@EmployeeEmail", emp.EmployeeEmail);

                com.Parameters.AddWithValue("@EmployeeDepartmentId", emp.EmployeeDepartmentId);
                com.Parameters.AddWithValue("@type", emp.type);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
              

               
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
 
            return ds;
        }
        public string DepartmentOpt(Department dpt)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("Department_details", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@DepartmentId", dpt.DepartmentId);
                com.Parameters.AddWithValue("@DepartmentName", dpt.DepartmentName);

                com.Parameters.AddWithValue("@type", dpt.type);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "Success";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }
        public DataSet DepartmentGet(Department dpt, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Department_details", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@DepartmentId", dpt.DepartmentId);
                com.Parameters.AddWithValue("@DepartmentName", dpt.DepartmentName);

                com.Parameters.AddWithValue("@type", dpt.type);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";



            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }

    }
}


