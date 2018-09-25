using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_DAL.Data
{
    /// <summary>
    /// Propriedades de Erro
    /// </summary>
    public abstract class DataDB
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }

}
