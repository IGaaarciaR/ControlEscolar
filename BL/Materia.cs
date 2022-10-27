using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        //Entity Framework
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }    
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                throw;
            }
            return result;
        }
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {

                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                throw;
            }
            return result;
        }
        public static ML.Result Delete(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    var query = context.MateriaDelete(materia.IdMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                throw;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    var materias = context.MateriaGetAll();
                    result.Objects = new List<object>();


                    if (materias != null)
                    {
                        foreach(var mat in materias)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = mat.IdMateria;
                            materia.Nombre = mat.Nombre;
                            materia.Costo = (decimal)mat.Costo;

                            result.Objects.Add(materia);    

                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                throw;
            }
            return result;
        }
        public static ML.Result GetById(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    var query = context.MateriaGetById(materia.IdMateria).SingleOrDefault();
                    result.Objects = new List<object>();


                    if (query != null)
                    {
                        
                        materia = new ML.Materia();
                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = (decimal)query.Costo;

                        result.Object = materia; //boxing

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                throw;
            }
            return result;
        }
    }
}
