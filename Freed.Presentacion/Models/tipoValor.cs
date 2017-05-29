using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freed.Presentacion.Models
{
    public class tipoValor
    {
        public string nombre { get; set; }

        public List<tipoValor> get_types()
        {
            List<tipoValor> types = new List<tipoValor>
            {
            new tipoValor{nombre="string"},
            new tipoValor{nombre="datetime"},
            new tipoValor{nombre="int"},
            new tipoValor{nombre="bool"},
            new tipoValor{nombre="List(Pais)"}
            };

            return types;
        }
    }
}