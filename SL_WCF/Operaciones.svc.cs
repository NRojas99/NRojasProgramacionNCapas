using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public void DoWork()
        {
        }
        public string Saludar(string nombre)
        {
            return "Hola, mucho gusto " + nombre;
        }
        public int Suma(int x, int y)
        {
            return x + y;
        }
        public int Resta(int x, int y)
        {
            return x - y;
        }
        public int Multiplicación(int x, int y)
        {
            return x * y;
        }
        public int División(int x, int y)
        {
            return x / y;
        }
    }
}
