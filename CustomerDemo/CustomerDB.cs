using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace CustomerDemo
{
    public class CustomerDB
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public CustomerDB()
        {
            con = new SqlConnection("server=.;database=SoleraEmployees;user id=sa;pwd=sa");

        }

        public int GenerateID()
        {
            string cmdStr = "select max(cid) from Customer";
            cmd = new SqlCommand(cmdStr, con);
            int genId = 0;

            try
            {
                con.Open();
                object data=cmd.ExecuteScalar(); // return the firstcollumn of the first row

                if (data.ToString().Equals(""))
                {
                    genId = 1;
                }
                else
                {
                    genId = (Convert.ToInt32(data) + 1);
                }

            }
            catch(SqlException ex)
            {
                throw ex;

            }
            finally
            {
                if(con.State!=ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            return genId;

        }

        public void AddCustomer(Customer c)
        {


            string cmdStr = $"insert into Customer values({c.CID},'{c.CNAME}','{c.CGENDER}','{c.ADDRESS}','{c.MOBILE}')";
            cmd = new SqlCommand(cmdStr, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); //-> its  an insert statement
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

          

        }
        public bool UpdateCustomer(int cid, Customer c)
        {
            string cmdStr = $"update customer set cname='{c.CNAME}',cgender='{c.CGENDER}',caddress='{c.ADDRESS}',cmobile='{c.MOBILE}') where cid={cid}";
            cmd = new SqlCommand(cmdStr, con);
            bool toRet = false;
            try
            {
                con.Open();
                int rEffected=cmd.ExecuteNonQuery(); //-> its  an update statement
                if (rEffected != 0)
                {
                    toRet = true;
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

            return toRet;

        }
        public bool DeleteCustomer(int cid)
        {
            string cmdStr = $"Delete from customer where cid={cid}";
            cmd = new SqlCommand(cmdStr, con);
            bool toRet = false;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery(); //-> its  an delete statement
                int rEffected = cmd.ExecuteNonQuery(); //-> its  an delete statement
                if (rEffected != 0)
                {
                    toRet = true;
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

            return toRet;

        }
        public Customer FindCustomer(int cid)
        {
            string cmdStr = $"select * from customer where cid={cid}";
            cmd = new SqlCommand(cmdStr, con);
            Customer customer = null;
            try
            {
                con.Open();
                SqlDataReader dr= cmd.ExecuteReader();
                //-> its  an select statement

                if (dr.HasRows)
                {
                    //-> pointer is on 0 pointer, so increase to 1 otherwise data wont be acccessed
                    dr.Read();
                    customer = new Customer();
                    customer.MOBILE =dr["cmobile"].ToString();
                    customer.ADDRESS= dr["caddress"].ToString();
                    customer.CGENDER= dr["cgender"].ToString();
                    customer.CNAME= dr["cname"].ToString();
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

            string cmdStr = $"select * from customer";
            cmd = new SqlCommand(cmdStr, con);
            Customer customer = null;
            List < Customer > customerlist= new List<Customer>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //-> its  an select statement

                while(dr.Read())
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
