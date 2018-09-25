using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_DAL.Data
{
    /// <summary>
    /// Propriedades das Entrevistas
    /// </summary>
    public class EntrevistasDB
    {
        public string Descricao { get; set; }
        public int IdEntrevista { get; set; }
        public DateTime DataHora { get; set; }
        public int Id { get; set; }
        public string EscaDescricao { get; set; }
        public string EntDescricao { get; set; }
        public string Nota { get; set; }
        public string Nome { get; set; }
        public int CandidatoId { get; set; }
        public CandidatoDB candidato { get; set; }
        public EscalaAvaliacaoDB escalaAvaliacao { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ListaEntrevistasDB : DataDB
    {
        public List<EntrevistasDB> Lista { get; set; }
    }
}
