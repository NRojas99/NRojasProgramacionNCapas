using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.NRojasProgramacionNCapasEntities1 context = new DL_EF.NRojasProgramacionNCapasEntities1())
                {
                    var areas = context.AreaGetall().ToList();

                    result.Objects = new List<Object>();

                    if (areas != null)
                    {
                        foreach (var obj in areas)
                        {
                            ML.Area area = new ML.Area();

                            area.IdArea = obj.IdArea;
                            area.Nombre = obj.Nombre;

                            result.Objects.Add(area);
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
