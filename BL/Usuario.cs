using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Globalization;

namespace BL
{
    public class Usuario
    {
     //Agregar STORE PROCEDURE
    public static ML.Result AddSP(ML.Usuario usuario) 
          {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string procedure = "UsuarioAdd";
                    using (SqlCommand cmd = new SqlCommand(procedure,Context))
                    {
                        cmd.Connection = Context;
                        //cmd.CommandText = query;
                        cmd.CommandType= CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[14];

                        collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[0].Value = usuario.UserName;

                        collection[1] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[1].Value = usuario.Password;

                        collection[2] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[2].Value = usuario.Nombre;

                        collection[3] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;

                        collection[4] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[4].Value = usuario.ApellidoMaterno;

                        collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;

                        collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.Date.ToString());
                        collection[6].Value = usuario.FechaNacimiento;

                        collection[7] = new SqlParameter("Sexo", SqlDbType.VarChar);
                        collection[7].Value = usuario.Sexo;

                        collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("Estatus", SqlDbType.Bit);
                        collection[10].Value = usuario.Estatus;

                        collection[11] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[11].Value = usuario.CURP;

                        collection[12] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        collection[13] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[13].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        result.Object = Convert.ToInt32(cmd.Parameters["IdUsuario"].Value);

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
       }
    //Actualizar STORE PROCEDURE
    public static ML.Result UpdateSP(ML.Usuario usuario)
    {
      ML.Result result=new ML.Result();
      try
       { 
         using (SqlConnection context= new SqlConnection(DL.Conexion.GetConnectionString()))
          {
              string query = "UsuarioUpdate";
               using (SqlCommand cmd=new SqlCommand())
               {
                   cmd.Connection = context;
                   cmd.CommandText = query;
                   cmd.CommandType = CommandType.StoredProcedure;

                  SqlParameter[] collection = new SqlParameter[14];

                  collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                  collection[0].Value = usuario.IdUsuario;

                  collection[1] = new SqlParameter("UserName", SqlDbType.VarChar);
                  collection[1].Value = usuario.UserName;

                  collection[2] = new SqlParameter("Password", SqlDbType.VarChar);
                  collection[2].Value = usuario.Password;

                  collection[3] = new SqlParameter("Nombre", SqlDbType.VarChar);
                  collection[3].Value = usuario.Nombre;

                  collection[4] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                  collection[4].Value = usuario.ApellidoPaterno;

                  collection[5] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                  collection[5].Value = usuario.ApellidoMaterno;

                  collection[6] = new SqlParameter("Email", SqlDbType.VarChar);
                  collection[6].Value = usuario.Email;

                  collection[7] = new SqlParameter("FechaNacimiento", SqlDbType.Date.ToString());
                  collection[7].Value = usuario.FechaNacimiento;

                  collection[8] = new SqlParameter("Sexo", SqlDbType.VarChar);
                  collection[8].Value = usuario.Sexo;

                  collection[9] = new SqlParameter("Telefono", SqlDbType.VarChar);
                  collection[9].Value = usuario.Telefono;

                  collection[10] = new SqlParameter("Celular", SqlDbType.VarChar);
                  collection[10].Value = usuario.Celular;

                  collection[11] = new SqlParameter("Estatus", SqlDbType.Bit);
                  collection[11].Value = usuario.Estatus;

                  collection[12] = new SqlParameter("CURP", SqlDbType.VarChar);
                  collection[12].Value = usuario.CURP;

                  collection[13] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                  collection[13].Value = usuario.Rol.IdRol;

                  cmd.Parameters.AddRange(collection);
                  cmd.Connection.Open();

                  int RowsAffected = cmd.ExecuteNonQuery();

                  if(RowsAffected>0)
                  {
                      result.Correct=true;
                  }
                  else
                  {
                      result.Correct=false;
                  }
             }
         }
      }
     catch (Exception ex)
      {
          result.Correct = false;
          result.ErrorMessage = ex.Message;
          result.Ex = ex;
      }

      return result;

    }
    //Eliminar STORE PROCEDURE
     public static ML.Result DeleteSP(ML.Usuario usuario)
    {
       ML.Result result=new ML.Result();
       try
       {
           using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
           {
               string query = "UsuarioDelete";
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = context;
                   cmd.CommandText = query;
                   cmd.CommandType = CommandType.StoredProcedure;

                   SqlParameter[] collection = new SqlParameter[1];

                   collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                   collection[0].Value = usuario.IdUsuario;

                   cmd.Parameters.AddRange(collection);
                   cmd.Connection.Open();

                   int RowsAffected = cmd.ExecuteNonQuery();

                   if (RowsAffected > 0)
                   {
                       result.Correct = true;
                   }
                   else
                   {
                       result.Correct = false;
                   }
               }
           }
       }
       catch (Exception ex)
       {
           result.Correct = false;
           result.ErrorMessage = ex.Message;
           result.Ex = ex;
       }

