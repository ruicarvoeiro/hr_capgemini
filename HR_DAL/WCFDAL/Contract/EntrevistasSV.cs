using HR_DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFDAL.Contract
{
    [DataContract]
    public class EntrevistasSV
    {
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Nota { get; set; }
        [DataMember]
        public string EscaDescricao { get; set; }
        [DataMember]
        public string EntDescricao { get; set; }
        [DataMember]
        public int IdEntrevista { get; set; }
        [DataMember]
        public DateTime DataHora { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CandidatoId { get; set; }
        [DataMember]
        public CandidatoSV candidato { get; set; }
        [DataMember]
        public EscalaAvaliacaoSV escalaAvaliacao { get; set; }
    }
    public class ListaEntrevistasSV : DataSV
    {
        public List<EntrevistasSV> Lista { get; set; }
    }
}