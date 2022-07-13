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
            Console.WriteLine("Ingreso la fecha de nacimiento del alumno");
            alumno.FechaNacimiento = Console.ReadLine();
            alumno.Semestre = new ML.Semestre();
            Console.WriteLine("Ingreso el semestre del alumno");
            alumno.Semestre.IdSemestre = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Alumno.Add(alumno);
            ML.Result result = BL.Alumno.AddLINQ(alumno);

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
        public static void GetAll()
        {
            //ML.Result result = BL.Alumno.GetAll();
            ML.Result result = BL.Alumno.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Alumno alumno in result.Objects)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("El Nombre del Alumno es: " + alumno.Nombre);
                    Console.WriteLine("El Apellido paterno del Alumno es: " + alumno.ApellidoPaterno);
                    Console.WriteLine("El Apellido materno del Alumno es: " + alumno.ApellidoMaterno);
                    Console.WriteLine("El Email es: " + alumno.Email);
                    Console.WriteLine("Fecha de Nacimiento: " + alumno.FechaNacimiento);
                    Console.WriteLine("Semestre: " + alumno.Semestre.IdSemestre);
                    Console.WriteLine("-----------------------");
                }

            }
            else
            {
                Console.WriteLine("No se ha podido consultar la informaíón" + result.Message);
            }
            Console.ReadKey();
        } 
        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id del Alumno a consultar");
            int IdAlumno = int.Parse(Console.ReadLine());

            ML.Result result = BL.Alumno.GetById(IdAlumno);
            if (result.Correct)
            {
                //unboxing
                ML.Alumno alumno = (ML.Alumno)result.Object;

                Console.WriteLine("-----------------------");
                Console.WriteLine("El Nombre del Alumno es: " + alumno.Nombre);
                Console.WriteLine("El Apellido paterno del Alumno es: " + alumno.ApellidoPaterno);
                Console.WriteLine("El Apellido materno del Alumno es: " + alumno.ApellidoMaterno);
                Console.WriteLine("El Email es: " + alumno.Email);
                Console.WriteLine("Fecha de Nacimiento: " + alumno.FechaNacimiento);
                Console.WriteLine("Semestre: " + alumno.Semestre.IdSemestre);
                Console.WriteLine("-----------------------");
            }
            else
            {
                Console.WriteLine("No se pudo realizar la consulta" + result.Message);
            }
        }
    }
}
