using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tarea3JuanCruzCarballo.ADO;
using Tarea3JuanCruzCarballo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea3JuanCruzCarballo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<ProductoVendido> _logger;

        public UsuarioController(ILogger<ProductoVendido> logger)
        {
            _logger = logger;
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public Usuario GetUsuarioByContraseña(string nombreUsuario, string contraseña)
        {
            var usuario = UsuarioHandler.GetUsuarioByPassword(nombreUsuario, contraseña);

            return usuario == null ? new Usuario() : usuario;
        }

        [HttpGet("{nombreUsuario}")]
        public Usuario GetUsuarioByNombre(string nombreUsuario)
        {
            var usuario = UsuarioHandler.GetUsuarioByUserName(nombreUsuario);

            return usuario == null ? new Usuario() : usuario;
        }

        [HttpPost]


        [HttpPut]
        public bool PutUsuario(Usuario usuario)
        {
            return UsuarioHandler.UpdateUsuario(usuario);
        }
    }
}
