using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022RR656_2022ZL650.Models;

namespace L01_2022RR656_2022ZL650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class comentariosController : ControllerBase
    {


        public readonly blogDBContext _blogDBContexto;


        public comentariosController(blogDBContext blogDBContexto)
        {


            _blogDBContexto = blogDBContexto;


        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<comentarios> listadoComentarios = (from c in _blogDBContexto.comentarios select c).ToList();


            if (listadoComentarios.Count == 0)
            {
                return NotFound("No hay registros de comentarios en las base de datos");
            }

            return Ok(listadoComentarios);

        }


        [HttpPost]
        [Route("Add")]


        public IActionResult GuardarComentario([FromBody] comentarios comentario)
        {
            try
            {

                _blogDBContexto.comentarios.Add(comentario);
                _blogDBContexto.SaveChanges();
                return Ok(comentario);


            }

            catch (Exception ex)
            {


                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        [Route("actualizar/{id}")]


        public IActionResult ActualizarComentario(int id, [FromBody] comentarios comentarioModificar)
        {
            comentarios? comentarioActual = (from c in _blogDBContexto.comentarios
                                                  where c.cometarioId == id
                                                  select c).FirstOrDefault();


            if (comentarioActual == null) { return NotFound(); }

            comentarioActual.comentario = comentarioModificar.comentario;
            



            _blogDBContexto.Entry(comentarioActual).State = EntityState.Modified;
            _blogDBContexto.SaveChanges();

            return Ok(comentarioModificar);


        }


        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult eliminarComentario(int id)
        {

            comentarios? comentario = (from c in _blogDBContexto.comentarios
                                            where c.cometarioId == id
                                            select c).FirstOrDefault();


            if (comentario == null)
            {
                return NotFound();
            }


            _blogDBContexto.comentarios.Attach(comentario);
            _blogDBContexto.comentarios.Remove(comentario);
            _blogDBContexto.SaveChanges();

            return Ok(comentario);


        }



        [HttpGet]
        [Route("GetByUsuarioId/{id}")]

        public IActionResult GetByUsuarioId(int id)
        {

            var comentario = (from c in _blogDBContexto.comentarios

                                where c.usuarioId == id

                                select c).ToList();


            if (comentario == null)
            {

                return NotFound(" No hay comentario con el id del usuario:  " + id);

            }

            return Ok(comentario);

        }


    }
}
