﻿using Freed.Servicios.DAL;
using Freed.Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freed.Servicios.Models.grupo
{
    [DataContract]
    public class grupoListResponse
    {
        [DataMember]
        public int code { get; set; }

        [DataMember]
        public String messageDetail { get; set; }

        [DataMember]
        public String messageException { get; set; }

        //[DataMember]
        //public List<grupoDTO> data { get; set; }

        [DataMember]
        public string data { get; set; }

        public grupoListResponse(int code, String messageDetail, String messageException, string data)
        {
            this.code = code;
            this.messageDetail = messageDetail;
            this.messageException = messageException;
            this.data = data;
        }
    }
}