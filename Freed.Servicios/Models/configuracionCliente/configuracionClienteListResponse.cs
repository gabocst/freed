using Freed.Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.Models.configuracionCliente
{
    [DataContract]
    public class configuracionClienteListResponse
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public String messageDetail { get; set; }

        [DataMember]
        public String messageException { get; set; }

        [DataMember]
        public List<configuracionClienteDTO> data { get; set; }

        public configuracionClienteListResponse(int code, String messageDetail, String messageException, List<configuracionClienteDTO> data)
        {
            this.code = code;
            this.messageDetail = messageDetail;
            this.messageException = messageException;
            this.data = data;
        }
    }
}