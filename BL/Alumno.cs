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
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "INSERT INTO Alumno(Nombre, ApellidoPaterno, ApellidoMaterno , Email) VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Email)";
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[4];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = alumno.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = alumno.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoMaterno;
                    collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[3].Value = alumno.Email;


                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowAffected = cmd.ExecuteNonQuery(); //Ejecutamos nuestro query

                    if (RowAffected > 0)
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
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
