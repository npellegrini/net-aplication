using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Entidades;
using System.Data;

namespace Data.Database
{
    public class EspecialidadAdapter: Adapter
    {
        public List<Especialidad> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                var especialidades = new List<Especialidad>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", sqlConn);

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drEspecialidades.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    var especialidad = new Especialidad();
                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    //agregamos el objeto con datos a la lista que devolvemos
                    especialidades.Add(especialidad);
                }
                //cerramos el DataReader y la conexion la BD
                drEspecialidades.Close();
                this.CloseConnection();
                return especialidades;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de especialiades", Ex);
                throw ExcepcionManejada;
            }
        }
        public Especialidad GetOne(string descripcion)
        {
            var especialidad = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEsepecialidades = new SqlCommand("select * from especialidades where descripcion = @desc", sqlConn);
                cmdEsepecialidades.Parameters.Add("@desc", SqlDbType.VarChar).Value = descripcion;
                SqlDataReader drEspecialidades = cmdEsepecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar plan", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidad;
        }
        public Especialidad GetOne(int id)
        {
            var especialidad = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad = @id", sqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                }
                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar especialidad", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidad;
        }

        public void Delete(string descripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete especialidades where desc_especialidad = @descripcion", sqlConn);
                cmdDelete.Parameters.Add("@desc_especialidad", SqlDbType.VarChar).Value = descripcion;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE especialidades SET desc_especialidad = @desc_especialidad " +
                    "WHERE id_especialidad = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar).Value = especialidad.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into especialidades (desc_especialidad)" +
                    "values(@descripcion)" +
                    "select @@identity", //esta linea recupera el id que asigno sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.Descripcion);
            }
            else if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        } 
    }
}