       return result;
    }
     //Tarer Todo GetAll STORE PROCEDURE
     public static ML.Result GetAllSP()
     {
         ML.Result result = new ML.Result();
         try
         {
             using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
             {
                 string query = "UsuarioGetAll";
                 using (SqlCommand cmd = new SqlCommand())
                 {
                     cmd.Connection = context;
                     cmd.CommandText = query;
                     cmd.CommandType = CommandType.StoredProcedure;

                     DataTable UsuarioTable = new DataTable();//instnacia de mi DataTable

                     SqlDataAdapter da = new SqlDataAdapter(cmd);

                     da.Fill(UsuarioTable);

                     if (UsuarioTable.Rows.Count > 0)
                     {
                         result.Objects = new List<object>();//Para meter una lista de objetos 

                         foreach (DataRow row in UsuarioTable.Rows)
                         {
                             ML.Usuario usu = new ML.Usuario();

                             usu.IdUsuario = int.Parse(row[0].ToString());
                             usu.UserName = row[1].ToString();
                             usu.Password = row[2].ToString();
                             usu.Nombre = row[3].ToString();
                             usu.ApellidoPaterno = row[4].ToString();
                             usu.ApellidoMaterno = row[5].ToString();
                             usu.Email = row[6].ToString();
                             usu.FechaNacimiento = row[7].ToString();
                             usu.Sexo = row[8].ToString();
                             usu.Telefono = row[9].ToString();
                             usu.Celular = row[10].ToString();
                             usu.Estatus = bool.Parse(row[11].ToString());
                             usu.CURP = row[12].ToString();
                             usu.Rol = new ML.Rol();
                             usu.Rol.IdRol=byte.Parse(row[13].ToString());

                             result.Objects.Add(usu);
                         }

                         result.Correct = true;
                     }
                     else
                     {
                         result.Correct = false;
                         result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Usuarios";
                     }

                 }
             }
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.ErrorMessage = ex.Message;
             result.Ex = ex;
         }
         return result;
     }
     //Traer por Id STORE PROCEDURE
     public static ML.Result GetByIdSP(ML.Usuario usuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
             {
                 string query = "UsuarioGetById";
                 using (SqlCommand cmd = new SqlCommand())
                 {
                     cmd.Connection = context;
                     cmd.CommandText = query;
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Connection.Open();

                     SqlParameter[] collection = new SqlParameter[1];

                     collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                     collection[0].Value = usuario.IdUsuario;

                     cmd.Parameters.AddRange(collection);

                     using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                     {
                         DataTable UsuarioTable = new DataTable();//instnacia de mi DataTable objetos con minusculas

                         da.Fill(UsuarioTable); //Llenar la inf de la tabla materia

                         if (UsuarioTable.Rows.Count > 0)
                         {
                             DataRow row = UsuarioTable.Rows[0];
                             result.Object = new object();

                             ML.Usuario usu = new ML.Usuario();
                             usu.Rol = new ML.Rol();

                             usu.IdUsuario = int.Parse(row[0].ToString());
                             usu.UserName = row[1].ToString();
                             usu.Password = row[2].ToString();
                             usu.Nombre = row[3].ToString();
                             usu.ApellidoPaterno = row[4].ToString();
                             usu.ApellidoMaterno = row[5].ToString();
                             usu.Email = row[6].ToString();
                             usu.FechaNacimiento = row[7].ToString();
                             usu.Sexo = row[8].ToString();
                             usu.Telefono = row[9].ToString();
                             usu.Celular = row[10].ToString();
                             usu.Estatus = bool.Parse(row[11].ToString());
                             usu.CURP = row[12].ToString();
                             usu.Rol.IdRol = byte.Parse(row[13].ToString());

                             result.Object = usu;
                             result.Correct = true;

                         }
                         else
                     {
                         result.Correct = false;
                         result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Usuarios";
                     }

                 }
             }
       
            }
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.ErrorMessage = ex.Message;
             result.Ex = ex;
         }
         return result;
     }



    //Agregar EntityFramework
     public static ML.Result AddEF(ML.Usuario usuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context=new DL_EF.NRojasProgramacionNCapasEntities1())
              {
                 ObjectParameter IdUsuario = new ObjectParameter("IdUsuario", typeof(int));
                 var query = context.UsuarioAdd(usuario.UserName, usuario.Password, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.Estatus, usuario.CURP, usuario.Rol.IdRol,usuario.Imagen,IdUsuario);

                     if (query != null)
                     {
                         result.Correct = true;
                         //result.Object = Convert.ToInt32(IdUsuario.Value);
                     }
                     else
                     {
                         result.Correct = false;
                     }
             }
             result.Correct = true;
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.Ex = ex;
         }
         return result;
     }
     //Actualizar EntityFramework
     public static ML.Result UpdateEF(ML.Usuario usuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context= new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var updateResult = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Password, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.Estatus, usuario.CURP, usuario.Rol.IdRol,usuario.Imagen);
                 if (updateResult >= 1)
                 {
                     result.Correct = true;
                 }
                 else
                 {
                     result.Correct = false;
                     result.ErrorMessage="Error al Actualizar Usuario";
                 }
             }
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.Ex = ex;
         }
         return result;
     }
     //Borrar EntityFramework
     public static ML.Result DeleteEF(int IdUsuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var query = context.UsuarioDelete(IdUsuario);
                 if (query >= 1)
                 {
                     result.Correct = true;
                 }
                 else
                 {
                     result.Correct = false;
                     result.ErrorMessage = "Error al Eliminar al Usuario";
                 }
             }
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.Ex = ex;
         }
         return result;
     }
     //Traer Todo EntityFramework
     public static ML.Result GetAllEF(ML.Usuario usuario)
     {
         ML.Result result = new ML.Result();
            
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var usuarios = context.UsuarioGetAll(usuario.Nombre,usuario.ApellidoPaterno, usuario.ApellidoMaterno).ToList();

                 result.Objects = new List<Object>();

                 if (usuarios != null)
                 {
                     foreach (var obj in usuarios)
                     {
                         

                         usuario = new ML.Usuario();
                         usuario.IdUsuario = Convert.ToInt16(obj.IdUsuario);
                         usuario.UserName = obj.UserName;
                         usuario.Password = obj.Password;
                         usuario.Nombre = obj.Nombre;
                         usuario.ApellidoPaterno = obj.ApellidoPaterno;
                         usuario.ApellidoMaterno = obj.ApellidoMaterno;
                         usuario.Email = obj.Email;
                         usuario.FechaNacimiento = Convert.ToString(obj.FechaNacimiento);
                         usuario.Sexo = obj.Sexo;
                         usuario.Telefono = obj.Telefono;
                         usuario.Celular = obj.Celular;
                         usuario.CURP = obj.CURP;

                         usuario.Rol = new ML.Rol();
                         usuario.Rol.IdRol = Convert.ToByte(obj.IdRol);
                         usuario.Rol.Nombre = obj.NombreRol;
                         //usuario.Imagen = obj.Imagen;

                         result.Objects.Add(usuario);
                     }
                     result.Correct = true;
                 }
                 else
                 {
                     result.Correct = false;
                     result.ErrorMessage = "No se encontraron registros";
                 }
             }
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.ErrorMessage = ex.Message;
         }
         return result;
     }
     //Traer por ID EntityFramework
     public static ML.Result GetByIdEF(int IdUsuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var ObjUsuario = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                 result.Objects = new List<object>();

                 if (ObjUsuario != null)
                 {
                     ML.Usuario usuario = new ML.Usuario(); 

                     usuario.IdUsuario = ObjUsuario.IdUsuario;
                     usuario.UserName = ObjUsuario.UserName;
                     usuario.Password = ObjUsuario.Password;
                     usuario.Nombre = ObjUsuario.Nombre;
                     usuario.ApellidoPaterno = ObjUsuario.ApellidoPaterno;
                     usuario.ApellidoMaterno = ObjUsuario.ApellidoMaterno;
                     usuario.Email = ObjUsuario.Email;
                     usuario.FechaNacimiento = Convert.ToString(ObjUsuario.FechaNacimiento);
                     usuario.Sexo = ObjUsuario.Sexo;
                     usuario.Telefono = ObjUsuario.Telefono;
                     usuario.Celular = ObjUsuario.Celular;
                     usuario.CURP = ObjUsuario.CURP;
                     usuario.Rol = new ML.Rol();
                     usuario.Rol.IdRol = Convert.ToByte(ObjUsuario.IdRol);
                     usuario.Imagen = Convert.ToString(ObjUsuario.Imagen);

                     result.Correct = true;
                     result.Object = usuario; 
                     //result.Objects.Add(usuario);
                 }
                 else
                 {
                     result.Correct = false;
                     result.ErrorMessage = "Ocurrio un error al consultar al usuario";
                 }

             }
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.ErrorMessage = ex.Message;
             result.Ex = ex;
         }
         return result;
     }


     // AgregarLinq
     public static ML.Result AddLinq(ML.Usuario usuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context= new DL_EF.NRojasProgramacionNCapasEntities1())
             {

                 DL_EF.Usuario usuarioA = new DL_EF.Usuario();

                 usuarioA.UserName= usuario.UserName;
                 usuarioA.Password = usuario.Password;
                 usuarioA.Nombre = usuario.Nombre;
                 usuarioA.ApellidoPaterno = usuario.ApellidoPaterno;
                 usuarioA.ApellidoMaterno = usuario.ApellidoMaterno;
                 usuarioA.Email = usuario.Email;
                 usuarioA.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento,"dd/MM/yyyy",CultureInfo.InvariantCulture);
                 usuarioA.Sexo = usuario.Sexo;
                 usuarioA.Telefono = usuario.Telefono;
                 usuarioA.Celular = usuario.Celular;
                 usuarioA.Estatus = usuario.Estatus;
                 usuarioA.CURP = usuario.CURP;
                 usuarioA.IdRol = usuario.Rol.IdRol;
                 usuarioA.IdUsuario = usuario.IdUsuario;

                 context.Usuarios.Add(usuarioA);

                 int RowsAffected = context.SaveChanges();
                 result.Object = usuarioA.IdUsuario;

                 if( RowsAffected > 0)
                 {
                     result.Correct = true;
                 }
                 else
                 {
                     result.Correct = false;
                     result.ErrorMessage = "Ocurrio un error al registrar al usuario";
                 }
             }
         }
         catch (Exception ex)
         {
            
             result.Correct = false;
             result.ErrorMessage = ex.Message;
         }
         return result;
     }
     //ActualizarLinq
     public static ML.Result UpdateLinq(ML.Usuario usuario)
     {
         ML.Result result = new ML.Result();
         try
         {

             using(DL_EF.NRojasProgramacionNCapasEntities1 context= new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var query = (from a in context.Usuarios
                              where a.IdUsuario == usuario.IdUsuario
                              select a).SingleOrDefault();
                if(query != null)
                {
                    query.UserName = usuario.UserName;
                    query.Password = usuario.Password;
                    query.Nombre = usuario.Nombre;
                    query.ApellidoPaterno = usuario.ApellidoPaterno;
                    query.ApellidoMaterno = usuario.ApellidoMaterno;
                    query.Email = usuario.Email;
                    query.FechaNacimiento = Convert.ToDateTime(usuario.FechaNacimiento);
                    query.Sexo = usuario.Sexo;
                    query.Telefono = usuario.Telefono;
                    query.Celular = usuario.Celular;
                    query.CURP = usuario.CURP;
                    query.Rol.IdRol = usuario.Rol.IdRol;
                    context.SaveChanges();
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontro al usuario" + usuario.IdUsuario;
                }
             }
             result.Correct = true;
         }
         catch (Exception ex)
         {
             result.Correct = false;
             result.Ex = ex;
         }
         return result;
     }
     //EliminarLinq
     public static ML.Result DeleteLinq(int IdUsuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var query=(from a in context.Usuarios
                            where a.IdUsuario == IdUsuario
                            select a).First();
                 context.Usuarios.Remove(query);
                 context.SaveChanges();

                 if (query != null)
                 {
                     result.Correct = true;
                 }
                 else
                 {
                     result.Correct = false;
                 }
             }
         }
        catch(Exception ex)
         {
             result.Correct = false;
             result.Ex = ex;
        }
        return result;
    }
     //Traer Todo Linq
     public static ML.Result GetAllLinq()
     {
         ML.Result result = new ML.Result();
         try
         {
             using(DL_EF.NRojasProgramacionNCapasEntities1 context= new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var UsuarioList=( from usuarioTable in context.Usuarios 
                                   select 
                                   new 
                                   {
                                       IdUsuario=usuarioTable.IdUsuario,
                                       UserName= usuarioTable.UserName,
                                       Password = usuarioTable.Password,
                                       Nombre =usuarioTable.Nombre,
                                       ApellidoPaterno = usuarioTable.ApellidoPaterno,
                                       ApellidoMaterno = usuarioTable.ApellidoMaterno,
                                       Email = usuarioTable.Email,
                                       FechaNacimiento = usuarioTable.FechaNacimiento,
                                       Sexo = usuarioTable.Sexo,
                                       Telefono = usuarioTable.Telefono,
                                       Celular = usuarioTable.Celular,
                                       Estatus = usuarioTable.Estatus,
                                       CURP = usuarioTable.CURP,
                                       IdRol = usuarioTable.Rol.IdRol
                                   }
                                   ) .ToList();
                  result.Objects = new List<object>();

                 if(UsuarioList.Count>0)
                 {
                     foreach(var UsuarioItem in UsuarioList)
                     {
                         ML.Usuario usuario = new ML.Usuario();

                         usuario.IdUsuario = UsuarioItem.IdUsuario;
                         usuario.UserName = UsuarioItem.UserName;
                         usuario.Password = UsuarioItem.Password;
                         usuario.Nombre= UsuarioItem.Nombre;
                         usuario.ApellidoPaterno = UsuarioItem.ApellidoPaterno;
                         usuario.ApellidoMaterno = UsuarioItem.ApellidoMaterno;
                         usuario.Email= UsuarioItem.Email;
                         usuario.FechaNacimiento = Convert.ToString(UsuarioItem.FechaNacimiento);
                         usuario.Sexo = UsuarioItem.Sexo;
                         usuario.Telefono = UsuarioItem.Telefono;
                         usuario.Celular = UsuarioItem.Celular;
                         usuario.CURP = UsuarioItem.CURP;
                         usuario.Rol = new ML.Rol();
                         usuario.Rol.IdRol = UsuarioItem.IdRol;
                         result.Objects.Add(usuario);
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
             result.Ex = ex;

         }
         return result;
     }
     //Traer por Id Linq 
     public static ML.Result GetByIdLinq(int IdUsuario)
     {
         ML.Result result = new ML.Result();
         try
         {
             using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var ObjUsuario = (from usuarioTable in context.Usuarios
                                   where usuarioTable.IdUsuario == IdUsuario
                                   select
                                   new
                                   {
                                       IdUsuario = usuarioTable.IdUsuario,
                                       UserName = usuarioTable.UserName,
                                       Password = usuarioTable.Password,
                                       Nombre = usuarioTable.Nombre,
                                       ApellidoPaterno = usuarioTable.ApellidoPaterno,
                                       ApellidoMaterno = usuarioTable.ApellidoMaterno,
                                       Email = usuarioTable.Email,
                                       FechaNacimiento = usuarioTable.FechaNacimiento,
                                       Sexo = usuarioTable.Sexo,
                                       Telefono = usuarioTable.Telefono,
                                       Celular = usuarioTable.Celular,
                                       Estatus = usuarioTable.Estatus,
                                       CURP = usuarioTable.CURP,
                                       IdRol = usuarioTable.Rol.IdRol
                                   }
                                   ).FirstOrDefault();

                 if (ObjUsuario !=  null)
                 {
                         ML.Usuario usuario = new ML.Usuario();

                         usuario.IdUsuario = ObjUsuario.IdUsuario;
                         usuario.UserName=ObjUsuario.UserName;
                         usuario.Password = ObjUsuario.Password;
                         usuario.Nombre = ObjUsuario.Nombre;
                         usuario.ApellidoPaterno = ObjUsuario.ApellidoPaterno;
                         usuario.ApellidoMaterno = ObjUsuario.ApellidoMaterno;
                         usuario.Email = ObjUsuario.Email;
                         usuario.FechaNacimiento = Convert.ToString(ObjUsuario.FechaNacimiento);
                         usuario.Sexo = ObjUsuario.Sexo;
                         usuario.Telefono = ObjUsuario.Telefono;
                         usuario.Celular = ObjUsuario.Celular;
                         usuario.CURP = ObjUsuario.CURP;
                         usuario.Rol = new ML.Rol();
                         usuario.Rol.IdRol = ObjUsuario.IdRol;

                         result.Object = usuario;
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
             result.Ex = ex;

         }
         return result;
     }
    
    
  }
}
