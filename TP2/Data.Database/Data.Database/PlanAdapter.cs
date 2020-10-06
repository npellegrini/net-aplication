using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                var planes = new List<Plan>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdPlanes = new SqlCommand("select * from planes", sqlConn);

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drPlanes.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    var plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    //agregamos el objeto con datos a la lista que devolvemos
                    planes.Add(plan);
                }
                //cerramos el DataReader y la conexion la BD
                drPlanes.Close();
                this.CloseConnection();
                return planes;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
        }

        public DataTable GetPlanes()
        {
            try
            {

                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select p.id_plan, p.desc_plan, e.desc_especialidad, e.id_especialidad " +
                "from planes p inner join especialidades e on p.id_especialidad = e.id_especialidad ", sqlConn);

                SqlDataAdapter daPlanes = new SqlDataAdapter(cmdPlanes);
                SqlCommandBuilder cbComisiones = new SqlCommandBuilder(daPlanes);
                DataTable dtPlanes = new DataTable();
                daPlanes.Fill(dtPlanes);


                this.CloseConnection();
                return dtPlanes;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Planes", Ex);
                throw ExcepcionManejada;
            }
        }

        public Plan GetOne(int id)
        {
            var plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan = @id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                }
                drPlanes.Close();
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
            return plan;
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE planes SET ID_especialidad = @id_especialidad, desc_plan = @desc_plan " +
                    "WHERE id_plan = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar).Value = plan.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into planes (id_especialidad,desc_plan)" +
                    "values(@id_especialidad,@desc_plan)" +
                    "select @@identity",
                    sqlConn);

                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.VarChar, 50).Value = plan.IDEspecialidad;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        } 
    }
}
