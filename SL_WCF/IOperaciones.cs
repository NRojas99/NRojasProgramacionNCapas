using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        string Saludar(string nombre);

        [OperationContract]
        int Suma(int x, int y);

        [OperationContract]
        int Resta(int x, int y);

        [OperationContract]
        int Multiplicación(int x, int y);

        [OperationContract]
        int División(int x, int y);
    }
}
