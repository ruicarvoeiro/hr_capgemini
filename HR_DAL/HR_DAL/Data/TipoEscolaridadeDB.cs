using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_DAL.Data
{
    public class TipoEscolaridadeDB
    {
        public string Descricao { get; set; }
        public int id { get; set; }
    }
    public class ListaTipoEscolaridadeDB : DataDB
    {
        public List<TipoEscolaridadeDB> Lista { get; set; }
    }
}
