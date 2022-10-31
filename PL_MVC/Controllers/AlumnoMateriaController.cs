using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = BL.Alumno.GetAll();

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
        [HttpGet]
        public ActionResult GetMateriaAsignada(int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Alumno alumno = new ML.Alumno();
            ML.Materia materia = new ML.Materia();

            alumno.IdAlumno = IdAlumno;
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Materia = new ML.Materia();

            alumnoMateria.Alumno.IdAlumno = IdAlumno;
            

            ML.Result resultAlumno = BL.Alumno.GetById(alumno);
            ML.Result resultMateria = BL.Materia.GetAll();

            //ML.Result resultMateria = BL.Materia.GetById(materia);

            if (resultAlumno.Correct)
            {
                alumno = ((ML.Alumno)resultAlumno.Object); 

                ML.Result resultAlumnoMat = BL.Alumno.GetMateriaAsignada(alumnoMateria);
                //Json(resultAlumnoMat.Objects);
                if (resultAlumnoMat.Correct)
                {
                    alumnoMateria.Materia.Materias = resultMateria.Objects;

                    alumnoMateria.AlumnosMaterias = resultAlumnoMat.Objects;
                    
                    //alumnoMateria.Alumno.Alumnos = resultAlumno.Objects;
                    alumnoMateria.Alumno = alumno;

                    alumnoMateria.Alumno.Nombre = alumno.Nombre + " " + alumno.ApellidoPaterno + " " + alumno.ApellidoMaterno;
                    //alumnoMateria.IdAlumno = alumno.IdAlumno;
                    //alumnoMateria.NombreMateria = materia.Nombre;
                    //alumnoMateria.CostoMateria = materia.Costo;


                    //alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;   
                    //alumnoMateria.AlumnosMaterias = resultAlumnoMat.Objects.ToList();   
                    return View(alumnoMateria);
                }
                else
                {
                    return View(alumnoMateria);
                }
            }
            else
            {
                return View(alumnoMateria);
            }
        }

        [HttpGet]
        public ActionResult GetMateriaNOAsignada(int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Alumno alumno = new ML.Alumno();
            ML.Materia materia = new ML.Materia();

            alumno.IdAlumno = IdAlumno;
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Materia = new ML.Materia();

            alumnoMateria.Alumno.IdAlumno = IdAlumno;
            

            ML.Result resultAlumno = BL.Alumno.GetById(alumno);
            ML.Result resultMateria = BL.Materia.GetAll();


            if (resultAlumno.Correct)
            {
                alumno = ((ML.Alumno)resultAlumno.Object);

                ML.Result resultAlumnoMat = BL.Alumno.GetMateriaNoAsignada(alumnoMateria);

                if (resultAlumnoMat.Correct)
                {
                    //alumnoMateria.Materia.Materias = resultMateria.Objects;

                    alumnoMateria.AlumnosMaterias = resultAlumnoMat.Objects;

                    //alumnoMateria.Alumno = alumno;

                    alumnoMateria.Alumno.Nombre = alumno.Nombre + " " + alumno.ApellidoPaterno + " " + alumno.ApellidoMaterno;
                    
                    
                    //foreach (int var in alumnoMateria.AlumnosMaterias)
                    //{
                    //    if(alumnoMateria.IDAlumMatIDMateria != alumnoMateria.Materia.IdMateria)
                    //    {

                    //    }
                    //}

                    return View(alumnoMateria);
                }
                else
                {
                    return View(alumnoMateria);
                }
            }
            else
            {
                return View(alumnoMateria);
            }
        }

        //[HttpPost]
        //public ActionResult GetMateriaNOAsignada(int IdAlumno, int IdAlumnoMateria)
        //{

        //    ML.Result resultMaterias = new ML.Result();
        //    ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
        //    alumnoMateria.IdAlumnoMateria = IdAlumnoMateria;
        //    alumnoMateria.Alumno = new ML.Alumno();
        //    alumnoMateria.Alumno.IdAlumno = IdAlumno;


        //    ML.Result result = BL.Alumno.AlumnoMateriaAdd(alumnoMateria);

        //    if (result.Correct)
        //    {
        //        resultMaterias = BL.Alumno.GetMateriaAsignada(alumnoMateria);
        //        if (resultMaterias.Correct)
        //        {
        //            ViewBag.Message = "Materia eliminada correctamente";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio un error al eliminar la Materia";

        //        }
        //    }
        //    return View("ModalMateriaAsignada");

        //}
        public ActionResult AlumnoMateriaDelete(int IdAlumnoMateria, int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.IdAlumnoMateria = IdAlumnoMateria;

            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno;

            ML.Result resultMaterias = new ML.Result();

            ML.Result result = BL.Alumno.AlumnoMateriaDelete(alumnoMateria);

            if (result.Correct)
            {
                resultMaterias = BL.Alumno.GetMateriaAsignada(alumnoMateria);
                if (resultMaterias.Correct)
                {
                    ViewBag.Message = "Materia eliminada correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al eliminar la Materia";

                }
            }
            return View("ModalMateriaAsignada");

        }

        [HttpPost]
        public ActionResult AlumnoMateriaAdd(int IdAlumnoMateria, int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.IdAlumnoMateria = IdAlumnoMateria;

            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno;

            ML.Result resultMaterias = new ML.Result();

            ML.Result result = BL.Alumno.AlumnoMateriaAdd(alumnoMateria);

            if (result.Correct)
            {
                resultMaterias = BL.Alumno.GetMateriaAsignada(alumnoMateria);
                if (resultMaterias.Correct)
                {
                    ViewBag.Message = "Materia agregada correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar la Materia";

                }
            }
            return View("ModalMateriaAsignada");
        }
    }
}