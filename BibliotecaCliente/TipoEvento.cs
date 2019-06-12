using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;
namespace BibliotecaClases
{
    
    public class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public String Descripcion { get; set; }
        public TipoEvento()
        {

        }
        private OnBreakEntities1 bdd = new OnBreakEntities1();
        public List<TipoEvento> listar()
        {
            try
            {
                var lis = bdd.TipoEvento.ToList();
                List<TipoEvento> lista = new List<TipoEvento>();
                foreach (var item in lis)
                {
                    TipoEvento TpEv = new TipoEvento();
                    TpEv.IdTipoEvento = item.IdTipoEvento;
                    TpEv.Descripcion = item.Descripcion;
                    lista.Add(TpEv);
                }
                return lista;
            }
            catch (Exception ex)
            {

               return null;
            }
        } 
    }
}
