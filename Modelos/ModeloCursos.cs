using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoEducativo.Modelos
{
    internal class ModeloCursos
    {
        int idCurso;
        string nombreCurso;
        int duracionCurso;
        double precioCurso;
        int instructorCurso;

        public int IdCurso { get => idCurso; set => idCurso = value; }
        public string NombreCurso { get => nombreCurso; set => nombreCurso = value; }
        public int DuracionCurso { get => duracionCurso; set => duracionCurso = value; }
        public double PrecioCurso { get => precioCurso; set => precioCurso = value; }
        public int InstructorCurso { get => instructorCurso; set => instructorCurso = value; }
    }
}
