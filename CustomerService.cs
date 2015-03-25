using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AirlineService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in both code and config file together.
    public class CustomerService : ICustomerService
    {
        public DatabaseConnector dbcon;
        CustomerClass customer=null;
        
        //public CustomerClass customer;

        public int addDetails(CustomerClass customer)
        {

            dbcon = new DatabaseConnector();


            dbcon.OpenConnection();

            //insert into tbl_nm(db FIELDS) VALUES(variables)
            dbcon.InitSqlCommand("INSERT INTO customer(fname,lname,nic,gender,dob,address1,address2,phone,mail) VALUES(@fn,@ln,@nic,@gn,@dob,@ad1,@ad2,@phn,@em)");
            dbcon.mySqlCommand.Parameters.AddWithValue("@fn", customer.Fname);       //parameter are used instead of directly adding coz its prevent sql injection
            dbcon.mySqlCommand.Parameters.AddWithValue("@ln", customer.Lname);
            dbcon.mySqlCommand.Parameters.AddWithValue("@nic", customer.Nic);
            dbcon.mySqlCommand.Parameters.AddWithValue("@gn", customer.Gender);
            dbcon.mySqlCommand.Parameters.AddWithValue("@dob", customer.Dob);
            dbcon.mySqlCommand.Parameters.AddWithValue("@ad1", customer.Add1);
            dbcon.mySqlCommand.Parameters.AddWithValue("@ad2", customer.Add2);
            dbcon.mySqlCommand.Parameters.AddWithValue("@phn", customer.Phone);
            dbcon.mySqlCommand.Parameters.AddWithValue("@em", customer.Email);



            dbcon.mySqlCommand.ExecuteNonQuery();
            //after add return the id
            dbcon.InitSqlCommand("SELECT MAX(cid) FROM Customer;");
            int num = Convert.ToInt32(dbcon.mySqlCommand.ExecuteScalar());


            dbcon.CloseConnection();
            return num;
        }



        public CustomerClass loadCustomers()
        {
            customer = new CustomerClass();
            customer. customerCount = 0;
            dbcon = new DatabaseConnector();
            dbcon.OpenConnection();
            customer.customerCount = dbcon.GetData("SELECT * FROM customer ORDER BY cid ASC").Rows.Count;
            //customerCount = dbcon.dataSetMain.Tables[0].Rows.Count;
  
            customer.custObject = new CustomerClass[customer.customerCount]; //so now array size will depend on number of records

            for (int i = 0; i < customer.customerCount; i++)        //same as loadseat method in seatclass
            {
                customer.custObject[i] = new CustomerClass();
                dbcon.dataRowMain = dbcon.dataSetMain.Tables[0].Rows[i];
                customer.custObject[i].Cid = Convert.ToInt32(dbcon.dataRowMain[0]);
                customer.custObject[i].Fname = Convert.ToString(dbcon.dataRowMain[1]);
                customer.custObject[i].Lname = Convert.ToString(dbcon.dataRowMain[2]);
                customer.custObject[i].Nic = Convert.ToString(dbcon.dataRowMain[3]);
                customer.custObject[i].Gender = Convert.ToChar(dbcon.dataRowMain[4].ToString());
                customer.custObject[i].Dob = Convert.ToDateTime(dbcon.dataRowMain[5].ToString());
                customer.custObject[i].Add1 = Convert.ToString(dbcon.dataRowMain[6]);
                customer.custObject[i].Add2 = Convert.ToString(dbcon.dataRowMain[7]);
                customer.custObject[i].Phone = Convert.ToString(dbcon.dataRowMain[8]);
                customer.custObject[i].Email = Convert.ToString(dbcon.dataRowMain[9]);
                dbcon.CloseConnection();
                
            }
            return customer;
                
        }
    }
}
