using System.Runtime.Serialization;
using System;

namespace Client_Server
{
    /// <summary>
    /// User message data
    /// </summary>
    [DataContract]
    public struct UserData
    {
        /// <summary>
        /// User id
        /// </summary>
        [DataMember]
        public string Id;

        /// <summary>
        /// User message
        /// </summary>
        [DataMember]
        public readonly string Message;

        /// <summary>
        /// Message time
        /// </summary>
        [DataMember]
        public readonly string Time;

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="message">User message</param>
        public UserData(string id, string message)
        {
            Id = id;
            Message = message;
            Time = DateTime.Now.ToShortTimeString();
        }
    }
}
