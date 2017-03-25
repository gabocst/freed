using Freed.Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.Models.factura
{
    [DataContract]
    public class facturaReadResponse
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public String messageDetail { get; set; }

        [DataMember]
        public String messageException { get; set; }

        [DataMember]
        public facturaDTO data { get; set; }

        public facturaReadResponse(int code, String messageDetail, String messageException, facturaDTO data)
        {
            this.code = code;
            this.messageDetail = messageDetail;
            this.messageException = messageException;
            this.data = data;
        }

    }
}