using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace CustomerDemo
{
    public class CustomerSPDB
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public CustomerSPDB()
        {
            con = new SqlConnection("server=.;database=SoleraEmployees;user id=sa;pwd=sa");

        }

        public void AddCustomer(Customer c)
        {
            String instr = $"AddCustomer";
            cmd = new SqlCommand(instr, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@cname", c.CNAME));
            cmd.Parameters.Add(new SqlParameter("@gender", c.CGENDER));
            cmd.Parameters.Add(new SqlParameter("@address", c.ADDRESS));
            cmd.Parameters.Add(new SqlParameter("@mobile", c.MOBILE));

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();   // return the no of rows executed - works for insert,update, delete,create 



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }




        }
        public string UpdateCustomer(int cid, Customer c)
        {
            String instr = $"UpdateCustomer";
            cmd = new SqlCommand(instr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            string returnData="Error";

            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            cmd.Parameters.Add(new SqlParameter("@cname", c.CNAME));
            cmd.Parameters.Add(new SqlParameter("@gender", c.CGENDER));
            cmd.Parameters.Add(new SqlParameter("@address", c.ADDRESS));
            cmd.Parameters.Add(new SqlParameter("@mobile", c.MOBILE));

            //-> all above are input parameteers
            // we need to add the ouput parameter also (pls check the stoered procedure once)
            SqlParameter sp = new SqlParameter("@sts", SqlDbType.VarChar, 100);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); //-> its  an update statement
                returnData= cmd.Parameters[5].Value.ToString(); //-> for sts

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return returnData;

        }
        public string DeleteCustomer(int cid)
        {
            string cmdStr = $"DeleteCustomer";
            cmd = new SqlCommand(cmdStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            SqlParameter sp = new SqlParameter("@sts", SqlDbType.VarChar, 100);
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            string RetData = "Error";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); //-> its  an delete statement
                RetData = cmd.Parameters[1].Value.ToString();
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return RetData;


        }
        public Customer FindCustomer(int cid)
        {
            string cmdStr = $"FindCustomer";
            cmd = new SqlCommand(cmdStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            Customer customer = null;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //-> its  an select statement

                if (dr.HasRows)
                {
                    //-> pointer is on 0 pointer, so increase to 1 otherwise data wont be acccessed
                    dr.Read();
                    customer = new Customer();
                    customer.MOBILE = dr["cmobile"].ToString();
                    customer.ADDRESS = dr["caddress"].ToString();
                    customer.CGENDER = dr["cgender"].ToString();
                    customer.CNAME = dr["cname"].ToString();
                    customer.CID = int.Parse(dr["cid"].ToString());

                }

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return customer;

        }
        public List<Customer> GetCustomers()
        {

            string cmdStr = $"CustomerSummary";
            cmd = new SqlCommand(cmdStr, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd = new SqlCommand(cmdStr, con);
            Customer customer = null;
            List<Customer> customerlist = new List<Customer>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //-> its  an select statement

                while (dr.Read())
                {

                    customer = new Customer();
                    customer.MOBILE = dr["cmobile"].ToString();
                    customer.ADDRESS = dr["caddress"].ToString();
                    customer.CGENDER = dr["cgender"].ToString();
                    customer.CNAME = dr["cname"].ToString();
                    customer.CID = int.Parse(dr["cid"].ToString());
                    customerlist.Add(customer);

                }

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return customerlist;


        }
    }

}
