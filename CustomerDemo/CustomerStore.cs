using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace CustomerDemo
{
    public class CustomerStore
    {
        private FileStream fs = null;
        private BinaryFormatter bf = null;
        public CustomerStore()
        {
            bf = new BinaryFormatter();

        }

        public void StoreCustomers(CustomerCollection cstData)
        {
            if(File.Exists("C:\\Users\\Yogek.Garg\\Documents\\CustData.txt"))
            {
                File.Delete("C:\\Users\\Yogek.Garg\\Documents\\CustData.txt");
            }
            fs = new FileStream("C:\\Users\\Yogek.Garg\\Documents\\CustData.txt", FileMode.Create, FileAccess.ReadWrite);
            bf.Serialize(fs, cstData);
            fs.Flush();
            fs.Close();
        }
        public CustomerCollection RetrieveCustomer()
        {
            if(File.Exists("C:\\Users\\Yogek.Garg\\Documents\\CustData.txt"))
            {
                fs = new FileStream("C:\\Users\\Yogek.Garg\\Documents\\CustData.txt", FileMode.Open, FileAccess.ReadWrite);

                var toret= (CustomerCollection)bf.Deserialize(fs);
                fs.Flush();
                fs.Close();
                return toret;

            }
            else
            {
                return new CustomerCollection();

            }


        }
    }
}
