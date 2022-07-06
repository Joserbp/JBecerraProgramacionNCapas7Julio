using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Ingrese el nombre del alumno");
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Ingreso el genero del alumno");
            alumno.Genero = Console.ReadLine();

            string result = BL.Alumno.Add(alumno);

            Console.WriteLine(result);
        }
    }
}
