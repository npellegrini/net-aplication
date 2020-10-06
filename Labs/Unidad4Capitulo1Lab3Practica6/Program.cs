using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Unidad4Capitulo1Lab3Practica6
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresasa");

            dtEmpresas.Columns.Add("CustomerID", typeof(int));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));
            SqlConnection myconn = new SqlConnection();

            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();
            myadap.Fill(dtEmpresas);
            myconn.Close();

            Console.WriteLine("listado de empresas: ");
            foreach (DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idempresa = rowEmpresa["CustomerID"].ToString();
                string nameempesa = rowEmpresa["CustomerName"].ToString();
                Console.WriteLine(idempresa + "--" + nameempesa);
            }
            Console.ReadKey();

            Console.WriteLine("Escriba el CustomerID que sea modificar: ");
            string customerid = Console.ReadLine();
            DataRow[] rwempresas = dtEmpresas.Select("CustomerID='" + customerid + "'");
            if(rwempresas.Length!=1)
            {
                Console.WriteLine("CustomerID no encontrado");
                Console.ReadLine();
                return;
            }
            DataRow rowMiempresa = rwempresas[0];
            string nombreActual = rowMiempresa["CompanyName"].ToString();
            Console.WriteLine("Nombre acutal de la empresa: " + nombreActual);
            Console.WriteLine("Escriba nuevo nombre empresa: ");
            string nuevoNombre = Console.ReadLine();
            rowMiempresa.BeginEdit();
            rowMiempresa["CompanyName"] = nuevoNombre;
            rowMiempresa.EndEdit();

            SqlCommand updcommdand = new SqlCommand();
            updcommdand.Connection = myconn;
            updcommdand.CommandText = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustumerID";
            updcommdand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
            updcommdand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");

            myadap.UpdateCommand = updcommdand;
            myadap.Update(dtEmpresas);

        }
    }
}
