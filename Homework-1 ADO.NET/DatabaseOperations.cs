using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDataBase
{
    public class DatabaseOperations
    {
        //computer "DESKTOP-K00EKIT\\SQLEXPRESS";
        //DESKTOP-K00EKIT\SQLEXPRESS
        // string connectionName = "master";

        private SqlConnection connection = new SqlConnection(
          @"Server=DESKTOP-K00EKIT\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");

        public void CreateDataBase()
        {
            string CheckForDB = ("SELECT database_id FROM sys.databases WHERE Name = 'TestDatabase1'");

            connection.Open();
            SqlCommand DBcheck = new SqlCommand(CheckForDB, connection);
            object result = DBcheck.ExecuteScalar();
            connection.Close();

            if (result == null)
            {
                string CreateDB = "CREATE DATABASE TestDatabase1";
                connection.Open();
                SqlCommand cmd = new SqlCommand(CreateDB, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void CreateTables()
        {

            connection = new SqlConnection(@"Server=DESKTOP-K00EKIT\SQLEXPRESS;Database=TestDatabase1;Trusted_Connection=True;TrustServerCertificate=True;");
            connection.Open();
            string CreateTables =
                "USE TestDatabase1" +
                "\r\n" +
                "CREATE TABLE Products\r\n" +
                "(\r\nID INT PRIMARY KEY IDENTITY(1,1)," +
                "\r\nProductName VARCHAR(MAX)\r\n)" +
                "\r\n\r\nCREATE TABLE Buyers\r\n" +
                "(\r\nID INT PRIMARY KEY IDENTITY(1,1)," +
                "\r\nBuyerName VARCHAR(MAX)\r\n)\r\n" +
                "CREATE TABLE Sales\r\n" +
                "(\r\nSaleID INT PRIMARY KEY IDENTITY(1,1)," +
                "\r\nBuyerID INT FOREIGN KEY REFERENCES Buyers (ID)," +
                "\r\nProductID INT FOREIGN KEY REFERENCES Products (ID)\r\n)";


            SqlCommand Tables = new SqlCommand(CreateTables, connection);
            Tables.ExecuteNonQuery();
            connection.Close();

        }

        public void InsertBuyer()
        {
            connection = new SqlConnection(@"Server=DESKTOP-K00EKIT\SQLEXPRESS;Database=TestDatabase1;Trusted_Connection=True;TrustServerCertificate=True;");
            connection.Open();
            string insertBuyer = "INSERT INTO Buyers\r\n" +
                "VALUES('Georgi')," +
                "\r\n('Dimitar')," +
                "\r\n('veselin')";

            SqlCommand Insert = new SqlCommand(insertBuyer, connection);
            Insert.ExecuteNonQuery();
            connection.Close();

        }




        public void InsertProduct()
        {
            connection = new SqlConnection(@"Server=DESKTOP-K00EKIT\SQLEXPRESS;Database=TestDatabase1;Trusted_Connection=True;TrustServerCertificate=True;");
            connection.Open();
            string insertProduct = "INSERT INTO Products\r\n" +
                "VALUES('Картофи')," +
                "\r\n('Кока Кола')," +
                "\r\n('Вода')," +
                "\r\n('Торта')";

            SqlCommand InsertProduct = new SqlCommand(insertProduct, connection);
            InsertProduct.ExecuteNonQuery();
            connection.Close();

        }

        public void addSales()
        {
            connection = new SqlConnection(@"Server=DESKTOP-K00EKIT\SQLEXPRESS;Database=TestDatabase1;Trusted_Connection=True;TrustServerCertificate=True;");
            connection.Open();

            string insertSale = "INSERT INTO Sales\r\n" +
                "VALUES(1,1)," +
                "\r\n(1,2)," +
                "\r\n(1,2)," +
                "\r\n(1,3)," +
                "\r\n(2,4)," +
                "\r\n(2,4)," +
                "\r\n(2,3)," +
                "\r\n(3,2)," +
                "\r\n(3,1)," +
                "\r\n(3,4)";

            SqlCommand InsertSale = new SqlCommand(insertSale, connection);
            InsertSale.ExecuteNonQuery();
            connection.Close();





        }


        public void AllSalesInfo()
        {

            connection = new SqlConnection(@"Server=DESKTOP-K00EKIT\SQLEXPRESS;Database=TestDatabase1;Trusted_Connection=True;TrustServerCertificate=True;");
            connection.Open();

            string SalesI = "SELECT COUNT(s.SaleID) AS [SalesCount],p.ProductName" +
                "\r\nFROM Products AS p JOIN Sales AS s ON p.ID = s.ProductID " +
                "\r\n GROUP BY p.ProductName";


            SqlCommand sInfo = new SqlCommand(SalesI, connection);
            SqlDataReader reader = sInfo.ExecuteReader();

         

           //  StringBuilder sb = new StringBuilder();
            //  sb.AppendLine("Product name | Count");

            Console.WriteLine("Product name | Count");




            while (reader.Read())
            {

                 int count = int.Parse(reader["SalesCount"].ToString());
                string name = reader["ProductName"].ToString();

                //SalesInfo info = new SalesInfo(count, name);

                Console.WriteLine($"{name} - {count}");

           

            }
            connection.Close();

            //foreach (var items in sb.ToString())
            //{
            //    Console.WriteLine(items);

            //}


        }

    }

    //public class SalesInfo
    //{
    //    public int Count { get; set; }
    //    public string Name { get; set; }


    //    public SalesInfo(int Count, string Name)
    //    {
    //        this.Count = Count;
    //        this.Name = Name;

    //    }

    //}
}

