using System;
using Datos;
using Entity;

namespace Logica
{
    public class UsuarioService
    {
        private readonly ConnectionManager _conexion;
        private readonly UsuarioRepository _repositorio;

        public UsuarioService(string cadenaDeConexion)
        {
            _conexion = new ConnectionManager(cadenaDeConexion);
            _repositorio = new UsuarioRepository(_conexion);
        }

        public GuardarUsuarioResponse Guardar(Usuario usuario)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(usuario);
                _conexion.Close();
                return new GuardarUsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new GuardarUsuarioResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
    }
}
