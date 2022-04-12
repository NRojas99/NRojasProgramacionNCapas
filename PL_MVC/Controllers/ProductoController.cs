using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/
        public ActionResult GetAll()
        {
            ML.Result result= BL.Producto.GetAllEF();
            ML.Producto producto = new ML.Producto();

            if (result.Correct)
            {
                producto.Productos = result.Objects;
                return View(producto);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al obtener la informacion" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto= new ML.Producto();

            producto.Proveedor = new ML.Proveedor();
            ML.Result resultProveedor = BL.Proveedor.GetAll();

            producto.Departamento = new ML.Departamento();
            ML.Result resultDepartamento = BL.Departamento.GetAll();
            producto.Departamento.Area = new ML.Area();
            ML.Result resultArea = BL.Area.GetAll();

            if (IdProducto == null)
            {
                producto.Proveedor.Proveedores = resultProveedor.Objects;
                producto.Departamento.Departamentos = resultDepartamento.Objects;
                producto.Departamento.Area.Areas = resultArea.Objects; 
                return View(producto);
            }
            else //UpDate 
            {
                ML.Result result = new ML.Result();

                result = BL.Producto.GetByIdEF(IdProducto.Value);

                if (result.Correct)
                {

                    producto = ((ML.Producto)result.Object);

                    producto.Proveedor.Proveedores = resultProveedor.Objects;
                    producto.Departamento.Departamentos = resultDepartamento.Objects;
                    producto.Departamento.Area.Areas = resultArea.Objects; 

                    return View(producto);
                }
            }
            return View("ValidationModal");
        }


        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            HttpPostedFileBase file = Request.Files["fuImagen"];

            if (file.ContentLength > 0)
            {
               //producto.Imagen = ConvertToBytes(file);
            }

            if (producto.IdProducto == 0)
            {
                result = BL.Producto.AddEF(producto);
                if (result.Correct)
                {
                    ViewBag.Message = "El producto se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Message = "El producto NO se pudo registrar correctamente ";
                }
            }
            else
            {
                result = BL.Producto.UpdateEF(producto);
                if (result.Correct)
                {
                    ViewBag.Message = "El producto se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "El producto no se ha actualizado correctamente";
                }
            }
            return PartialView("ValidationModal");
        }

        //Metodo de conversión de la imagen
        private byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);
            return data;
        }
        //Metodo para traer el DROPDOWNLIST en cascada
        public JsonResult GetDepartamento(byte IdArea)
        {
            var result = BL.Departamento.DepartamentoGetByIdArea(IdArea);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteEF(IdProducto);
            if (result.Correct)
            {
                ViewBag.Message = "El producto se a eliminado correctamente ";
            }
            else
            {
                ViewBag.Message = "El producto no se pudo eliminar correctamente";
            }
            return PartialView("ValidationModal");
        }
	}
}