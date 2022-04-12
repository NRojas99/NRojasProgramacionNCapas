using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        //Agregar
        public static void Add()
        {

            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio unitario del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su Descripcion");
            producto.Descripcion= Console.ReadLine();

            //ML.Result result = BL.Producto.AddSP(producto); //Querry
            // ML.Result result = BL.Producto.AddEF(producto); //Querry
            ML.Result result = BL.Producto.AddLinq(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto Registrado exitosamente");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ocurrio un Error al resgitrar al usuario");
                Console.ReadLine();
            }
        }
        //Actualizar
        public static void Update()
            {
                ML.Producto producto = new ML.Producto();
                Console.WriteLine("Ingresa el ID del Producto a actualizar");
               producto.IdProducto= int.Parse(Console.ReadLine());

               Console.WriteLine("Ingrese el nombre del producto");
               producto.Nombre = Console.ReadLine();

               Console.WriteLine("Ingrese el precio unitario del producto");
               producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

               Console.WriteLine("Ingrese el Stock del producto");
               producto.Stock = int.Parse(Console.ReadLine());

               Console.WriteLine("Ingrese el Id del proveedor");
               producto.Proveedor = new ML.Proveedor();
               producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

               Console.WriteLine("Ingrese el Id del departamento");
               producto.Departamento = new ML.Departamento();
               producto.Departamento.IdDepartamento = byte.Parse(Console.ReadLine());

               Console.WriteLine("Ingrese su Descripcion");
               producto.Descripcion = Console.ReadLine();

               ML.Result result = BL.Producto.UpdateLinq(producto); //Querry

               if (result.Correct)
               {
                   Console.WriteLine("Producto Actualizado exitosamente");
                   Console.ReadLine();
               }
               else
               {
                   Console.WriteLine("Ocurrio un Error al resgitrar al usuario");
                   Console.ReadLine();
               }
            }
        //Borrar
        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("Ingresa el ID del Producto que desea eliminar");
              producto.IdProducto= int.Parse(Console.ReadLine());
              ML.Result result = BL.Producto.DeleteLinq(producto); //Querry
            if (result.Correct)
            {
                Console.WriteLine("Producto Eliminado exitosamente");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ocurrio un Error al eliminar el producto");
                Console.ReadLine();
            }
        }
        //Traer todo
        public static void GetAll()
        {
            //ML.Result result = BL.Producto.GetAllEF();
             ML.Result result = BL.Producto.GetAllLinq();
             if (result.Correct)
             {     
                foreach(ML.Producto producto in result.Objects)
                {
                  Console.WriteLine("Id Producto:"+ producto.IdProducto );
                  Console.WriteLine("Nombre:" + producto.Nombre );
                  Console.WriteLine("Precio Unitario:" + producto.PrecioUnitario);
                  Console.WriteLine("Stock:" + producto.Stock );
                  Console.WriteLine("Id Proveedor:" + producto.Proveedor.IdProveedor );
                  Console.WriteLine("Id Departamento:" +producto.Departamento.IdDepartamento );
                  Console.WriteLine("Descripciòn:" +producto.Descripcion );
                  Console.WriteLine("................................................");
                  Console.WriteLine();
               }
                 Console.ReadLine();
             }
          else
          {
              Console.WriteLine("Ocurrio un error"+result.ErrorMessage);
          }
       }
        //Traer por ID
        public static void GetById()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el Id de usuario que desea buscar");
            producto.IdProducto = int.Parse(Console.ReadLine());
            //ML.Result result = BL.Producto.GetByIdEF(producto.IdProducto);
            ML.Result result = BL.Producto.GetByIdLinq(producto.IdProducto);
            if (result.Correct)
            {
                producto = ((ML.Producto)result.Object);

                Console.WriteLine("Id Producto:" + producto.IdProducto);
                Console.WriteLine("Nombre:" + producto.Nombre);
                Console.WriteLine("Precio Unitario:" + producto.PrecioUnitario);
                Console.WriteLine("Stock:" + producto.Stock);
                Console.WriteLine("Id Proveedor:" + producto.Proveedor.IdProveedor);
                Console.WriteLine("Id Departamento:" + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripciòn:" + producto.Descripcion);
                Console.WriteLine("................................................");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ocurrio un Error al buscar al usuario");
                Console.ReadLine();
            }
        }

    }
}
