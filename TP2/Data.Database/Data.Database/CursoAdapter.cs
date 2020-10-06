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
    public class CursoAdapter: Adapter
    {
        public int CountInscriptos(int id)
        {
            int count = 0;
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select count(*) from cursos c inner join alumnos_inscripciones i on c.id_curso = i.id_curso where c.id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = id;
                count = (int)cmdCursos.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar cantidad de inscriptos", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return count;
        }

        public DataTable GetCursosPlan(int id_plan)
        {
            int anio = DateTime.Today.Year;
            try
            {

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select cur.id_curso, com.id_comision, com.desc_comision, m.id_materia, m.desc_materia, cur.cupo from cursos cur inner join materias m on "+
                "m.id_materia = cur.id_materia inner join comisiones com on cur.id_comision = com.id_comision where com.id_plan = @idPlan and cur.anio_calendario = @anio", sqlConn);
                cmdCursos.Parameters.Add("@idPlan", SqlDbType.Int).Value = id_plan;
                cmdCursos.Parameters.Add("@anio", SqlDbType.Int).Value = anio;

                SqlDataAdapter daCurso = new SqlDataAdapter(cmdCursos);
                SqlCommandBuilder cbCurso = new SqlCommandBuilder(daCurso);
                DataTable dtCurso = new DataTable();
                daCurso.Fill(dtCurso);


                this.CloseConnection();
                return dtCurso;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }
        public DataTable GetCursosByMateria(int id_materia)
        {
            int anio = DateTime.Today.Year;
            try
            {

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select cur.id_curso, com.id_comision, com.desc_comision, m.id_materia, m.desc_materia, cur.cupo from cursos cur inner join materias m on " +
                "m.id_materia = cur.id_materia inner join comisiones com on cur.id_comision = com.id_comision where cur.id_materia = @idMateria and cur.anio_calendario = @anio", sqlConn);
                cmdCursos.Parameters.Add("@idMateria", SqlDbType.Int).Value = id_materia;
                cmdCursos.Parameters.Add("@anio", SqlDbType.Int).Value = anio;

                SqlDataAdapter daCurso = new SqlDataAdapter(cmdCursos);
                SqlCommandBuilder cbCurso = new SqlCommandBuilder(daCurso);
                DataTable dtCurso = new DataTable();
                daCurso.Fill(dtCurso);


                this.CloseConnection();
                return dtCurso;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<Curso> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                var cursos = new List<Curso>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drCursos.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    var curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.Cupo = (int)drCursos["cupo"];

                    //agregamos el objeto con datos a la lista que devolvemos
                    cursos.Add(curso);
                }
                //cerramos el DataReader y la conexion la BD
                drCursos.Close();
                this.CloseConnection();
                return cursos;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }

        public DataTable GetCursos()
        {
            try
            {

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select cur.id_curso, com.id_comision, com.desc_comision, m.id_materia, m.desc_materia, cur.cupo, cur.anio_calendario, e.desc_especialidad, "+
                "p.desc_plan from cursos cur inner join materias m on m.id_materia = cur.id_materia inner join planes p on p.id_plan = m.id_plan inner join especialidades e on e.id_especialidad = p.id_especialidad " +
                "inner join comisiones com on cur.id_comision = com.id_comision", sqlConn);
                

                SqlDataAdapter daCurso = new SqlDataAdapter(cmdCursos);
                SqlCommandBuilder cbCurso = new SqlCommandBuilder(daCurso);
                DataTable dtCurso = new DataTable();
                daCurso.Fill(dtCurso);


                this.CloseConnection();
                return dtCurso;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }

        
        public Curso GetOne(int id)
        {
            var curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso = @id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.Cupo = (int)drCursos["cupo"];
                }
                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar curso", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        public Curso GetOne(int idMateria, int idComision, int anio)
        {
            var curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_materia = @idMat and id_comision = @idCom and anio_calendario = @anio", sqlConn);
                cmdCurso.Parameters.Add("@idMat", SqlDbType.Int).Value = idMateria;
                cmdCurso.Parameters.Add("@idCom", SqlDbType.Int).Value = idComision;
                cmdCurso.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.Cupo = (int)drCursos["cupo"];
                }
                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar curso", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE cursos SET cupo = @cupo , anio_calendario = @anioCalendario, id_comision = @idcomision, id_materia = @idmateria " +
                    "WHERE id_curso = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@anioCalendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@idcomision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@idmateria", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into cursos (id_materia,id_comision,anio_calendario,cupo)" +
                    "values(@idmateria,@idcomision,@anioCalendario,@cupo)" +
                    "select @@identity", //esta linea recupera el id que asigno sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@anioCalendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@idcomision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@idmateria", SqlDbType.Int).Value = curso.IDMateria;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
