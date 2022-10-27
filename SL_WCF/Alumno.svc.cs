using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {

        public Result Add(ML.Alumno alumno)
        {

            ML.Result result = BL.Alumno.Add(alumno);
            return new Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects

            };

        }

        public Result GetAll(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.GetAll();
            return new Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects

            };
        }

        public Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            return new Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects

            };
        }
        public Result Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Delete(alumno);
            return new Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects

            };
        }
        public Result GetById(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.GetById(alumno);
            return new Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects

            };
        }
    }
}
