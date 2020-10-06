using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            try
            {
                //instanciamos el objeto lista a retornar
                List<Usuario> usuarios = new List<Usuario>();

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                while (drUsuarios.Read())
                {
                    //creamos un objeto Usuario para copiar los datos obtenidos
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDTipoPersona = (int)drUsuarios["id_tipo_usuario"];
                    if (drUsuarios["direccion"] != null)
                        usr.Direccion = (string)(drUsuarios["direccion"]);
                    usr.FechaNacimiento = drUsuarios.GetDateTime(13);
                    if (!drUsuarios.IsDBNull(10))
                        usr.IDPlan = (int)drUsuarios["id_plan"];
                    if (!drUsuarios.IsDBNull(11))
                        usr.Telefono = (string)drUsuarios["telefono"];
                    if (!drUsuarios.IsDBNull(12))
                        usr.Legajo = (int)drUsuarios["legajo"];

                    //agregamos el objeto con datos a la lista que devolvemos
                    usuarios.Add(usr);
                }
                //cerramos el DataReader y la conexion la BD
                drUsuarios.Close();
                this.CloseConnection();
                return usuarios;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public DataTable GetUsuarios()
        {
            try
            {

                //abrimos la conexion
                this.OpenConnection();

                //creamos un objeto SqlCommand que sera la sentencia SQL a ejecutar
                SqlCommand cmdUsuarios = new SqlCommand("select id_usuario, nombre, apellido, direccion, email, ISNULL(telefono,'-') as telefono, clave, " +
                "fecha_nacimiento, ISNULL(legajo,0) as legajo, descripcion, u.id_tipo_usuario, ISNULL(u.id_plan,0) as id_plan, ISNULL(desc_plan,'-') as desc_plan, nombre_usuario, habilitado, ISNULL(desc_especialidad,'-') as desc_especialidad " +
                "from usuarios u inner join tipos_usuario tu on u.id_tipo_usuario = tu.id_tipo_usuario " +
                "left join planes p on u.id_plan = p.id_plan " +
                "left join especialidades e on e.id_especialidad = p.id_especialidad", sqlConn);
                //CHEQUEAR QUE TODAS LAS RELACIONES ESTEN BIEN Y QUE NO DEN ERROR A LA HORA DE LISTARLOS// OK

                //instanciamos un objeto DataReader que sera quien recupere los datos de la BD
                //ES IGUAL A UN RESULTSET

                //SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                /*Read() lee una fila de las devueltas por el comando sql, carga los datos en 
                 *drUsuarios para poder accederlos, devuelve true si pudo leer los datos y avanza
                 *a la fila siguiente. ES IGUAL AL rs.Next() de java
                 */
                //if (drUsuarios.HasRows)
                //{
                    //while (drUsuarios.Read())
                    //{
                    //    //creamos un objeto Usuario para copiar los datos obtenidos
                    //    Usuario usr = new Usuario();
                    //    usr.ID = (int)drUsuarios["id_usuario"];
                    //    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    //    //usr.Clave = (string)drUsuarios["clave"];
                    //    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    //    usr.Nombre = (string)drUsuarios["nombre"];
                    //    usr.Apellido = (string)drUsuarios["apellido"];
                    //    usr.Email = (string)drUsuarios["email"];
                    //    usr.IDTipoPersona = (int)drUsuarios["id_tipo_usuario"];
                    //    if (drUsuarios["direccion"] != null)
                    //        usr.Direccion = (string)(drUsuarios["direccion"]);
                    //    usr.FechaNacimiento = drUsuarios.GetDateTime(7);
                    //    //if (drUsuarios["id_plan"] != null)
                    //    //    usr.IDPlan = (int)drUsuarios["id_plan"];
                    //    //if (drUsuarios["telefono"] != null)
                    //    //    usr.Telefono = (string)drUsuarios["telefono"];
                    //    //if (drUsuarios["legajo"] != null)
                    //    //    usr.Legajo = (int)drUsuarios["legajo"];

                    //    if (!drUsuarios.IsDBNull(11))
                    //        usr.IDPlan = (int)drUsuarios["id_plan"];
                    //    if (!drUsuarios.IsDBNull(15))
                    //        usr.Telefono = (string)drUsuarios["telefono"];
                    //    if (!drUsuarios.IsDBNull(16))
                    //        usr.Legajo = (int)drUsuarios["legajo"];
                    //    //agregamos el objeto con datos a la lista que devolvemos
                    //    // usuarios.Add(usr);
                    //}

                    SqlDataAdapter daUsuarios = new SqlDataAdapter(cmdUsuarios);
                    SqlCommandBuilder cbUsuarios = new SqlCommandBuilder(daUsuarios);
                    DataTable dtUsuarios = new DataTable();
                    daUsuarios.Fill(dtUsuarios);

                    //drUsuarios.Close();
                    this.CloseConnection();

                    return dtUsuarios;
                //}
                //else
                //{
                //    Console.WriteLine("No rows found.");
                //}
                //cerramos el DataReader y la conexion la BD

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDTipoPersona = (int)drUsuarios["id_tipo_usuario"];
                    if (drUsuarios["direccion"] != null)
                        usr.Direccion = (string)(drUsuarios["direccion"]);
                    usr.FechaNacimiento = drUsuarios.GetDateTime(13);
                    if (!drUsuarios.IsDBNull(10))
                        usr.IDPlan = (int)drUsuarios["id_plan"];
                    if (!drUsuarios.IsDBNull(11))
                        usr.Telefono = (string)drUsuarios["telefono"];
                    if (!drUsuarios.IsDBNull(12))
                        usr.Legajo = (int)drUsuarios["legajo"];
                }
                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al recuperar usuario", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("error al eliminar usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email, id_tipo_usuario = @idTipoPersona, " +
                    "direccion = @direccion, fecha_nacimiento = @fecha_nac, id_plan =@idPlan, telefono = @telefono, legajo = @legajo " +
                    "WHERE id_usuario = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@idTipoPersona", SqlDbType.Int).Value = usuario.IDTipoPersona;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = usuario.Direccion;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = usuario.FechaNacimiento;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = usuario.IDPlan;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = usuario.Telefono;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = usuario.Legajo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into usuarios (nombre_usuario,clave,habilitado,nombre,apellido,email,id_tipo_usuario,direccion,fecha_nacimiento,id_plan,telefono,legajo) " +
                    "values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,@idTipoPersona,@direccion,@fecha_nac,@idPlan,@telefono,@legajo) " +
                    "select @@identity", //esta linea recupera el id que asigno sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@idTipoPersona", SqlDbType.Int).Value = usuario.IDTipoPersona;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = usuario.Direccion;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = usuario.FechaNacimiento;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = usuario.IDPlan;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = usuario.Telefono;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = usuario.Legajo;

                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno la BD
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
        public Usuario GetOneByNombreUsuario(string nombre_usuario)
        {

            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario=@nombre_usuario", sqlConn);
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = nombre_usuario;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDTipoPersona = (int)drUsuarios["id_tipo_usuario"];
                    if (drUsuarios["direccion"] != null)
                        usr.Direccion = (string)(drUsuarios["direccion"]);
                    usr.FechaNacimiento = drUsuarios.GetDateTime(13);
                    if (!drUsuarios.IsDBNull(10))
                        usr.IDPlan = (int)drUsuarios["id_plan"];
                    if (!drUsuarios.IsDBNull(11))
                        usr.Telefono = (string)drUsuarios["telefono"];
                    if (!drUsuarios.IsDBNull(12))
                        usr.Legajo = (int)drUsuarios["legajo"];

                }
                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("No existe nombre de usuario", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public Usuario GetOneByEmail(string email)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where email = @email", sqlConn);
                cmdUsuarios.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDTipoPersona = (int)drUsuarios["id_tipo_usuario"];
                    if (drUsuarios["direccion"] != null)
                        usr.Direccion = (string)(drUsuarios["direccion"]);
                    usr.FechaNacimiento = drUsuarios.GetDateTime(13);
                    if (!drUsuarios.IsDBNull(10))
                        usr.IDPlan = (int)drUsuarios["id_plan"];
                    if (!drUsuarios.IsDBNull(11))
                        usr.Telefono = (string)drUsuarios["telefono"];
                    if (!drUsuarios.IsDBNull(12))
                        usr.Legajo = (int)drUsuarios["legajo"];

                }
                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("No existe el email", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
    }
}



