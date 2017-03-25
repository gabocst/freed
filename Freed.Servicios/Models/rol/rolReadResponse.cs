using Freed.Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.Models.rol
{
    [DataContract]
    public class rolReadResponse
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public String messageDetail { get; set; }

        [DataMember]
        public String messageException { get; set; }

        [DataMember]
        public rolDTO data { get; set; }

        [DataMember]
        public List<permisoDTO> permisos { get; set; }

        public rolReadResponse(int code, String messageDetail, String messageException, rolDTO data, List<permisoDTO> permisos)
        {
            this.code = code;
            this.messageDetail = messageDetail;
            this.messageException = messageException;
            this.data = data;
            this.permisos = permisos;
        }
    }
}