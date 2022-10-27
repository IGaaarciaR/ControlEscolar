using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class MateriaController : ApiController
    {
        //GET ALL : MATERIA
        [HttpGet]
        [Route("api/materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();    
            }
        }

        //ADD : MATERIA
        [HttpPost]
        [Route("api/materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //UPDATE : MATERIA
        [HttpPost]
        [Route("api/materia/Update")]
        public IHttpActionResult Update([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Update(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //GETBYID : MATERIA
        [HttpGet]
        [Route("api/materia/GetById{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();  
            materia.IdMateria = IdMateria;

            ML.Result result = BL.Materia.GetById(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //DELETE : MATERIA
        [HttpGet]
        [Route("api/materia/Delete{IdMateria}")]
        public IHttpActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = IdMateria;

            ML.Result result = BL.Materia.Delete(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}