using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter:Adapter
    {
        public List<Materia> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                var materias = new List<Materia>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drMaterias.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    var materia = new Materia();
                    materia.ID = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    //agregamos el objeto con datos a la lista que devolvemos
                    materias.Add(materia);
                }
                //cerramos el DataReader y la conexion la BD
                drMaterias.Close();
                this.CloseConnection();
                return materias;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
        }

        public DataTable GetMaterias()
        {
            try
            {

                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select m.id_materia, m.id_plan, m.desc_materia, m.hs_totales, m.hs_semanales, p.desc_plan, e.desc_especialidad from materias m "+
                "inner join planes p on m.id_plan = p.id_plan inner join especialidades e on e.id_especialidad = p.id_especialidad", sqlConn);

                SqlDataAdapter daMaterias = new SqlDataAdapter(cmdMaterias);
                SqlCommandBuilder cbMaterias = new SqlCommandBuilder(daMaterias);
                DataTable dtMaterias = new DataTable();
                daMaterias.Fill(dtMaterias);


                this.CloseConnection();
                return dtMaterias;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
        }

        public Materia GetOne(int id)
        {
            var materia = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia = @id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drMateria = cmdMaterias.ExecuteReader();
                if (drMateria.Read())
                {
                    materia.ID = (int)drMateria["id_materia"];
                    materia.Descripcion = (string)drMateria["desc_materia"];
                    materia.HSTotales = (int)drMateria["hs_totales"];
                    materia.HSSemanales = (int)drMateria["hs_semanales"];
                    materia.IDPlan = (int)drMateria["id_plan"];
                }
                drMateria.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar materia", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE materias SET desc_materia = @descMateria, hs_totales = @hsTotales, id_plan = @idPlan, hs_semanales = @hsSemanales " +
                    "WHERE id_materia = @id", sqlConn);
                cmdSave.Parameters.Add("@descMateria", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = materia.IDPlan;
                cmdSave.Parameters.Add("@hsTotales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@hsSemanales", SqlDbType.Int).Value = materia.HSSemanales;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        //FALTA CAMBIAR INSERT
        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into materias (desc_materia, hs_totales, hs_semanales, id_plan ) " +
                    "values(@descMateria, @hsTotales, @hsSemanales, @idPlan) " +
                    "select @@identity", //esta linea recupera el id que asigno sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@descMateria", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hsTotales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@hsSemanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = materia.IDPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
