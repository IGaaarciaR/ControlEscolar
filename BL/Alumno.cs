using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        // SQL Client
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoAdd";

                    using (SqlCommand cmd= new SqlCommand())
                    {
                        cmd.Connection = contex;    
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection); 

                        cmd.Connection.Open();

                        int RowsAfected = cmd.ExecuteNonQuery();

                        if(RowsAfected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Se agrego correctamente el Alumno";

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al agregar el Alumno";
                        }
                    }

                }
            }
            catch(Exception ex) 
            {
                result.Ex = ex;
                throw;
            }

            return result;
        }
        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAfected = cmd.ExecuteNonQuery();

                        if (RowsAfected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Se actualizo correctamente el Alumno";
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al actualizar el Alumno";
                        }
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
        public static ML.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAfected = cmd.ExecuteNonQuery();

                        if (RowsAfected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Se elimino correctamente el Alumno";
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al eliminar el Alumno";
                        }
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
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableAlumno = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumno);
                        if (tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>(); //inicializar una lista 

                            foreach (DataRow row in tableAlumno.Rows) //
                            {
                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();

                                result.Objects.Add(alumno); 
                            }

                            result.Correct = true;
                            
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al seleccionar los registros de la tabla Alumno";
                        }
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
        public static ML.Result GetById(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        DataTable tableAlumno = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumno);
                        if (tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>(); //inicializar una lista 

                                DataRow row = tableAlumno.Rows[0]; //
                            
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();

                            result.Object = alumno;
                            

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al seleccionar los registros de la tabla Alumno";
                        }
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

        // ENTITY FRAMEWORK
        public static ML.Result GetMateriaAsignada(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    var query = context.GetMateriaAsignada(alumnoMateria.Alumno.IdAlumno).ToList();
                    
                    if (query != null)
                    {

                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = item.IdAlumnoMateria;

                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Alumno.IdAlumno = item.IdAlumno;
                            alumnoMateria.Alumno.Nombre = item.NombreAlumno;

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = item.IdMateria;
                            alumnoMateria.Materia.Nombre = item.NombreMateria;
                            alumnoMateria.Materia.Costo = (decimal)item.CostoMateria;

                            result.Objects.Add(alumnoMateria);

                            //result.Object = alumnoMateria; //boxing

                            result.Correct = true;
                        }
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

        // ENTITY FRAMEWORK
        public static ML.Result GetMateriaNoAsignada(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();

            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    int IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    var query = context.GetMateriaNOAsignada(IdAlumno).ToList();

                    if (query != null)
                    {

                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            
                            alumnoMateria = new ML.AlumnoMateria();
                            //alumnoMateria.IdAlumno = (int)item.IdAlumno;
                            //alumnoMateria.IdAlumnoMateria = item.;
                            //alumnoMateria.IDAlumMatIDMateria = (int)item.IDAlumMatIDMateria;   

                            //alumnoMateria.Alumno = new ML.Alumno();
                            //alumnoMateria.Alumno.IdAlumno = (int)item.;

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = (int)item.IdMateria;
                            alumnoMateria.Materia.Nombre = item.Nombre;
                            alumnoMateria.Materia.Costo = (decimal)item.Costo;

                            result.Objects.Add(alumnoMateria);

                                
                            
                            //result.Object = alumnoMateria; //boxing

                            result.Correct = true;
                        }

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

        public static ML.Result AlumnoMateriaDelete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaDelete(alumnoMateria.IdAlumnoMateria);
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

        public static ML.Result AlumnoMateriaAdd(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            //using ()
            try
            {
                using (DL.IGarciaControlEscolarEntities context = new DL.IGarciaControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaAdd(alumnoMateria.Alumno.IdAlumno, alumnoMateria.Materia.IdMateria);
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

    }


}
