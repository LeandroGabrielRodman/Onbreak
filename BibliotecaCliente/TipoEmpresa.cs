using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;

namespace BibliotecaClases
{
   public class TipoEmpresa
    {
        public int idTipoEmpresa { get; set; }
        public string Descripcion { get; set; }

        private OnBreakEntities1 bdd = new OnBreakEntities1();
        


        public List<TipoEmpresa> listar()
        {
            try
            {
                var list = bdd.TipoEmpresa.ToList();
                List<TipoEmpresa> Lista = new List<TipoEmpresa>();
                foreach (var item in list)
                {
                    TipoEmpresa TE = new TipoEmpresa();
                    TE.idTipoEmpresa = item.IdTipoEmpresa;
                    TE.Descripcion = item.Descripcion;

                    Lista.Add(TE);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


    }
}
