using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public double Uf()
        {

            ClDatos datos;
            // crea peticion
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(@"https://mindicador.cl/api/uf");
            //recupera
            HttpWebResponse response =
                (HttpWebResponse)request.GetResponse();
            //recive
            Stream stream = response.GetResponseStream();
            //la lee hasta que la recupere
            StreamReader stream_reader = new StreamReader(stream);
            //se carga todos los datos
            var json = stream_reader.ReadToEnd();
            //y luego se convierte
            datos = JsonConvert.DeserializeObject<ClDatos>(json);

            String uf = "";
            foreach (Serie item in datos.serie)
            {
                uf = item.valor;
            }
            uf = uf.Replace('.', ',');
            
            double valor_uf = double.Parse(uf);
            return valor_uf;
        }
    }
}
