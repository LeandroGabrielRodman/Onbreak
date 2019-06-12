using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;


namespace BibliotecaClases
{
    public class ActividadEmpresa
    {
        public int idactividadEmpresa { get; set; }
        public string Descripcion { get; set; }

        private OnBreakEntities1 bdd = new OnBreakEntities1();

        public override string ToString()
        {
            return this.Descripcion;
        }

        public ActividadEmpresa()
        {

        }

        public List<ActividadEmpresa>listar()
        {
            try
            {
                var list = bdd.ActividadEmpresa.ToList();
                List<ActividadEmpresa> Lista = new List<ActividadEmpresa>();
                foreach (var item in list)
                {
                    ActividadEmpresa AE = new ActividadEmpresa();
                    AE.idactividadEmpresa = item.IdActividadEmpresa;
                    AE.Descripcion = item.Descripcion;

                    Lista.Add(AE);

                }
                return Lista;
                 
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool Read()
        {
            try
            {
                BibliotecaDALC.ActividadEmpresa act = bdd.ActividadEmpresa.First(x => x.IdActividadEmpresa == idactividadEmpresa);
                Descripcion = act.Descripcion;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

}
