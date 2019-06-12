using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class ComboTipoEmpresa
    {
        public int id { get; set; }
        public String texto { get; set; }

        public override string ToString()
        {
            return texto;
        }
    }
}
