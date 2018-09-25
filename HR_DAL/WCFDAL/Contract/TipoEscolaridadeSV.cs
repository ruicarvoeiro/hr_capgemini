using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFDAL.Contract
{
    [DataContract]
    public class TipoEscolaridadeSV
    {
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public int id { get; set; }
    }
    public class ListaTipoEscolaridadeSV : DataSV
    {
        public List<TipoEscolaridadeSV> Lista { get; set; }
    }
}