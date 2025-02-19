using L01_2022RR656_2022ZL650.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2022RR656_2022ZL650.Models;

namespace L01_2022RR656_2022ZL650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly blogDBContext _blogDBContexto;
        public usuariosController(blogDBContext blogDBContext)
        {
            _blogDBContexto = blogDBContext;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<usuarios> usuarios = (from e in _blogDBContexto.usuarios select e).ToList();
            if (usuarios.Count() == 0)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }
        [HttpPost]
        [Route("Add/usuario")]
        public IActionResult GuardarUsuario([FromBody] usuarios usuarios) 
        {
            try
            {
                _blogDBContexto.Add(usuarios);
                _blogDBContexto.SaveChanges();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] usuarios usuariosmodificar)
        {
            usuarios? UActual = (from u in _blogDBContexto.usuarios
                                where u.usuarioId == id
                                select u).FirstOrDefault();
            if (UActual == null)
            { return NotFound(); }
            UActual.rolId = usuariosmodificar.rolId;
            UActual.nombreUsuario = usuariosmodificar.nombreUsuario;
            UActual.clave = usuariosmodificar.clave;
            UActual.nombre = usuariosmodificar.nombre;
            UActual.apellido = usuariosmodificar.apellido;


            _blogDBContexto.Entry(UActual).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _blogDBContexto.SaveChanges();
            return Ok(UActual);
        }
        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult eliminar(int id)
        {
            usuarios? usuario = (from u in _blogDBContexto.usuarios
                              where u.usuarioId == id
                              select u).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }
            _blogDBContexto.usuarios.Attach(usuario);
            _blogDBContexto.usuarios.Remove
                (usuario);
            _blogDBContexto.SaveChanges
                ();
            return Ok(usuario);


        }
        [HttpGet]
        [Route("Buscar por nombre y apellido")]
        public IActionResult listar4(string nombre, string  apellido)
        {
            var p2 = nombre;
            var p1 = apellido;
            var usua = (from l in _blogDBContexto.usuarios
                       where l.nombre == p2 & l.apellido == p1
                       select l).ToList();
                      
            return Ok(usua);
        }
        [HttpGet]
        [Route("Buscar por rol")]
        public IActionResult listar4(string rol)
        {
            var p2 = rol;
            var usua = (from l in _blogDBContexto.usuarios
                        join ro in _blogDBContexto.roles
                        on l.rolId equals ro.rolId
                        where ro.rol == p2 
                        select l).ToList();

            return Ok(usua);
        }

    }
}
