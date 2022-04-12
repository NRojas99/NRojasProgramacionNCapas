using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        public ActionResult GetAll()
        {
            ML.Result result = BL.Direccion.GetAllEF();
            //ML.Usuario usuario = new ML.Usuario();
            ML.Direccion direccion = new ML.Direccion();

            if (result.Correct)
            {
                direccion.Direcciones = result.Objects;
                return View(direccion);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al obtener la informacion" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
        }


         [HttpGet]
        public ActionResult Form (int? IdUsuario)
        {
            ML.Direccion direccion = new ML.Direccion();

            direccion.Usuario = new ML.Usuario();
            direccion.Colonia = new ML.Colonia();
            //ML.Result resultColonia= BL.Colonia.GetAll();
            direccion.Colonia.Municipio = new ML.Municipio();
            direccion.Colonia.Municipio.Estado = new ML.Estado();
            direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            ML.Result resultPaises = BL.Pais.GetAllEF();
            direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

            direccion.Usuario.Rol = new ML.Rol();
            ML.Result resultRol = BL.Rol.GetAll();
            


            if (IdUsuario == null)
            {

                ML.Result resultEstados = BL.Estado.EstadoGetByIdPais(direccion.Colonia.Municipio.Estado.Pais.IdPais);
                ML.Result resultMunicipios = BL.Municipio.MunicipioGetByIdEstado(direccion.Colonia.Municipio.Estado.IdEstado);
                ML.Result resultColonias = BL.Colonia.ColoniaGetByIdMunicipio(direccion.Colonia.Municipio.IdMunicipio);
                ML.Result resultDirecciones = BL.Direccion.DireccionGetByIdColonia(direccion.Colonia.IdColonia);

                direccion.Usuario.Rol.Roles = resultRol.Objects;
                direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                direccion.Colonia.Colonias = resultColonias.Objects;
                return View(direccion);
            }
            else //Update 
            {
                
                ML.Result result = BL.Direccion.GetByIdUsuario(IdUsuario.Value); /// agregar imagen en este metodo
                if (result.Correct)
                {

                    
                    //direccion.Colonia.Colonias = resultColonia.Objects;

                    direccion.Colonia = new ML.Colonia();
                    direccion.Colonia.Municipio = new ML.Municipio();
                    direccion.Colonia.Municipio.Estado = new ML.Estado();
                    direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                    direccion = ((ML.Direccion)result.Object);

                    ML.Result resultEstados = BL.Estado.EstadoGetByIdPais(direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Result resultMunicipios = BL.Municipio.MunicipioGetByIdEstado(direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultColonias = BL.Colonia.ColoniaGetByIdMunicipio(direccion.Colonia.Municipio.IdMunicipio);
                    ML.Result resultDirecciones = BL.Direccion.DireccionGetByIdColonia(direccion.Colonia.IdColonia);

                    direccion.Usuario.Rol.Roles = resultRol.Objects;
                    direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
                    direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                    direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                    direccion.Colonia.Colonias = resultColonias.Objects;
                    
                    return View(direccion);
                }
            }
            return View("ValidationModal");
        }


         [HttpPost]
        public ActionResult Form(ML.Direccion direccion)
       {

           HttpPostedFileBase file = Request.Files["fuImagen"];

             if(file.ContentLength > 0)
             {
                 //direccion.Usuario.Imagen = ConvertToBytes(file);
             }

        if (direccion.Usuario.IdUsuario== 0)
         {
            ML.Result result = BL.Usuario.AddEF(direccion.Usuario);

             if (result.Correct)
             {
                 direccion.Usuario.IdUsuario = ((int)result.Object);
                 ML.Result resultDireccion = BL.Direccion.AddEF(direccion);

                 if (resultDireccion.Correct)
                 {
                     ViewBag.Message = "El usuario se ha registrado correctamente";
                 }
                 else
                 {
                     ViewBag.Message = "El usuario NO se pudo registrar correctamente ";
                 }
             }
             else
             {
                 ViewBag.Message = "Error al intentar ingresar al usuario" + result.ErrorMessage;
             }
         }
         else //Update
         {
             ML.Result resultU = BL.Usuario.UpdateEF(direccion.Usuario);
             
             if(resultU.Correct)
             {
                 ViewBag.Message="Los datos del usuario se ha actualizado correctamente";
                 ML.Result resultDireccion = BL.Direccion.UpdateEF(direccion);
                
                 if (resultDireccion.Correct)
                 {
                     ViewBag.Message = "La dirección del usuario se ha registrado correctamente";
                 }
             }
             else
             {
                 ViewBag.Message = "El Usuario no se ha actualizado correctamente";
             }
         }
         return PartialView("ValidationModal");
       }

         private byte[] ConvertToBytes(HttpPostedFileBase Imagen)
         {
             byte[] data = null;
             System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
             data = reader.ReadBytes((int)Imagen.ContentLength);
             return data;
         }


        public JsonResult GetEstado(int IdPais)
         {
             var result = BL.Estado.EstadoGetByIdPais(IdPais);
             return Json(result.Objects, JsonRequestBehavior.AllowGet);
         }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Delete(int IdUsuario)
         {
            ML.Direccion direccion = new ML.Direccion();

            ML.Result resultDireccion = BL.Direccion.GetByIdUsuario(IdUsuario);

            ML.Direccion direccionItem = (ML.Direccion)resultDireccion.Object;
            ML.Result resultDelete = BL.Direccion.DeleteEF(direccionItem.IdDireccion);

            if (resultDelete.Correct)
            {
                ML.Result resultDeleteUsuario = BL.Usuario.DeleteEF(IdUsuario);
                if (resultDeleteUsuario.Correct)
                {
                    Console.WriteLine("Alumno Eliminado correctamente");
                }
                else
                {
                    Console.WriteLine("Ocurrio un Error al eliminar al usuario");
                }
            }
            else
            {
                ViewBag.Message = "El Usuario no se pudo eliminar correctamente";
            }
            return PartialView("ValidationModal");
         }
	}
}