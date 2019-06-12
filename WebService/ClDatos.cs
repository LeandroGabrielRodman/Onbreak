using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class ClDatos
    {
        public String version { get; set; }
        public String autor { get; set; }
        public String codigo { get; set; }
        public String Nombre { get; set; }
        public String unidad_medida { get; set; }
        public List<Serie> serie { get; set; }
        public ClDatos()
        {

        }
    }
    public class Serie
    {
        public String fecha { get; set; }
        public String valor { get; set; }

        public Serie()
        {

        }
    }
}