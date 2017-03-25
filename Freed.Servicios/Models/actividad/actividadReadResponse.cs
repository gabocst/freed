using Freed.Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.Models.actividad
{
    [DataContract]
    public class actividadReadResponse
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public String messageDetail { get; set; }

        [DataMember]
        public String messageException { get; set; }

        [DataMember]
        public actividadDTO data { get; set; }

        public actividadReadResponse(int code, String messageDetail, String messageException, actividadDTO data)
        {
            this.code = code;
            this.messageDetail = messageDetail;
            this.messageException = messageException;
            this.data = data;
        }
    }
}