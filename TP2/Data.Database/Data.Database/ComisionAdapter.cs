using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Entidades;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data.Database
{
    public class ComisionAdapter:Adapter
    {
        public List<Comision> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                var comisiones = new List<Comision>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drComisiones.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    var comision = new Comision();
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                    //Plan plan1 = new Plan();
                    //plan1.ID = 
                    //comision.Plan = plan1
                    //agregamos el objeto con datos a la lista que devolvemos
                    comisiones.Add(comision);
                }
                //cerramos el DataReader y la conexion la BD
                drComisiones.Close();
                this.CloseConnection();
                return comisiones;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
        }

        public DataTable GetComisiones()
        {
            try
            {

                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select c.id_comision, desc_comision, anio_especialidad, "+
                "desc_plan, desc_especialidad, p.id_plan from comisiones c inner join planes p on c.id_plan = p.id_plan "+
                "inner join especialidades e on e.id_especialidad = p.id_especialidad", sqlConn);

                SqlDataAdapter daComisiones = new SqlDataAdapter(cmdComisiones);
                SqlCommandBuilder cbComisiones = new SqlCommandBuilder(daComisiones);
                DataTable dtComisiones = new DataTable();
                daComisiones.Fill(dtComisiones);


                this.CloseConnection();
                return dtComisiones;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
        }

        public Comision GetOne(int id)
        {
            var comision = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision = @idComision", sqlConn);
                cmdComisiones.Parameters.Add("@idComision", SqlDbType.Int).Value = id;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                    comision.ID = (int)drComisiones["id_comision"];
                }
                drComisiones.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar comision", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision = @idComision", sqlConn);
                cmdDelete.Parameters.Add("@idComision", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar comision", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE comisiones SET desc_comision = @descComision, anio_especialidad = @anio, id_plan = @idPlan "+
                    "WHERE id_comision = @id", sqlConn);
                cmdSave.Parameters.Add("@descComision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into comisiones (desc_comision, anio_especialidad, id_plan ) " +
                    "values(@descripcion, @anio, @idPlan) " +
                    "select @@identity", //esta linea recupera el id que asigno sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = comision.IDPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
