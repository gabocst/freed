using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freed.Servicios.Utils
{
    [Serializable]
    public class response
    {
        public int code { get; set; }
        public string data { get; set; }
        public String messageDetail { get; set; }
        public String messageException { get; set; }


        public response(int code, string data, String messageDetail, String messageException)
        {
            this.code = code;
            /*List<grupoDTO> listGroup = (List<grupoDTO>)js.Deserialize(json, typeof(List<grupoDTO>));*/
            this.data = data;
            this.messageDetail = messageDetail;
            this.messageException = messageException;


        }
    }
}