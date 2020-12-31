using System.Runtime.Serialization;
using System;

namespace Client_Server
{
    [DataContract]
    public class UserData
    {
        [DataMember]
        public string Id;

        [DataMember]
        public readonly string Message;

        [DataMember]
        public readonly string Time;

        public UserData(string id, string transletedString)
        {
            Id = id;
            Message = transletedString;
            Time = DateTime.Now.ToShortTimeString();
        }
    }
}
