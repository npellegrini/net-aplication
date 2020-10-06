using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class TipoPersonaAdapter:Adapter
    {
        public List<TipoPersona> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                List<TipoPersona> tipos = new List<TipoPersona>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdTiposPersona = new SqlCommand("select * from tipos_usuario", sqlConn);

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drTiposPersona = cmdTiposPersona.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drTiposPersona.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    TipoPersona tp = new TipoPersona();
                    tp.ID = (int)drTiposPersona["id_tipo_usuario"];
                    tp.Descripcion = (string)drTiposPersona["descripcion"];
                    

                    //agregamos el objeto con datos a la lista que devolvemos
                    tipos.Add(tp);
                }
                //cerramos el DataReader y la conexion la BD
                drTiposPersona.Close();
                this.CloseConnection();
                return tipos;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de tipos de usuario", Ex);
                throw ExcepcionManejada;
            }
        }

        public TipoPersona GetOne(int id)
        {
            var tipo = new TipoPersona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdTipos = new SqlCommand("select * from tipos_usuario where id_tipo_usuario = @id", sqlConn);
                cmdTipos.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drTipos = cmdTipos.ExecuteReader();
                if (drTipos.Read())
                {
                    tipo.ID = (int)drTipos["id_tipo_usuario"];
                    tipo.Descripcion = (string)drTipos["descripcion"];
                }
                drTipos.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar tipo usuario", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return tipo;
        }
    }
}
