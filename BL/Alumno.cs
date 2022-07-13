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
        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "AlumnoAdd";
                    cmd.CommandType = CommandType.StoredProcedure;
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "AlumnoGetAll";
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable tableAlumno = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(tableAlumno);

                    if (tableAlumno.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in tableAlumno.Rows)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            alumno.Email = row[4].ToString();

                            result.Objects.Add(alumno);
                        }

                        result.Correct = true;

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
        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "UsuarioGetById";
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    collection[0].Value = IdAlumno;

                    cmd.Parameters.AddRange(collection);

                    DataTable tableAlumno = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(tableAlumno);

                    if (tableAlumno.Rows.Count > 0)
                    {
                        DataRow row = tableAlumno.Rows[0];

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.Nombre = row[0].ToString();
                        alumno.ApellidoPaterno = row[1].ToString();
                        alumno.ApellidoMaterno = row[2].ToString();
                        //boxing y unboxing


                        //boxing
                        result.Object = alumno;

                        result.Correct = true;

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

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasJulioEntities context = new DL_EF.JBecerraProgramacionNCapasJulioEntities()) {

                    var query = context.AlumnoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objAlumno in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = objAlumno.IdAlumno;
                            alumno.Nombre = objAlumno.Nombre;
                            alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                            alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;
                            alumno.Email = objAlumno.Email;
                            alumno.FechaNacimiento = objAlumno.FechaNacimiento.ToString();
                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre = objAlumno.IdSemestre.Value;

                            result.Objects.Add(alumno);
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
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasJulioEntities context = new DL_EF.JBecerraProgramacionNCapasJulioEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Email, alumno.FechaNacimiento, alumno.Semestre.IdSemestre );

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
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JBecerraProgramacionNCapasJulioEntities context = new DL_EF.JBecerraProgramacionNCapasJulioEntities())
                {

                    var objAlumno = context.AlumnoGetById(IdAlumno).FirstOrDefault();

                    if (objAlumno != null)
                    {

                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = objAlumno.IdAlumno;
                            alumno.Nombre = objAlumno.Nombre;
                            alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                            alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;
                            alumno.Email = objAlumno.Email;

                        result.Object = alumno;
                        
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

        public static ML.Result AddLINQ(ML.Alumno alumno) 
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.JBecerraProgramacionNCapasJulioEntities context = new DL_EF.JBecerraProgramacionNCapasJulioEntities()){

                    DL_EF.Alumno alumnoLINQ = new DL_EF.Alumno();
                    alumnoLINQ.Nombre = alumno.Nombre;
                    alumnoLINQ.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumnoLINQ.ApellidoMaterno = alumno.ApellidoMaterno;
                    alumnoLINQ.Email = alumno.Email;
                    alumnoLINQ.FechaNacimiento = DateTime.Parse(alumno.FechaNacimiento);
                    alumnoLINQ.IdSemestre = alumno.Semestre.IdSemestre;

                    context.Alumnoes.Add(alumnoLINQ);
                    context.SaveChanges();

                    result.Correct = true;
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
