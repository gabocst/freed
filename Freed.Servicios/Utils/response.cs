using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.Utils
{
    [DataContract]
    public class response
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public string data { get; set; }

        [DataMember]
        public String messageDetail { get; set; }

        [DataMember]
        public String messageException { get; set; }


        public response(int code, string data, String messageDetail, String messageException)
        {
            this.code = code;
            this.data = data;
            this.messageDetail = messageDetail;
            this.messageException = messageException;


        }
    }
}