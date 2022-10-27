using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno(); 

            ServiceAlumno.AlumnoClient alumnoClient = new ServiceAlumno.AlumnoClient();
            var result = alumnoClient.GetAll(alumno);

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
                return View(alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpGet] //vista getbyid
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            if(IdAlumno == null)
            {
                //agregar alumno
                return View(alumno);
            }
            else
            {
                alumno.IdAlumno = IdAlumno.Value;

                ServiceAlumno.AlumnoClient alumnoClient = new ServiceAlumno.AlumnoClient();
                var result = alumnoClient.GetById(alumno);
            
                if(result.Correct)
                {
                    alumno = ((ML.Alumno)result.Object); //unboxing
                    return View(alumno);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ServiceAlumno.AlumnoClient alumnoClient = new ServiceAlumno.AlumnoClient();


            if (alumno.IdAlumno == 0) //agregar alumno
            {
                var result = alumnoClient.Add(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Alumno agregado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar el Alumno";
                }
            }
            else //actualizar
            {
                var result = alumnoClient.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Alumno actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el Alumno";
                }
            }

            return View("Modal");
        }

        public ActionResult Delete(ML.Alumno alumno)
        {
            if(alumno.IdAlumno == 0)
            {
                //agregar
                return View();
            }
            else
            {
                //eliminar
                ServiceAlumno.AlumnoClient alumnoClient = new ServiceAlumno.AlumnoClient();
                var result = alumnoClient.Delete(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Alumno eliminado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al eliminar el Alumno";
                }

            }
            return View("Modal");  
        }






    }
}