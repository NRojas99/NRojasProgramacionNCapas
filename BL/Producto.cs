using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace BL
{
   public class Producto
    {
       //Agregar
        public static ML.Result AddSP(ML.Producto producto) 
          {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ProductoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = Context;
                        cmd.CommandText = query;
                        cmd.CommandType= CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.TinyInt);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

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
                result.Correct = true;
            }
             catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
          }
      //Actualizar
        public static ML.Result UpdateSP(ML.Producto producto)
           {
               ML.Result result = new ML.Result();
               try
               {
                   using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                   {
                       string query = "ProductoUpdate";
                       using (SqlCommand cmd = new SqlCommand())
                       {
                           cmd.Connection = context;
                           cmd.CommandText = query;
                           cmd.CommandType = CommandType.StoredProcedure;

                           SqlParameter[] collection = new SqlParameter[7];

                           collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                           collection[0].Value = producto.IdProducto;

                           collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                           collection[1].Value = producto.Nombre;

                           collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                           collection[2].Value = producto.PrecioUnitario;

                           collection[3] = new SqlParameter("Stock", SqlDbType.Int);
                           collection[3].Value = producto.Stock;

                           collection[4] = new SqlParameter("IdProveedor", SqlDbType.Int);
                           collection[4].Value = producto.Proveedor.IdProveedor;

                           collection[5] = new SqlParameter("IdDepartamento", SqlDbType.TinyInt);
                           collection[5].Value = producto.Departamento.IdDepartamento;

                           collection[6] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                           collection[6].Value = producto.Descripcion;

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
      //Eliminar
        public static ML.Result DeleteSP(ML.Producto producto)
             {
                 ML.Result result=new ML.Result();
                     try
                     {
                         using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                         {
                             string query = "ProductoDelete";
                             using (SqlCommand cmd = new SqlCommand())
                             {
                                 cmd.Connection = context;
                                 cmd.CommandText = query;
                                 cmd.CommandType = CommandType.StoredProcedure;

                                 SqlParameter[] collection = new SqlParameter[1];

                                 collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                                 collection[0].Value = producto.IdProducto;

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
     //Traer todo
        public static ML.Result GetAllSP()
           {
               ML.Result result = new ML.Result();
               try
               {
                 using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                   {
                       string query = "ProductoGetAll";
                       using (SqlCommand cmd = new SqlCommand())
                       {
                           cmd.Connection = context;
                           cmd.CommandText = query;
                           cmd.CommandType = CommandType.StoredProcedure;

                           DataTable ProductoTable = new DataTable();//instnacia de mi DataTable

                           SqlDataAdapter da = new SqlDataAdapter(cmd);

                           da.Fill(ProductoTable);
                            if (ProductoTable.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();//Para meter una lista de objetos 

                                foreach (DataRow row in ProductoTable.Rows)
                                {
                                    ML.Producto producto = new ML.Producto();

                                    producto.IdProducto = int.Parse(row[0].ToString());
                                    producto.Nombre = row[1].ToString();
                                    producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                    producto.Stock= int.Parse(row[3].ToString());
                                    producto.Proveedor = new ML.Proveedor();
                                    producto.Proveedor.IdProveedor= int.Parse(row[4].ToString());
                                    producto.Departamento= new ML.Departamento();
                                    producto.Departamento.IdDepartamento = byte.Parse(row[5].ToString());
                                   producto.Descripcion = row[6].ToString();
                                   result.Objects.Add(producto);
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
      //Traer por Id
        public static ML.Result GetByIdSP(ML.Producto producto)
            {
                 ML.Result result = new ML.Result();
               try
                 {
                 using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                   {
                     string query = "ProductoGetById";
                     using (SqlCommand cmd = new SqlCommand())
                       {
                         cmd.Connection = context;
                         cmd.CommandText = query;
                         cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Connection.Open();

                         SqlParameter[] collection = new SqlParameter[1];

                         collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                         collection[0].Value = producto.IdProducto;

                         cmd.Parameters.AddRange(collection);

                         using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                           {
                        
                           DataTable ProductoTable = new DataTable();//instnacia de mi DataTable

                             da.Fill(ProductoTable);

                            if (ProductoTable.Rows.Count > 0)
                                {
                                   DataRow row = ProductoTable.Rows[0];
                                   result.Object = new object();

                                   ML.Producto Prod = new ML.Producto();
                                   Prod.Proveedor = new ML.Proveedor();
                                   Prod.Departamento = new ML.Departamento();

                                   Prod.IdProducto = int.Parse(row[0].ToString());
                                   Prod.Nombre = row[1].ToString();
                                   Prod.PrecioUnitario = decimal.Parse(row[2].ToString());
                                   Prod.Stock = int.Parse(row[3].ToString());
                                   Prod.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                                   Prod.Departamento.IdDepartamento = byte.Parse(row[5].ToString());
                                   Prod.Descripcion = row[6].ToString();

                                   result.Object = Prod;
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
       public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
                {
                    var query = context.ProductoAdd(producto.Nombre,producto.PrecioUnitario,producto.Stock,producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento,producto.Descripcion,producto.Imagen);
                    if (query > 0)
                    {
                        result.Correct = true;
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
       public static ML.Result UpdateEF(ML.Producto producto)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion,producto.Imagen);
                   if (query > 0)
                   {
                       result.Correct = true;
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
       //Borrar EntityFramework
       public static ML.Result DeleteEF(int IdProducto)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query = context.ProductoDelete(IdProducto);
                   if (query >= 1)
                   {
                       result.Correct = true;
                   }
                   else
                   {
                       result.Correct = false;
                       result.ErrorMessage = "Error al borrar Producto";
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
       public static ML.Result GetAllEF()
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var productos = context.ProductoGetAll().ToList();

                   result.Objects = new List<Object>();

                   if (productos != null)
                   {
                       foreach (var obj in productos)
                       {
                           ML.Producto producto = new ML.Producto();
                           producto.IdProducto = obj.IdProducto;
                           producto.Nombre = obj.Nombre;
                           producto.PrecioUnitario = Convert.ToDecimal(obj.PrecioUnitario);
                           producto.Stock = Convert.ToInt16(obj.Stock);
                           producto.Proveedor = new ML.Proveedor();
                           producto.Proveedor.IdProveedor = Convert.ToInt16(obj.IdProveedor);
                           producto.Proveedor.Nombre = obj.NombreProveedor;
                           producto.Departamento = new ML.Departamento();
                           producto.Departamento.IdDepartamento = Convert.ToByte(obj.IdDepartamento);
                           producto.Departamento.Nombre = obj.NombreDepartamento;
                           producto.Departamento.Area = new ML.Area();
                           producto.Departamento.Area.IdArea = Convert.ToByte(obj.IdArea);
                           producto.Departamento.Area.Nombre = obj.NombreArea;
                           producto.Descripcion = obj.Descripcion;
                           producto.Imagen = Convert.ToString(obj.Imagen);
                           result.Objects.Add(producto);

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
       public static ML.Result GetByIdEF(int IdProducto)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var Obj = context.ProductoGetById(IdProducto).FirstOrDefault();
                   result.Objects = new List<object>();

                   if (Obj != null)
                   {
                       

                       ML.Producto producto = new ML.Producto();
                       producto.IdProducto = Obj.IdProducto;
                       producto.Nombre = Obj.Nombre;
                       producto.PrecioUnitario = Convert.ToDecimal(Obj.PrecioUnitario);
                       producto.Stock = Convert.ToInt16(Obj.Stock);
                       producto.Proveedor = new ML.Proveedor();
                       producto.Proveedor.IdProveedor = Convert.ToInt16(Obj.IdProveedor);
                       producto.Departamento = new ML.Departamento();
                       producto.Departamento.IdDepartamento = Convert.ToByte(Obj.IdDepartamento);
                       producto.Descripcion = Obj.Descripcion;
                       producto.Imagen = Convert.ToString(Obj.Imagen);
                       result.Objects.Add(producto);

                       result.Correct = true;
                       result.Object = producto;
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
       public static ML.Result AddLinq (ML.Producto producto)
       {
           ML.Result result = new ML.Result();
           try
           {
               using(DL_EF.NRojasProgramacionNCapasEntities1 context= new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   DL_EF.Producto productoDL= new DL_EF.Producto();
                   productoDL.Nombre = producto.Nombre;
                   productoDL.PrecioUnitario = producto.PrecioUnitario;
                   productoDL.Stock = producto.Stock;
                   productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                   productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                   productoDL.Descripcion = producto.Descripcion;

                   context.Productoes.Add(productoDL);
                   int RowsAffected = context.SaveChanges();

                   if (RowsAffected > 0)
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
       public static ML.Result UpdateLinq(ML.Producto producto)
     {
         ML.Result result = new ML.Result();
         try
         {

             using(DL_EF.NRojasProgramacionNCapasEntities1 context= new DL_EF.NRojasProgramacionNCapasEntities1())
             {
                 var query = (from a in context.Productoes
                              where a.IdProducto == producto.IdProducto
                              select a).SingleOrDefault();
                if(query != null)
                {
                    query.Nombre=producto.Nombre;
                    query.PrecioUnitario=producto.PrecioUnitario;
                    query.Stock=producto.Stock;
                    query.Proveedor.IdProveedor=producto.Proveedor.IdProveedor;
                    query.Departamento.IdDepartamento=producto.Departamento.IdDepartamento;
                    query.Descripcion=producto.Descripcion;
                    context.SaveChanges();
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontro el producto"+ producto.IdProducto;
                }
                   result.Correct = true;
             }
         }
           catch (Exception ex)
         {
             result.Correct = false;
             result.Ex = ex;
         }
         return result;
       }
       //EliminarLinq
       public static ML.Result DeleteLinq(ML.Producto producto)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query = (from a in context.Productoes
                                where a.IdProducto== producto.IdProducto
                                select a).First();
                   context.Productoes.Remove(query);
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
           catch (Exception ex)
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
               using(DL_EF.NRojasProgramacionNCapasEntities1 context=new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query= (from productoTable in context.Productoes
                               select
                               new
                               {
                                IdProducto=productoTable.IdProducto,
                                Nombre=productoTable.Nombre,
                                PrecioUnitario=productoTable.PrecioUnitario,
                                Stock=productoTable.Stock,
                                IdProveedor=productoTable.Proveedor.IdProveedor,
                                IdDepartamento=productoTable.Departamento.IdDepartamento,
                                Descripcion=productoTable.Descripcion,
                               }
                                   ).ToList();
                   result.Objects = new List<object>();

                   if (query.Count > 0)
                   {
                       foreach (var productoItem in query)
                       {
                           ML.Producto producto = new ML.Producto();

                                producto.IdProducto=productoItem.IdProducto;
                                producto.Nombre=productoItem.Nombre;
                                producto.PrecioUnitario = Convert.ToDecimal(productoItem.PrecioUnitario);
                                producto.Stock = Convert.ToInt16(productoItem.Stock);
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor= productoItem.IdProveedor;
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento=productoItem.IdDepartamento;
                                producto.Descripcion=productoItem.Descripcion;
                     
                           result.Objects.Add(producto);
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
       public static ML.Result GetByIdLinq(int IdProducto)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var ObjProducto = (from productoTable in context.Productoes
                                      where productoTable.IdProducto == IdProducto
                                     select
                                     new
                                     {
                                         IdProducto = productoTable.IdProducto,
                                         Nombre = productoTable.Nombre,
                                         PrecioUnitario = productoTable.PrecioUnitario,
                                         Stock = productoTable.Stock,
                                         IdProveedor = productoTable.Proveedor.IdProveedor,
                                         IdDepartamento = productoTable.Departamento.IdDepartamento,
                                         Descripcion = productoTable.Descripcion,
                                     }
                                     ).FirstOrDefault();

                   if (ObjProducto != null)
                   {
                       ML.Producto producto = new ML.Producto();
                       producto.IdProducto = ObjProducto.IdProducto;
                       producto.Nombre = ObjProducto.Nombre;
                       producto.PrecioUnitario = Convert.ToDecimal(ObjProducto.PrecioUnitario);
                       producto.Stock = Convert.ToInt16(ObjProducto.Stock);
                       producto.Proveedor = new ML.Proveedor();
                       producto.Proveedor.IdProveedor = ObjProducto.IdProveedor;
                       producto.Departamento = new ML.Departamento();
                       producto.Departamento.IdDepartamento = ObjProducto.IdDepartamento;
                       producto.Descripcion = ObjProducto.Descripcion;
                     
                       result.Object = producto;
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
