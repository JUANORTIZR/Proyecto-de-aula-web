using System.Collections.Generic;
using Entity;

namespace Logica
{
    public class ConsultarUsuarioResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public ConsultarUsuarioResponse(List<Usuario> usuarios)
        {
            Error = false;
            Usuarios = usuarios;
        }

        public ConsultarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}