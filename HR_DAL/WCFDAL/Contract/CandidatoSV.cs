using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFDAL.Contract
{
    [DataContract]
    public class CandidatoSV
    {
        [DataMember(IsRequired = true)]
        public string Nif { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public int Escolaridade { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public DateTime DataNascimento { get; set; }

    }
    [DataContract]
    public class ListaCandidatoSV : DataSV
    {
        [DataMember]
        public List<CandidatoSV> Lista { get; set; }
    }
}
