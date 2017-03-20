using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freed.Servicios.Utils
{
    [Serializable]
    public class responseClass
    {
        public int code { get; set; }
        public Nullable<int> id { get; set; }
        public String messageDetail { get; set; }
        public String messageException { get; set; }


        public responseClass(int code, int? id, String messageDetail, String messageException)
        {
            this.code = code;
            this.id = id;
            this.messageDetail = messageDetail;
            this.messageException = messageException;
        }
        
    }
}