using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
namespace Datos
{
    public class UsuarioRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Usuario> Usuarios = new List<Usuario>();
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

    }
}
