using Entity;

namespace Presentacion.Models
{
    public class UsuarioViewModel:UsuarioInputModel
    {
        public UsuarioViewModel(Usuario usuario){
            Identificacion = usuario.Identificacion;
            PrimerNombre = usuario.PrimerNombre;
            SegundoNombre = usuario.SegundoNombre;
            PrimerApellido = usuario.PrimerApellido;
            SegundoApellido = usuario.SegundoApellido;
            Telefono = usuario.Telefono;
            CorreoElectronico = usuario.CorreoElectronico;
            Clave = usuario.Clave;
        }
    }
}