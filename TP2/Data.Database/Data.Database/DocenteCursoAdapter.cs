using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class DocenteCursoAdapter:Adapter
    {
        public DocenteCurso GetOne(int id)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos where id_dictado = @id", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Cargo = (DocenteCurso.TipoCargo)((int)drDocenteCurso["cargo"]);
                }
                drDocenteCurso.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar dictado", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;

        }

        public List<DocenteCurso> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                List<DocenteCurso> dictados = new List<DocenteCurso>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdDictados = new SqlCommand("select * from docentes_cursos", sqlConn);
                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drDictados = cmdDictados.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drDictados.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDictados["id_dictado"];
                    dc.IDDocente = (int)drDictados["id_docente"];
                    dc.IDCurso = (int)drDictados["id_curso"];
                    dc.Cargo = (DocenteCurso.TipoCargo)Enum.Parse(typeof(DocenteCurso.TipoCargo), (drDictados["cargo"]).ToString());

                    //agregamos el objeto con datos a la lista que devolvemos
                    dictados.Add(dc);
                }
                //cerramos el DataReader y la conexion la BD
                drDictados.Close();
                this.CloseConnection();
                return dictados;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista dictados", Ex);
                throw ExcepcionManejada;
            }
        }

        public DocenteCurso GetOne(int id_docente, int id_curso, DocenteCurso.TipoCargo cargo)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos where id_docente = @idDocente and id_curso = @idCurso and cargo = @cargo", sqlConn);
                cmdDocenteCurso.Parameters.Add("@idDocente", SqlDbType.Int).Value = id_docente;
                cmdDocenteCurso.Parameters.Add("@idCurso", SqlDbType.Int).Value = id_curso;
                cmdDocenteCurso.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)cargo;

                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    dc.ID = (int)drDocenteCurso["id_dictado"];
                    dc.IDCurso = (int)drDocenteCurso["id_curso"];
                    dc.IDDocente = (int)drDocenteCurso["id_docente"];
                    dc.Cargo = (DocenteCurso.TipoCargo)((int)drDocenteCurso["cargo"]);
                }
                else
                    dc = null;

                drDocenteCurso.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar dictado", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }

        public DataTable GetDocentesCurso(int id_curso)
        {
            try
            {

                this.OpenConnection();

                SqlCommand cmdDocentesCurso = new SqlCommand("select c.id_curso,u.id_usuario, u.legajo, u.apellido, u.nombre, dc.id_dictado, dc.cargo, m.desc_materia " +
                    "from usuarios u " +
                    "inner join docentes_cursos dc on u.id_usuario = dc.id_docente " +
                    "inner join cursos c on c.id_curso = dc.id_curso " +
                    "inner join materias m on m.id_materia = c.id_materia " +
                    "where dc.id_curso = @idCurso", sqlConn);

                cmdDocentesCurso.Parameters.Add("@idCurso", SqlDbType.Int).Value = id_curso;

                SqlDataAdapter daDocentesCurso = new SqlDataAdapter(cmdDocentesCurso);
                SqlCommandBuilder cbDocentesCurso = new SqlCommandBuilder(daDocentesCurso);
                DataTable dtDocentesCurso = new DataTable();
                daDocentesCurso.Fill(dtDocentesCurso);


                this.CloseConnection();
                return dtDocentesCurso;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de docentes de curso: " + id_curso, Ex);
                throw ExcepcionManejada;
            }
        }
        public DataTable GetCursosDocente(int id_docente)
        {
            try
            {

                this.OpenConnection();

                SqlCommand cmdCursosDocente = new SqlCommand("select u.id_usuario, dc.id_docente, u.legajo, c.id_curso, u.apellido, u.nombre, dc.id_dictado, dc.cargo, m.desc_materia from usuarios u inner join docentes_cursos dc on " +
                "u.id_usuario = dc.id_docente inner join cursos c on c.id_curso = dc.id_curso inner join materias m on m.id_materia = c.id_materia where dc.id_docente = @id", sqlConn);

                cmdCursosDocente.Parameters.Add("@id", SqlDbType.Int).Value = id_docente;

                SqlDataAdapter daCursosDocente = new SqlDataAdapter(cmdCursosDocente);
                SqlCommandBuilder cbCursosDocente = new SqlCommandBuilder(daCursosDocente);
                DataTable dtCursosDocente = new DataTable();
                daCursosDocente.Fill(dtCursosDocente);


                this.CloseConnection();
                return dtCursosDocente;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos del docente: " + id_docente, Ex);
                throw ExcepcionManejada;
            }
        }
        public DataTable GetAlumnosCurso(int id_curso)
        {
            try
            {

                this.OpenConnection();

                SqlCommand cmdAlmunosCurso = new SqlCommand("select ai.id_inscripcion,ai.condicion, ai.nota, u.legajo, u.apellido, u.nombre from usuarios u inner join alumnos_inscripciones ai on " +
                "u.id_usuario = ai.id_alumno where ai.id_curso = @id", sqlConn);

                cmdAlmunosCurso.Parameters.Add("@id", SqlDbType.Int).Value = id_curso;

                SqlDataAdapter daAlumnosCurso = new SqlDataAdapter(cmdAlmunosCurso);
                SqlCommandBuilder cbAlumnosCurso = new SqlCommandBuilder(daAlumnosCurso);
                DataTable dtAlumnosCurso = new DataTable();
                daAlumnosCurso.Fill(dtAlumnosCurso);


                this.CloseConnection();
                return dtAlumnosCurso;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de alumnos del curso: ", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdAddDocenteCurso = new SqlCommand(
                    "insert into docentes_cursos (id_curso, id_docente, cargo)" +
                    "values(@idCurso,@idDocente,@Cargo)" +
                    "select @@identity", //esta linea recupera el id que asigno sql automaticamente
                    sqlConn);

                cmdAddDocenteCurso.Parameters.Add("@idCurso", SqlDbType.Int).Value = dc.IDCurso;
                cmdAddDocenteCurso.Parameters.Add("@idDocente", SqlDbType.Int).Value = dc.IDDocente;
                cmdAddDocenteCurso.Parameters.Add("@Cargo", SqlDbType.Int).Value = (int)dc.Cargo;
                dc.ID = Decimal.ToInt32((decimal)cmdAddDocenteCurso.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear dictado", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE docentes_cursos SET id_curso = @idCurso, id_docente = @idDocente, cargo = @cargo " +
                    "WHERE id_dictado = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = dc.IDCurso;
                cmdSave.Parameters.Add("@idDocente", SqlDbType.Int).Value = dc.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dc.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }
    }
}
