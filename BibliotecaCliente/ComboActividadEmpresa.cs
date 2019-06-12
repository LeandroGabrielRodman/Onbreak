using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaClases
{
    public class ComboActividadEmpresa
    {
        
            public int id { get; set; }
            public string texto { get; set; }

            public override string ToString()
            {
                return texto;
            }
        }
    }



