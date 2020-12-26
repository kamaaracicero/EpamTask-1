using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceChat
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract]
        void SendMessage(string msg);
    }

    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string msg);
    }
}
