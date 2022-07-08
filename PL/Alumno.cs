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
            Console.WriteLine("Ingreso el apellido paterno del alumno");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingreso el apellido materno del alumno");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingreso el email del alumno");
            alumno.Email = Console.ReadLine();

            //ML.Result result = BL.Alumno.Add(alumno);
            ML.Result result = BL.Alumno.AddSP(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Alumno agregado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.Message);
            }

            Console.WriteLine(result);
        }
    }
}
