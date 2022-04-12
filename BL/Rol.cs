using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.NRojasProgramacionNCapasEntities1 context= new DL_EF.NRojasProgramacionNCapasEntities1())
                {
                    var roles = context.RolGetAll().ToList();

                    result.Objects = new List<Object>();

                   if (roles != null)
                    {
                      foreach (var obj in roles)
                         {
                            ML.Rol rol= new ML.Rol();

                              rol.IdRol = Convert.ToByte(obj.IdRol);
                              rol.Nombre = obj.Nombre;
                              result.Objects.Add(rol);
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
    }
}
