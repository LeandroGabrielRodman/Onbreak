using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;




namespace BibliotecaClases

{
    public class Contrato
    {

        //Propiedades
        private String _numero;
        private DateTime _creacion;
        private DateTime _termino;
        private String _rutcliente;
        private String _idmodalidad;
        private int _idtipoevento;
        private DateTime _fechahorainicio;
        private DateTime _fechahoratermino;
        private int _asistentes;
        private int _personaladicional;
        private bool _realizado;
        private double _valortotalcontrato;
        //public String Direccion { get; set; }
        private String _observaciones;

        public String Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public DateTime Creacion
        {
            get { return _creacion; }
            set { _creacion = value; }
        }
        public DateTime Termino
        {
            get { return _termino; }
            set { _termino = value; }
        }
        public String RutCliente
        {
            get { return _rutcliente; }
            set { _rutcliente = value; }
        }
        public String IdModalidad
        {
            get { return _idmodalidad; }
            set { _idmodalidad = value; }
        }
        public int IdTipoEvento
        {
            get { return _idtipoevento; }
            set { _idtipoevento = value; }
        }
        public DateTime FechaHoraInicio
        {
            get { return _fechahorainicio; }
            set { _fechahorainicio = value; }
        }
        public DateTime FechaHoraTermino
        {
            get { return _fechahoratermino; }
            set { _fechahoratermino = value; }
        }
        public int Asistentes
        {
            get { return _asistentes; }
            set { _asistentes = value; }
        }
        public int PersonalAdicional
        {
            get { return _personaladicional; }
            set { _personaladicional = value; }
        }
        public bool Realizado
        {
            get { return _realizado; }
            set { _realizado = value; }
        }
        public double ValorTotalContrato
        {
            get { return _valortotalcontrato; }
            set { _valortotalcontrato = value; }
        }
        public String Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }


        public Contrato()
        {

        }

        private OnBreakEntities1 bdd = new OnBreakEntities1();

        public Boolean Guardar()
        {
            try
            {
                BibliotecaDALC.Contrato contr = new BibliotecaDALC.Contrato();
                CommonBC.Syncronize(this, contr);
                bdd.Contrato.Add(contr);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);

            }
        }

        public List<Contrato> Buscar(string NroContrato)
        {
            try
            {
                var List = bdd.Contrato.ToList();
                List<Contrato> Contract = new List<Contrato>();
                foreach (var item in List)
                {
                    if (item.Numero.Equals((NroContrato)))
                    {
                        Contrato Conn = new Contrato();
                        Conn.Numero = item.Numero;
                        Conn.Creacion = item.Creacion;
                        Conn.Termino = item.Termino;
                        Conn.RutCliente = item.RutCliente;
                        Conn.IdModalidad = item.IdModalidad;
                        Conn.IdTipoEvento = item.IdTipoEvento;
                        Conn.FechaHoraInicio = item.FechaHoraInicio;
                        Conn.FechaHoraTermino = item.FechaHoraTermino;
                        Conn.Asistentes = item.Asistentes;
                        Conn.PersonalAdicional = item.PersonalAdicional;
                        Conn.Realizado = item.Realizado;
                        Conn.ValorTotalContrato = item.ValorTotalContrato;
                        Conn.Observaciones = item.Observaciones;


                        Contract.Add(Conn);
                    }
                }
                return Contract;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
             }




            public List<ListaCompleto> ReadAll2()
        {
            try
            {
                var x = from item in bdd.Contrato
                        join modd in bdd.ModalidadServicio on item.IdModalidad equals modd.IdModalidad
                        join te in bdd.TipoEvento on item.IdTipoEvento equals te.IdTipoEvento
                        select new ListaCompleto()
                        {
                            Numero = item.Numero,
                            Creacion = item.Creacion,
                            Termino = item.Termino,
                            RutCliente = item.RutCliente,
                            Modalidad = modd.Nombre,
                            TipoEvento = te.Descripcion,
                            FechaHoraInicio = item.FechaHoraInicio,
                            FechaHoraTermino = item.FechaHoraTermino,
                            Asistentes = item.Asistentes,
                            PersonalAdicional = item.PersonalAdicional,
                            Realizado = item.Realizado,
                            ValorTotalContrato = item.ValorTotalContrato,
                            

            };
            return x.ToList();
        }
            catch (Exception ex)
            {

                return null;
    }

}
    }
    }


