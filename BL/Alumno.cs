using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class Alumno
    {
        public static string Add(ML.Alumno alumno)
        {
            string result = "";
            using(SqlConnection context = new SqlConnection(DL.Conexion.Get())){

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO Alumno(Nombre, Genero) VALUES(@Nombre, @Genero)";
                cmd.Connection = context;

                SqlParameter[] collection = new SqlParameter[2];
                collection[0] = new SqlParameter( "Nombre", SqlDbType.VarChar );
                collection[0].Value = alumno.Nombre;
                collection[1] = new SqlParameter("Genero", SqlDbType.Char);
                collection[1].Value = alumno.Genero;

                cmd.Parameters.AddRange(collection);

                cmd.Connection.Open();

                int RowAffected = cmd.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    result = "Alumno agregado exitosamente";
                }
                else
                {
                    result = "Error al realizar el insert";
                }
            }
            return result;
        }
    }
}
