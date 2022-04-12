using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class Departamento
    {
       public static ML.Result AddEF(ML.Departamento departamento)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query = context.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);
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
       public static ML.Result UpdateEF(ML.Departamento departamento)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query = context.DepartamentoUpdate(departamento.IdDepartamento,departamento.Nombre,departamento.Area.IdArea);
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
       public static ML.Result DeleteEF(byte IdDepartamento)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query = context.DepartamentoDelete(IdDepartamento);
                   if (query >= 1)
                   {
                       result.Correct = true;
                   }
                   else
                   {
                       result.Correct = false;
                       result.ErrorMessage = "Error al Borrar Departamento";
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
       public static ML.Result GetAll()
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var departamentos = context.DepartamentoGetAll().ToList();

                   result.Objects = new List<Object>();

                   if (departamentos != null)
                   {
                       foreach (var obj in departamentos)
                       {
                           ML.Departamento departamento = new ML.Departamento();

                           departamento.IdDepartamento = Convert.ToByte(obj.IdDepartamento);
                           departamento.Nombre= obj.Nombre;
                           departamento.Area = new ML.Area();
                           departamento.Area.IdArea = Convert.ToByte(obj.IdArea);
                           departamento.Area.Nombre = obj.NombreArea;

                           result.Objects.Add(departamento);
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
               result.Ex = ex;
           }

           return result;
       }
       public static ML.Result GetByIdEF(byte IdDepartamento)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var obj = context.DepartamentoGetById(IdDepartamento).FirstOrDefault();
                   result.Objects = new List<object>();

                   if (obj != null)
                   {


                       ML.Departamento departamento= new ML.Departamento();
                       departamento.IdDepartamento = Convert.ToByte(obj.IdDepartamento);
                       departamento.Nombre = obj.Nombre;
                       departamento.Area = new ML.Area();
                       departamento.Area.IdArea = Convert.ToByte(obj.IdArea);


                       result.Correct = true;
                       result.Object = departamento;
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
       public static ML.Result DepartamentoGetByIdArea(byte IdArea)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
               {
                   var query = context.DepartamentoGetByIdArea(IdArea).ToList();
                   result.Objects = new List<object>();

                   if (query != null)
                   {
                       result.Objects = new List<object>();
                       foreach (var obj in query)
                       {
                           ML.Departamento departamento = new ML.Departamento();
                           departamento.IdDepartamento = obj.IdDepartamento;
                           departamento.Nombre = obj.Nombre;
                           departamento.Area = new ML.Area();
                           departamento.Area.IdArea =obj.IdArea;

                           result.Objects.Add(departamento);
                       }
                       result.Correct = true;
                   }

                   else
                   {
                       result.Correct = false;
                       result.ErrorMessage = "Error No Existen Registros";
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
    }
}
