using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Runtime.Serialization; //code to connect to mssql


namespace AirlineService
{
  [DataContract(Namespace = "http://Nimaz")]
    public class CustomerClass : AbstractPerson //Inherit from Abstract Person
    {
        //variables
        private int cid;

       // public int customerCount;

       // [DataMember]
    //    public CustomerClass[] custObject;//making an array called custobject from class

       [DataMember]
        public int customerCount;
      [DataMember]
        public CustomerClass[] custObject;

      //  public DatabaseConnector dbcon;

      [DataMember]
        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }







        //methods
        //public override int addDetails()
        //{


        //    dbcon = new DatabaseConnector();


        //    dbcon.OpenConnection();

        //    //insert into tbl_nm(db FIELDS) VALUES(variables)
        //    dbcon.InitSqlCommand("INSERT INTO customer(fname,lname,nic,gender,dob,address1,address2,phone,mail) VALUES(@fn,@ln,@nic,@gn,@dob,@ad1,@ad2,@phn,@em)");
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@fn", Fname);       //parameter are used instead of directly adding coz its prevent sql injection
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@ln", Lname);
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@nic", Nic);
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@gn", Gender);
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@dob", Dob);
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@ad1", Add1);
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@ad2", Add2);
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@phn", Phone);
        //    dbcon.mySqlCommand.Parameters.AddWithValue("@em", Email);



        //    dbcon.mySqlCommand.ExecuteNonQuery();
        //    //after add return the id
        //    dbcon.InitSqlCommand("SELECT MAX(cid) FROM Customer;");
        //    int num = Convert.ToInt32(dbcon.mySqlCommand.ExecuteScalar());


        //    dbcon.CloseConnection();
        //    return num;

        //}

        public void loadCustomers()
        {//loading everything from database for load existing customers


            /*customerCount = 0;
            dbcon = new DatabaseConnector();
            dbcon.OpenConnection();
            customerCount = dbcon.GetData("SELECT * FROM customer ORDER BY cid ASC").Rows.Count;
            //customerCount = dbcon.dataSetMain.Tables[0].Rows.Count;

            custObject = new CustomerClass[customerCount]; //so now array size will depend on number of records

            for (int i = 0; i < customerCount; i++)        //same as loadseat method in seatclass
            {
                custObject[i] = new CustomerClass();
                dbcon.dataRowMain = dbcon.dataSetMain.Tables[0].Rows[i];
                custObject[i].Cid = Convert.ToInt32(dbcon.dataRowMain[0]);
                custObject[i].Fname = Convert.ToString(dbcon.dataRowMain[1]);
                custObject[i].Lname = Convert.ToString(dbcon.dataRowMain[2]);
                custObject[i].Nic = Convert.ToString(dbcon.dataRowMain[3]);
                custObject[i].Gender = Convert.ToChar(dbcon.dataRowMain[4].ToString());
                custObject[i].Dob = Convert.ToDateTime(dbcon.dataRowMain[5].ToString());
                custObject[i].Add1 = Convert.ToString(dbcon.dataRowMain[6]);
                custObject[i].Add2 = Convert.ToString(dbcon.dataRowMain[7]);
                custObject[i].Phone = Convert.ToString(dbcon.dataRowMain[8]);
                custObject[i].Email = Convert.ToString(dbcon.dataRowMain[9]);
                dbcon.CloseConnection();

            

            }*/

        }

        //public override void updateDetails(int custID)
        //{
        //    dbcon = new DatabaseConnector();
        //    Cid = custID;

        //    dbcon.OpenConnection();

        //    //insert into tbl_nm(db FIELDS) VALUES(variables)
        //    //convert date to enter format
        //    dbcon.InitSqlCommand("UPDATE customer SET fname='" + Fname + "',lname='" + Lname + "',nic='" + Nic + "',gender='" + Gender + "',dob='" + Dob.ToString("yyyy-MM-dd") + "',address1='" + Add1 + "',address2='" + Add2 + "',phone='" + Phone + "',mail='" + Email + "' WHERE cid='" + Cid + "'").ExecuteNonQuery();

        //    dbcon.CloseConnection();
        //}

        //public void deleteDetails()
        //{
        //    //code
        //}

    }
}
