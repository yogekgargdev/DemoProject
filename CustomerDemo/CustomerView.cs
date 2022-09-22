﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.IO;
using CustomerDemo;

namespace View
{
    public class CustomerView
    {
        Customer c;
        //CustomerCollection cl;
        // CustomerDB cl;
        CustomerSPDB cl;
        CustomerStore cStore;


        public CustomerView() {
             cStore = new CustomerStore();
             //cl = new CustomerDB();
             cl=new CustomerSPDB();
            //cl = new CustomerCollection();
        }

        public int MenuChoice() {
            Console.WriteLine("1. New Customer");
            Console.WriteLine("2. Modify Customer");
            Console.WriteLine("3. Remove Customer");
            Console.WriteLine("4. Find Customer");
            Console.WriteLine("5. Customer Summary");
            Console.WriteLine("6. Exit");
            Console.Write("Please Enter Your Choice\t:\t");
            int ch = int.Parse(Console.ReadLine());
            return ch;
        }

        public void AddCustomerView() {
            int id;
            string name, gender, address, mobile;
            //id = cl.GenerateID();
            //Console.WriteLine("New Customer ID\t\t:\t{0}", id);
            Console.Write("Please Enter Customer Name\t:\t");
            name = Console.ReadLine();
            Console.Write("Please Enter Customer Gender\t:\t");
            gender = Console.ReadLine();
            Console.Write("Please Enter Customer Address\t:\t");
            address = Console.ReadLine();
            Console.Write("Please Enter Mobile Number\t:\t");
            mobile = Console.ReadLine();

            c = new Customer { 
                //CID = id,
                CNAME = name,
                CGENDER = gender,
                ADDRESS = address,
                MOBILE = mobile
            };
            cl.AddCustomer(c);
        }

        public void UpdateCustomerView() {
            int id;
            string name,gender, address, mobile;
            Console.Write("Please Enter Customer ID\t:\t");
            id = int.Parse(Console.ReadLine());
            Console.Write("Please Enter Customer Name\t:\t");
            name = Console.ReadLine();
            Console.Write("Please Enter Customer Gender\t:\t");
            gender = Console.ReadLine();
            Console.Write("Please Enter Customer Address\t:\t");
            address = Console.ReadLine();
            Console.Write("Please Enter Mobile Number\t:\t");
            mobile = Console.ReadLine();

            c = new Customer
            {
                CID = id,
                CNAME = name,
                CGENDER = gender,
                ADDRESS = address,
                MOBILE = mobile
            };
            //Console.WriteLine(cl.UpdateCustomer(id, c));
            /*
            if (cl.UpdateCustomer(id, c)) {
                Console.WriteLine("Customer Updated Sucessfully.....");
            } else {
                Console.WriteLine("Customer not found to Update.......");
            }
            */
            Console.WriteLine(cl.UpdateCustomer(id, c));
        }

        public void FindCustomerView() {
            int id;
            
            Console.Write("Please Enter Customer ID\t:\t");
            id = int.Parse(Console.ReadLine());

            c = cl.FindCustomer(id);

            if (c != null)
            {
                Console.WriteLine("Customer Record Found.............");
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine("Customer not found.......");
            }
        }

        public void DeleteCustomerView() {
            int id;
            Console.Write("Please Enter Customer ID\t:\t");
            id = int.Parse(Console.ReadLine());
            //Console.WriteLine(cl.DeleteCustomer(id));
            /*
            if (cl.DeleteCustomer(id))
            {
                Console.WriteLine("Customer Deleted Successfully...........");
            }
            else
            {
                Console.WriteLine("Customer not found to delete.......");
            }
            */
            Console.WriteLine(cl.DeleteCustomer(id));

        }

        public void CustomerSummaryView() {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("ID\tName\tGender\tAddress\tMobile");
            Console.WriteLine("-------------------------------------------------------");
            List<Customer> lcst = cl.GetCustomers();
            foreach (Customer c in lcst) {
                Console.WriteLine(c.CID+"\t"+c.CNAME+"\t"+c.CGENDER+"\t"+c.ADDRESS+"\t"+c.MOBILE);
            }
            Console.WriteLine("-------------------------------------------------------");
        }

        ~CustomerView() {
            //cStore.StoreCustomers(cl);
            cl = null;
            c = null;
        }
    }
}
