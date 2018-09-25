using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_DAL.Data
{
    public class EscalaAvaliacaoDB
    {
        public string Descricao { get; set; }
        public string Nota { get; set; }
        public int id { get; set; }
    }
    public class ListaEscalaAvaliacaoDB : DataDB
    {
        public List<EscalaAvaliacaoDB> Lista { get; set; }
    }
}
