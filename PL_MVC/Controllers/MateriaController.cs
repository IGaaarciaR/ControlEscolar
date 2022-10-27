using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {


        // GET ALL: Materia
        [HttpGet]
        public ActionResult GetAll()
        {

            //ML.Result result = BL.Materia.GetAll();
            ML.Materia materia = new ML.Materia();
            ML.Result resultMaterias = new ML.Result();

            resultMaterias.Objects = new List<object>();

            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings[("WebApi")];
                client.BaseAddress = new Uri($@"{url}");

                var respuestaTarea = client.GetAsync("materia/GetAll");
                respuestaTarea.Wait();

                var result = respuestaTarea.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTarea = result.Content.ReadAsAsync < ML.Result>();
                    readTarea.Wait();

                    foreach(var resultItem in readTarea.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resultMaterias.Objects.Add(resultItemList);

                    }
                }
                materia.Materias = resultMaterias.Objects;
            }
                return View(materia);
            
        }

        // GET By Id: Materia Vista
        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Result result = new ML.Result();
            ML.Materia materia = new ML.Materia();

            if(IdMateria == null)
            {
                //llenar listas
                //agregar
                return View(materia);
            }
            else
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        string url = ConfigurationManager.AppSettings[("WebApi")];
                        client.BaseAddress = new Uri($@"{url}");

                        var respuestaTarea = client.GetAsync("materia/GetById" + IdMateria);
                        respuestaTarea.Wait();

                        var resultAPI = respuestaTarea.Result;

                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTarea = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTarea.Wait();

                            ML.Materia resultItemList = new ML.Materia();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTarea.Result.Object.ToString());
                            
                            result.Object = resultItemList;
                            materia = (ML.Materia)result.Object;
                            
                            result.Correct = true;  
                            return View(materia);
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla de materia";
                        }
                    
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }
            }

            return View();
        }

        // ADD Y UPDATE FORM: Materia 
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.IdMateria == 0) //agregar
            {
                using (var client = new HttpClient())
                {

                    string url = ConfigurationManager.AppSettings[("WebApi")];
                    client.BaseAddress = new Uri($@"{url}");

                    var respuestaTarea = client.PostAsJsonAsync("materia/Add", materia);
                    respuestaTarea.Wait();

                    var resultAPI = respuestaTarea.Result;

                    if (resultAPI.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Materia agregado correctamente";

                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al agregar la Materia";

                    }
                }
            }
            else
            {
                using (var client = new HttpClient())
                {

                    string url = ConfigurationManager.AppSettings[("WebApi")];
                    client.BaseAddress = new Uri($@"{url}");

                    var respuestaTarea = client.PostAsJsonAsync("materia/Update", materia);
                    respuestaTarea.Wait();

                    var resultAPI = respuestaTarea.Result;

                    if (resultAPI.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Materia actualizada correctamente";

                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al actualizar la Materia";

                    }
                }
            }

            return View("Modal");
        }

        //DELETE: Materia

        [HttpGet]
        public ActionResult Delete(ML.Materia materia)
        {
            ML.Result resultListMaterias = new ML.Result();
            int IdMateria = materia.IdMateria;

            if (materia.IdMateria == 0) //agregar
            {
                return View(); // agregar 
            }
            else
            {
                using (var client = new HttpClient())
                {

                    string url = ConfigurationManager.AppSettings[("WebApi")];
                    client.BaseAddress = new Uri($@"{url}");

                    var postTask = client.GetAsync("materia/Delete" + IdMateria);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        resultListMaterias = BL.Materia.GetAll();

                        if (resultListMaterias.Correct)
                        {
                            ViewBag.Message = "Materia eliminada correctamente";

                        }
                        else
                        {
                            ViewBag.Message = "Ocurrio un error al eliminar la Materia";

                        }
                        return View("Modal");

                    }

                    else
                    {
                        ViewBag.Message = "ERROR, NOT FOUND!";

                    }
                    return View("Modal");
                }
            }
        }


    }
}