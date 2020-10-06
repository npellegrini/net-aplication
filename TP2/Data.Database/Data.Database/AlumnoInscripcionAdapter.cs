using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll(int idAlumno)
        {
            try
            {
                //instanciamos el objeto lista a retornar
                List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where @idAlumno = id_alumno", sqlConn);
                cmdInscripciones.Parameters.Add("@idAlumno", SqlDbType.Int).Value = idAlumno;
                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drInscripciones.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (AlumnoInscripcion.Condiciones)Enum.Parse(typeof(AlumnoInscripcion.Condiciones), (drInscripciones["condicion"]).ToString());

                    //agregamos el objeto con datos a la lista que devolvemos
                    inscripciones.Add(ins);
                }
                //cerramos el DataReader y la conexion la BD
                drInscripciones.Close();
                this.CloseConnection();
                return inscripciones;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drInscripciones.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (AlumnoInscripcion.Condiciones)Enum.Parse(typeof(AlumnoInscripcion.Condiciones), (drInscripciones["condicion"]).ToString());

                    //agregamos el objeto con datos a la lista que devolvemos
                    inscripciones.Add(ins);
                }
                //cerramos el DataReader y la conexion la BD
                drInscripciones.Close();
                this.CloseConnection();
                return inscripciones;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
        }

        public DataTable GetInscripciones(int idAlumno)
        {
            //abrimos la conexion
            this.OpenConnection();
            try
            {
                List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();


                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdInscripciones = new SqlCommand("SELECT i.id_inscripcion, " +
                "m.desc_materia, com.desc_comision, i.condicion, i.id_curso, " +
                "i.nota FROM alumnos_inscripciones i INNER JOIN cursos cur on cur.id_curso = i.id_curso " +
                "INNER JOIN materias m on m.id_materia = cur.id_materia INNER JOIN comisiones com on com.id_comision = cur.id_comision " +
                "WHERE i.id_alumno=@idAlumno", sqlConn);
                //cmdInscripciones.Parameters.Add("@idAlumno", SqlDbType.Int).Value = 1;
                cmdInscripciones.Parameters.Add("@idAlumno", SqlDbType.Int).Value = idAlumno;

                SqlDataAdapter daInscripciones = new SqlDataAdapter(cmdInscripciones);
                //SqlDataReader drCampanas = daInscripciones.SelectCommand.ExecuteReader();
                SqlCommandBuilder cbInscripciones = new SqlCommandBuilder(daInscripciones);
                DataTable dtInscripciones = new DataTable();
                daInscripciones.Fill(dtInscripciones);


                this.CloseConnection();
                return dtInscripciones;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @idInscripcion", sqlConn);
                cmdInscripciones.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"];
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (AlumnoInscripcion.Condiciones)Enum.Parse(typeof(AlumnoInscripcion.Condiciones), (drInscripciones["condicion"]).ToString());
                    ins.Nota = (int)drInscripciones["nota"];
                }
                drInscripciones.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar inscripcion", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar inscripcion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(AlumnoInscripcion ins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET condicion = @condicion, nota = @nota " +
                    "WHERE id_inscripcion = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = ins.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.Int).Value = (int)ins.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = ins.Nota;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(AlumnoInscripcion ins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into alumnos_inscripciones (id_alumno,id_curso,condicion,nota) " +
                    "values(@idAlumno,@idCurso,@condicion,@nota) " +
                    "select @@identity", //esta linea recupera el id que asigno sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@idAlumno", SqlDbType.Int).Value = ins.IDAlumno;
                cmdSave.Parameters.Add("@idCurso", SqlDbType.Int).Value = ins.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.Int).Value = (int)ins.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = ins.Nota;
                ins.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear inscripcion de alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(AlumnoInscripcion ins)
        {
            if (ins.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ins.ID);
            }
            else if (ins.State == BusinessEntity.States.New)
            {
                this.Insert(ins);
            }
            else if (ins.State == BusinessEntity.States.Modified)
            {
                this.Update(ins);
            }
            ins.State = BusinessEntity.States.Unmodified;
        }
    }
}
