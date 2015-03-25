using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;// use mysql
using System.Data; // to use connection state

namespace AirlineService
{
    public class DatabaseConnector
    {

        public MySqlConnection mySqlConnection;//declare variable for connection
        public MySqlCommand mySqlCommand;

        public DataView myview;

        public MySqlDataReader dataReader;

        public DataSet dataSetMain; //assign as public for seats
        public DataRow dataRowMain;

        public MySqlParameter parameter;


        private const string Server = "localhost";
        private const string Database = "airline_db";
        private const string UserID = "root";





        //if u use the below non parameterised constructor you have to use one that takes 3 parameters

        public DatabaseConnector()
            : this(Server, UserID, Database)  //Constructor
        {
            //if no parameters are given use the private ones in this class and send to parameterized constructor
        }

        public DatabaseConnector(string server, string userID, string database) //overloaded parameterised constructor
        {

            mySqlConnection = CreateConnection(server, userID, database); //check
        }

        //Method to create the connection and return it
        private MySqlConnection CreateConnection(string server, string userID, string database)
        {
            var connectionString = String.Format("server={0};User Id={1};database={2}", server, userID, database);
            return new MySqlConnection(connectionString);
        }


        public void OpenConnection() //to open connection to database
        {
            try
            {
                if (mySqlConnection != null && mySqlConnection.State == ConnectionState.Closed)//to check if conn is already open or not
                {
                    mySqlConnection.Open();
                }
            }
            catch (MySqlException ex)
            {//if database exception is found(no database) pop up a message box 
                System.Windows.Forms.MessageBox.Show("Make sure you are connected to the database before starting this application \r\nError: " + ex.Message, "Database Connection Failed", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                //exit the program
                System.Environment.Exit(1);
            }
            catch (Exception ex1)
            {
                System.Windows.Forms.MessageBox.Show("Make sure you are connected to the database before starting this application \r\nError: " + ex1.Message, "Database Connection Failed", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                //exit the program
                System.Environment.Exit(1);
            }




        }

        public void CloseConnection() //to close connection to database
        {
            if (mySqlConnection != null && mySqlConnection.State == ConnectionState.Open)
            {
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }

        }

        public MySqlCommand InitSqlCommand(string query)
        {
            mySqlCommand = new MySqlCommand(query, mySqlConnection);//check this line
            return mySqlCommand;
        }

        //to get from the database
        public DataTable GetData(string query)
        {
            var dataTable = new DataTable();
            var dataSet = new DataSet();
            var dataAdapter = new MySqlDataAdapter { SelectCommand = InitSqlCommand(query) };
            // var dataView = new DataView();

            dataAdapter.Fill(dataSet);
            dataSetMain = dataSet;
            dataTable = dataSet.Tables[0];      //all tables assignted as table[0]
            return dataTable;
        }

    }
}
