using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022RR656_2022ZL650.Models;
namespace L01_2022RR656_2022ZL650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class calificacionesController : ControllerBase
    {

        public readonly blogDBContext _blogDBContexto;



        public calificacionesController(blogDBContext blogDBContexto)
        {


            _blogDBContexto = blogDBContexto;


        }




        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<calificaciones> listadoCalificaciones = (from c in _blogDBContexto.calificaciones select c).ToList();


            if (listadoCalificaciones.Count == 0)
            {
                return NotFound("NO hay registros en las base de datos");
            }

            return Ok(listadoCalificaciones);

        }


        [HttpPost]
        [Route("Add")]


        public IActionResult GuardarCalificación([FromBody] calificaciones calificacion)
        {
            try
            {

                _blogDBContexto.calificaciones.Add(calificacion);
                _blogDBContexto.SaveChanges();
                return Ok(calificacion);


            }

            catch (Exception ex)
            {


                return BadRequest(ex.Message);

            }

        }




        [HttpPut]
        [Route("actualizar/{id}")]


        public IActionResult ActualizarCalificacion(int id, [FromBody] calificaciones calificacionModificar)
        {
            calificaciones? calificacionActual = (from c in _blogDBContexto.calificaciones
                                                  where c.calificacionId == id
                                                  select c).FirstOrDefault();


            if (calificacionActual == null) { return NotFound(); }

            
            calificacionActual.calificacion = calificacionModificar.calificacion;



            _blogDBContexto.Entry(calificacionActual).State = EntityState.Modified;
            _blogDBContexto.SaveChanges();

            return Ok(calificacionModificar);


        }



        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult eliminarCalificacion(int id)
        {

            calificaciones? calificacion = (from c in _blogDBContexto.calificaciones
                                            where c.calificacionId == id
                                            select c).FirstOrDefault();


            if (calificacion == null)
            {
                return NotFound();
            }


            _blogDBContexto.calificaciones.Attach(calificacion);
            _blogDBContexto.calificaciones.Remove(calificacion);
            _blogDBContexto.SaveChanges();

            return Ok(calificacion);


        }


        [HttpGet]
        [Route("GetByPublicacionId/{id}")]

        public IActionResult GetByPublicacionId(int id){
        
        var calificacion = (from  c in  _blogDBContexto.calificaciones 
                            
                            where c.publicacionId == id

                            select c).ToList();
        
        
            if (calificacion == null)
            {

                return NotFound(" No hay calificaciones con el id de la publicacion "+ id);

            }

            return Ok(calificacion);
        
        }



        

    }
}
