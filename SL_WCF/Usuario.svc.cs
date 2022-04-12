using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Usuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Usuario.svc or Usuario.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {
        public void DoWork()
        {
        }
        public SL_WCF.Result Add(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);
            return new Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,

            };
        }
        public SL_WCF.Result Update(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEF(usuario);
            return new Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,

            };
        }
        public SL_WCF.Result Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);
            return new Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,

            };
        }
        public SL_WCF.Result GetAll()
        {
            
            ML.Usuario usuario = new ML.Usuario();

            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre; // Operador Tersario 
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

            ML.Result result = BL.Usuario.GetAllEF(usuario);
            return new Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,

            };
        }
        public SL_WCF.Result GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);
            return new Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects,

            };
        }

    }
}
