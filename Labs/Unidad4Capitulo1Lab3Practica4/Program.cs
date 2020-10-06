using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Unidad4Capitulo1Lab3Practica4
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresasa");

            dtEmpresas.Columns.Add("CustomerID", typeof(int));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));
            SqlConnection myconn = new SqlConnection();

            myconn.ConnectionString = "Data Source= LOCALHOST;Initial Catalog = Northwind; User ID=sa; Pwd=123";
            SqlCommand mycommand = new SqlCommand();
            mycommand.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            mycommand.Connection = myconn;

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();
            SqlDataReader mydr = mycommand.ExecuteReader();
            dtEmpresas.Load(mydr);
            myconn.Close();

            Console.WriteLine("listado de empresas: ");
            foreach(DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nameempesa = rowEmpresa["CustomerName"].ToString();
                Console.WriteLine(idempresa + "--" + nameempesa);
            }
            Console.ReadKey();
        }
    }
}
