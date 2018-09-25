using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_DAL.Data
{
    /// <summary>
    /// Propriedades de cada Candidato
    /// </summary>
    public class CandidatoDB
    {
        public string Nif { get; set; }
        public string Nome { get; set; }
        public int Escolaridade { get; set; }
        public int id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Descricao { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ListaCandidatoDB : DataDB
    {
        public List<CandidatoDB> Lista { get; set; }
    }

}
