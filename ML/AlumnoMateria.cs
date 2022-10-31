using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AlumnoMateria
    {

        public int IdAlumnoMateria { get; set; }
        public ML.Alumno Alumno { get; set; }
        public ML.Materia Materia { get; set; }
        public List<object> AlumnosMaterias { get; set; }
        public string NombreMateria { get; set; }   
        public int IdAlumno { get; set; }   
        public string NombreAlumno { get; set; }   
        public decimal CostoMateria { get; set; }   

        public int IDAlumMatIDMateria { get; set; }  
        public int IDMateria { get; set; }  

    }
}
