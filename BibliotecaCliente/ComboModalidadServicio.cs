using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;
namespace BibliotecaClases
{
    public class ComboModalidadServicio
    {
        public String IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public String Nombre { get; set; }
        public Double ValorBase { get; set; }
        public int PersonalBase { get; set; }
        public ComboModalidadServicio()
        {

        }
        private OnBreakEntities1 bdd = new OnBreakEntities1();
        public List<ModalidadServicio> ModServ(int IdTpEvnto)
        {
            try
            {
                var lis = bdd.ModalidadServicio.ToList();
                var x = from TpEvnto in bdd.TipoEvento
                        join ModSer in bdd.ModalidadServicio
                            on TpEvnto.IdTipoEvento equals ModSer.IdTipoEvento
                        where TpEvnto.IdTipoEvento == IdTpEvnto
                        select new ModalidadServicio()
                        {
                            IdModalidad=ModSer.IdModalidad,
                            IdTipoEvento=TpEvnto.IdTipoEvento,
                            Nombre=ModSer.Nombre,
                            ValorBase=ModSer.ValorBase,
                            PersonalBase=ModSer.PersonalBase,
                        };
                return x.ToList();     
            }
            catch (Exception ex)
            {

                return null; 
            }
        }
        public override string ToString()
        {
            return Nombre.Trim();
        }
    }
}
