using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            ////SALUDO 
            //OperacionesService.OperacionesClient TestOperaciones= new OperacionesService.OperacionesClient();
            //var result = TestOperaciones.Saludar("Nayeli");
            //Console.WriteLine(result);

            ////SUMA 
            //OperacionesService.OperacionesClient TestOperaciones = new OperacionesService.OperacionesClient();
            //var result = TestOperaciones.Suma(1,2);
            //Console.WriteLine(result);

            ////Resta
            //OperacionesService.OperacionesClient TestOperaciones = new OperacionesService.OperacionesClient();
            //var result = TestOperaciones.Resta(2,1);
            //Console.WriteLine(result);

            ////Multiplicacion
            //OperacionesService.OperacionesClient TestOperaciones = new OperacionesService.OperacionesClient();
            //var result = TestOperaciones.Multiplicación(2, 1);
            //Console.WriteLine(result);

            ////División
            //OperacionesService.OperacionesClient TestOperaciones = new OperacionesService.OperacionesClient();
            //var result = TestOperaciones.División(20, 10);
            //Console.WriteLine(result);

            Console.WriteLine("MENU");
            Console.WriteLine("1.-Usuario");
            Console.WriteLine("2.-Producto");
            Console.WriteLine("Ingrese la operación que desea realizar");
            int opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Console.WriteLine("1.- Ingresar Usuario");
                    Console.WriteLine("2.- Actualizar Usuario");
                    Console.WriteLine("3.- Eliminar Usuairo");
                    Console.WriteLine("4.- Mostrar todos los registros");
                    Console.WriteLine("5.- Mostrar registros por ID");
                    int opc2 = int.Parse(Console.ReadLine());
                    switch (opc2)
                    {
                        case 1:
                            Usuario.Add();
                            break;
                        case 2:
                            Usuario.Update();
                            break;
                        case 3:
                            Usuario.Delete();
                            break;
                        case 4:
                            Usuario.GetAll();
                            break;
                        case 5:
                            Usuario.GetById();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("1.- Ingresar Producto");
                    Console.WriteLine("2.- Actualizar Producto");
                    Console.WriteLine("3.- Eliminar Producto");
                    Console.WriteLine("4.- Mostrar todos los Producto");
                    Console.WriteLine("5.- Mostrar registros por ID");
                    int opc3 = int.Parse(Console.ReadLine());
                    switch (opc3)
                    {
                        case 1:
                            Producto.Add();
                            break;
                        case 2:
                            Producto.Update();
                            break;
                        case 3:
                            Producto.Delete();
                            break;
                        case 4:
                            Producto.GetAll();
                            break;
                        case 5:
                            Producto.GetById();
                            break;
                    }
                    break;

            }
            Console.ReadLine();
        }
    }
}
