using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        List<User> users = new List<User>();
        int nextId = 0;


        public int Connect(string name)
        {
            User user = new User() {
                ID = nextId,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextId++;

            SendMessage(user.Name + " connected");
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMessage(user.Name + "is disconnected");
            }
        }

        public void SendMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
