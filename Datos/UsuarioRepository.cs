using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
namespace Datos
{
    public class UsuarioRepository
    {
        private readonly SqlConnection _connection;
        public UsuarioRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar (Usuario usuario) {
            using (var comand = _connection.CreateCommand ()) {
                comand.CommandText = @"Insert Into Usuarios (Identificacion,PrimerNombre,SegundoNombre, PrimerApellido, SegundoApellido,Telefono,CorreoElectronico,Clave) 
                                        values (@Identificacion,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Telefono,@CorreoElectronico,@Clave)";
                comand.Parameters.AddWithValue ("@Identificacion", usuario.Identificacion);
                comand.Parameters.AddWithValue ("@PrimerNombre", usuario.PrimerNombre);
                comand.Parameters.AddWithValue ("@SegundoNombre", usuario.SegundoNombre);
                comand.Parameters.AddWithValue ("@PrimerApellido", usuario.PrimerApellido);
                comand.Parameters.AddWithValue ("@SegundoApellido", usuario.SegundoApellido);
                comand.Parameters.AddWithValue ("@Telefono", usuario.Telefono);
                comand.Parameters.AddWithValue ("@CorreoElectronico", usuario.CorreoElectronico);
                comand.Parameters.AddWithValue ("@Clave", usuario.Clave);
                var filas = comand.ExecuteNonQuery ();

            }
        }


        public List<Usuario> Consultar(){
            List<Usuario> usuarios = new List<Usuario>();
            SqlDataReader dataReader;

            using(var commad = _connection.CreateCommand()){
                commad.CommandText = "select * from Usuarios";
                dataReader = commad.ExecuteReader();
                if(dataReader.HasRows){
                    while(dataReader.Read()){
                        Usuario usuario = MapearUsuario(dataReader);
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        private Usuario MapearUsuario(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Usuario usuario = new Usuario();
            usuario.Identificacion = (string)dataReader["Identificacion"];
            usuario.PrimerNombre = (string)dataReader["PrimerNombre"];
            usuario.SegundoNombre = (string)dataReader["SegundoNombre"];
            usuario.PrimerApellido = (string)dataReader["PrimerApellido"];
            usuario.SegundoApellido = (string)dataReader["SegundoApellido"];
            usuario.Telefono = (string)dataReader["Telefono"];
            usuario.CorreoElectronico = (string)dataReader["CorreoElectronico"];
            usuario.Clave = (string)dataReader["Clave"];

            return usuario;

        }
    }
}
