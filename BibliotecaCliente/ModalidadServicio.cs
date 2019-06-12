using BibliotecaDALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class ModalidadServicio
    {
        public String IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public String Nombre { get; set; }
        public Double ValorBase { get; set; }
        public int PersonalBase { get; set; }
        public ModalidadServicio()
        {

        }
        private OnBreakEntities1 bdd = new OnBreakEntities1();
        public List<ModalidadServicio> ListaMod()
        {
            try
            {
                var x = bdd.ModalidadServicio.ToList();
                List<ModalidadServicio> ListaMod = new List<ModalidadServicio>();
                foreach (BibliotecaDALC.ModalidadServicio item in x)
                {
                    ModalidadServicio mod = new ModalidadServicio();
                    CommonBC.Syncronize(item, mod);
                    ListaMod.Add(mod);
                }
                return ListaMod.ToList();
            }
            catch (Exception exe)
            {
                throw new ArgumentException(exe.Message);
            }
        }
    }
}
