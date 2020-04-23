using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public IConfiguration Configuracion { get; }

        public UsuarioController(IConfiguration configuracion)
        {
            Configuracion = configuracion;
            string connectionString = Configuracion["ConnectionStrings:DefaultConnection"];
            _usuarioService = new UsuarioService(connectionString);
        }

        [HttpPost]
        public ActionResult<UsuarioViewModel> Post(UsuarioInputModel UsuarioInput)
        {
            Usuario usuario = MapearUsuario(UsuarioInput);
            var response = _usuarioService.Guardar(usuario);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Usuario);
        }

        private Usuario MapearUsuario(UsuarioInputModel usuarioInput)
        {
            var usuario = new Usuario
            {
                Identificacion = usuarioInput.Identificacion,
                PrimerNombre = usuarioInput.PrimerNombre,
                SegundoNombre = usuarioInput.SegundoNombre,
                PrimerApellido = usuarioInput.PrimerApellido,
                SegundoApellido = usuarioInput.SegundoApellido,
                Telefono = usuarioInput.Telefono,
                CorreoElectronico = usuarioInput.CorreoElectronico,
                Clave = usuarioInput.Clave
            };
            return usuario;
        }

        [HttpGet]
        public IEnumerable<UsuarioViewModel> Gets()
        {
            var usuarios = _usuarioService.Consultar().Usuarios.Select(p=> new UsuarioViewModel(p));
            return usuarios;
        }

    }
}