using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        const string consKeyDefaultCnnString = "ConnStringLocal";
        public SqlConnection sqlConn { get; set; }

        protected void OpenConnection()
        {
            try
            {

                


                    sqlConn = new SqlConnection();
                    sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
                    sqlConn.Open();
            
     
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error de conexión a base de datos", ex);
                throw exceptionManejada;
            }
        }      
                

        protected void CloseConnection()
        {
            try {
                sqlConn.Close();
                sqlConn = null;
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al cerrar conexión con base de datos", ex);
                throw exceptionManejada;
            }
        }
    }
}
