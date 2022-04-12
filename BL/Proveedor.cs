using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
                {
                    var proveedores = context.ProveedorGetAll().ToList();

                    result.Objects = new List<Object>();

                    if (proveedores != null)
                    {
                        foreach (var obj in proveedores)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();

                            proveedor.IdProveedor= Convert.ToInt16(obj.IdProveedor);
                            proveedor.Nombre = obj.Nombre;
                            proveedor.Telefono = obj.Telefono;
                            result.Objects.Add(proveedor);
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
