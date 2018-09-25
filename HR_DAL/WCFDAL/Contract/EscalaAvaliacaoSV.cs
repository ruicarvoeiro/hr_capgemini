using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFDAL.Contract
{
    [DataContract]
    public class EscalaAvaliacaoSV
    {
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string Nota { get; set; }
        [DataMember]
        public int id { get; set; }
    }
    public class ListaEscalaAvaliacaoSV : DataSV
    {
        public List<EscalaAvaliacaoSV> Lista { get; set; }
    }
}