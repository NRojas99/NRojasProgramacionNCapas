using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
  public class Usuario
    {
      //Agregar
      public static void Add()
            {
                
                ML.Direccion direccion= new ML.Direccion();
                direccion.Usuario = new ML.Usuario();
                direccion.Colonia = new ML.Colonia();

                Console.WriteLine("Ingrese su UserName");
                direccion.Usuario.UserName = Console.ReadLine();

                Console.WriteLine("Ingrese el password");
                direccion.Usuario.Password = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del usuario");
                direccion.Usuario.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido paterno");
                direccion.Usuario.ApellidoPaterno = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido materno" );
                direccion.Usuario.ApellidoMaterno = Console.ReadLine();

                Console.WriteLine("Ingrese su Email");
                direccion.Usuario.Email = Console.ReadLine();

                Console.WriteLine("Ingrese su Fecha de Nacimiento");
                direccion.Usuario.FechaNacimiento = Console.ReadLine();

                Console.WriteLine("Ingrese su sexo F = Femenino M= Masculino");
                direccion.Usuario.Sexo = Console.ReadLine();

                Console.WriteLine("Ingrese su Telefono");
                direccion.Usuario.Telefono = Console.ReadLine();

                Console.WriteLine("Ingrese su celular");
                direccion.Usuario.Celular = Console.ReadLine();

                Console.WriteLine("Ingrese su CURP");
                direccion.Usuario.CURP = Console.ReadLine();

                Console.WriteLine("Ingrese su Estatus");
                direccion.Usuario.Estatus = bool.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese su Rol 1= Usuario 2= Administrador ");
                direccion.Usuario.Rol = new ML.Rol();//Inicializar Entidad
                direccion.Usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

                Console.WriteLine("**********************************");
                Console.WriteLine("DIRECCIÓN");
                Console.WriteLine("**********************************");
                Console.WriteLine("Ingrese la Calle");
                direccion.Calle = Console.ReadLine();
                Console.WriteLine("Ingrese el numero exterior");
                direccion.NumeroExterior = Console.ReadLine();
                Console.WriteLine("Ingrese el numero interior");
                direccion.NumeroInterior = Console.ReadLine();
                Console.WriteLine("Ingrese el id de la colonia");
                direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

                // ML.Result result= BL.Usuario.AddEF(direccion.Usuario); //QuerryEF
                //ML.Result result = BL.Usuario.AddLinq(direccion.Usuario);
                UsuarioService.UsuarioClient usuarioS= new UsuarioService.UsuarioClient();
                var result = usuarioS.Add(direccion.Usuario);

                if (result.Correct)
                {
                    direccion.Usuario.IdUsuario = ((int)result.Object);//UNBOXING
                    ML.Result resultDireccion = BL.Direccion.Add(direccion);
                    if(resultDireccion.Correct)
                    {
                        Console.WriteLine("Usuario Registrado exitosamente");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Ocurrio un eror al registrar la dirección");
                    }
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
                ML.Usuario Usu = new ML.Usuario();
                Console.WriteLine("Ingresa el ID del Usuario a actualizar");
                Usu.IdUsuario = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese su UserName");
                Usu.UserName = Console.ReadLine();

                Console.WriteLine("Ingrese el password");
                Usu.Password = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del usuario");
                Usu.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido paterno");
                Usu.ApellidoPaterno = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido materno");
                Usu.ApellidoMaterno = Console.ReadLine();

                Console.WriteLine("Ingrese su Email");
                Usu.Email = Console.ReadLine();

                Console.WriteLine("Ingrese su Fecha de Nacimiento");
                Usu.FechaNacimiento = Console.ReadLine();

                Console.WriteLine("Ingrese su sexo F = Femenino M= Masculino");
                Usu.Sexo = Console.ReadLine();

                Console.WriteLine("Ingrese su Telefono");
                Usu.Telefono = Console.ReadLine();

                Console.WriteLine("Ingrese su celular");
                Usu.Celular = Console.ReadLine();

                Console.WriteLine("Ingrese su Estatus");
                Usu.Estatus = bool.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese su CURP");
                Usu.CURP= Console.ReadLine();

                Console.WriteLine("Ingrese su Rol 1= Usuario 2= Administrador ");
                Usu.Rol = new ML.Rol();//Inicializar Entidad
                Usu.Rol.IdRol = byte.Parse(Console.ReadLine());

                ML.Result result = BL.Usuario.UpdateLinq(Usu); //Querry

                if (result.Correct)
                {
                    Console.WriteLine("Usuario actulizado exitosamente");
                }
                else
                {
                    Console.WriteLine("Ocurrio un Error al actulizar al usuario"+ result.ErrorMessage);
                }
            }
      //Eliminar
      public static void Delete()
      {
          ML.Direccion direccion = new ML.Direccion();

          Console.WriteLine("Ingresa el ID del Usuario que desea eliminar"); 
          direccion.Usuario = new ML.Usuario();
          direccion.Usuario.IdUsuario = int.Parse(Console.ReadLine());
          //ML.Result result = BL.Usuario.DeleteSP(Usu); //Querry
          ML.Result resultDireccion=BL.Direccion.GetByIdUsuario(direccion.Usuario.IdUsuario);

          ML.Direccion direccionItem = (ML.Direccion)resultDireccion.Object;

          ML.Result resultDelete = BL.Direccion.DeleteEF(direccionItem.IdDireccion);
          if (resultDelete.Correct)
          {
              ML.Result resultDeleteUsuario = BL.Usuario.DeleteLinq(direccion.Usuario.IdUsuario);
              if(resultDeleteUsuario.Correct)
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
              Console.WriteLine("Ocurrio un Error al eliminar al usuario");
          }
          
      }
      //Traer Todo 
      public static void GetAll()
      {
          //ML.Result result = BL.Usuario.GetAllEF();
          ML.Result result = BL.Usuario.GetAllLinq();
          if (result.Correct)
          {
               
              foreach(ML.Usuario usuario in result.Objects)
              {
                  Console.WriteLine("Id Usuario:"+ usuario.IdUsuario);
                  Console.WriteLine("UserName:" + usuario.UserName);
                  Console.WriteLine("Password:" + usuario.Password);
                  Console.WriteLine("Nombre:" + usuario.Nombre);
                  Console.WriteLine("Apellido Paterno:" + usuario.ApellidoPaterno);
                  Console.WriteLine("Apellido Materno:" + usuario.ApellidoMaterno);
                  Console.WriteLine("Email:" + usuario.Email);
                  Console.WriteLine("Fecha de Nacimiento" + usuario.FechaNacimiento);
                  Console.WriteLine("Sexo:" + usuario.Sexo);
                  Console.WriteLine("Telefono:" + usuario.Telefono);
                  Console.WriteLine("Celular:" + usuario.Celular);
                  Console.WriteLine("Estatus:" + usuario.Estatus);
                  Console.WriteLine("CURP:" + usuario.CURP);
                  Console.WriteLine("Rol:" + usuario.Rol.IdRol);
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
      //Traer por id
      public static void GetById()
      {
          ML.Usuario usuario = new ML.Usuario(); 
          Console.WriteLine("Ingresa el Id de usuario que desea buscar"); 
          usuario.IdUsuario=int.Parse(Console.ReadLine());
          //ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);
          ML.Result result = BL.Usuario.GetByIdLinq(usuario.IdUsuario); 
          if (result.Correct)
           {
             usuario = ((ML.Usuario)result.Object);

              Console.WriteLine("Id Usuario:" + usuario.IdUsuario);
              Console.WriteLine("UserName:" + usuario.UserName);
              Console.WriteLine("Password:" + usuario.Password);
              Console.WriteLine("Nombre:" + usuario.Nombre);
              Console.WriteLine("Apellido Paterno:" + usuario.ApellidoPaterno);
              Console.WriteLine("Apellido Materno:" + usuario.ApellidoMaterno);
              Console.WriteLine("Email:" + usuario.Email);
              Console.WriteLine("Fecha de Nacimiento" + usuario.FechaNacimiento);
              Console.WriteLine("Sexo:" + usuario.Sexo);
              Console.WriteLine("Telefono:" + usuario.Telefono);
              Console.WriteLine("Celular:" + usuario.Celular);
              Console.WriteLine("Estatus:" + usuario.Estatus);
              Console.WriteLine("CURP:" + usuario.CURP);
              Console.WriteLine("Rol:" + usuario.Rol.IdRol);
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
