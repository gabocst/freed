using Freed.Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.Models.persona
{
    [DataContract]
    public class personaReadResponse
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public String messageDetail { get; set; }

        [DataMember]
        public String messageException { get; set; }

        [DataMember]
        public personaDTO data { get; set; }

        public personaReadResponse(int code, String messageDetail, String messageException, personaDTO data)
        {
            this.code = code;
            this.messageDetail = messageDetail;
            this.messageException = messageException;
            this.data = data;
        }
    }
}