using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDALC;


namespace BibliotecaClases
{
    public class Cliente
    {
        //Private
        private int _actividad;
        private String _nrotelefono;
        private String _direccion;
        private String _email;
        private String _nombre;
        private String _razonsocial;
        private String _rut;
        private int _idtipoempresa;

      


        //Public metode

        public String RutCliente
        {
            get { return _rut; }
            set
            {
                if (value.Trim().Length <= 10 && value.Trim().Length >= 9)
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un RUT valido ");
                }
            }
        }
        public String RazonSocial
        {
            get { return _razonsocial; }
            set
            {
                if (value.Trim() != null && value.Trim().Length >= 6)
                {
                    _razonsocial = value;
                }
                else
                {
                    throw new ArgumentException("El Campo Razon Social es obligatorio");
                }
            }
        }
        public String NombreContacto
        {
            get { return _nombre; }
            set
            {
                if (value.Trim().Length >= 3)
                {
                    _nombre = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Nombre de a lo menos 3 caracteres");
                }
            }
        }
        public String MailContacto
        {
            get { return _email; }
            set
            {
                if (value.Trim().Length >= 6 && value.Trim() != null)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Correo Electronico valido");
                }
            }
        }
        public String Direccion
        {
            get { return _direccion; }
            set
            {
                if (value.Trim().Length >= 6 && value.Trim() != null)
                {
                    _direccion = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese una Direccion valida.");
                }
            }
        }
        public String Telefono
        {
            get { return _nrotelefono; }
            set
            {
                if (value.Length==9)
                {
                    _nrotelefono = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Numero de 9 digitos si es un numero fijo anteponga '22' si es movil anteponga un '9'");
                }
            }
        }
        public int IdActividadEmpresa
        {
            get { return _actividad; }
            set { _actividad = value; }
        }
        public int IdTipoEmpresa
        {
            get { return _idtipoempresa; }
            set { _idtipoempresa = value; }
        }

        public Cliente()
        {

        }
        private OnBreakEntities1 bdd = new OnBreakEntities1();

        public bool Guardar()
        {
            try
            {
                BibliotecaDALC.Cliente cli = new BibliotecaDALC.Cliente();
                CommonBC.Syncronize(this,cli);
                bdd.Cliente.Add(cli);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception ex )
            {

                return false;
            }
        }


        public List<Cliente> ReadAll()
        {
            try
            {
                var x = bdd.Cliente.ToList();
                List<Cliente> Lista_Cliente = new List<Cliente>();
                foreach (BibliotecaDALC.Cliente item in x)
                {
                    Cliente cli = new Cliente();
                    CommonBC.Syncronize(item,cli);
                    Lista_Cliente.Add(cli);
                }
                return Lista_Cliente;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<ListaCompleta> ReadAll2()
        {
            try
            {
                var x = from cli in bdd.Cliente
                        join ac in bdd.ActividadEmpresa on cli.IdActividadEmpresa equals ac.IdActividadEmpresa
                        join te in bdd.TipoEmpresa on cli.IdTipoEmpresa equals te.IdTipoEmpresa
                        select new ListaCompleta()
                        {
                            RutCLiente = cli.RutCliente,
                            NombreContacto = cli.NombreContacto,
                            RazonSocial = cli.RazonSocial,
                            MailContacto = cli.MailContacto,
                            Telefono = cli.Telefono,
                            Direccion = cli.Direccion,
                            IdActividadEmpresa=ac.Descripcion,
                            IdTipoEmpresa = te.Descripcion

                        };
                return x.ToList();
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public bool Eliminar()
        {
            try
            {
                BibliotecaDALC.Cliente cli = bdd.Cliente.First(x => x.RutCliente == this.RutCliente);
                CommonBC.Syncronize(this, cli);
            
                bdd.Cliente.Remove(cli);
                bdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false; 
            }
        }

        public List<Cliente> Buscar(string rut)
        {
            try
            {
                var lista = bdd.Cliente.ToList();
                List<Cliente> clie = new List<Cliente>();
                foreach (var item in lista)
                {


                    if (item.RutCliente.Equals(rut))
                    {
                        Cliente clien = new Cliente();

                        clien.RutCliente = item.RutCliente;
                        clien.RazonSocial = item.RazonSocial;
                        clien.NombreContacto = item.NombreContacto;
                        clien.MailContacto = item.MailContacto;
                        clien.Direccion = item.Direccion;
                        clien.Telefono = item.Telefono;
                        clien.IdActividadEmpresa = item.IdActividadEmpresa;
                        clien.IdTipoEmpresa = item.IdTipoEmpresa;


                        clie.Add(clien);


                    }



                }
                return clie;




            }
            catch (Exception)
            {

                return null;
            }


        }



        public bool Modificar()
        {
            try
            {

                BibliotecaDALC.Cliente cBD = bdd.Cliente.First(x => x.RutCliente == this.RutCliente);

                cBD.RutCliente = this.RutCliente;
                cBD.RazonSocial = this.RazonSocial;
                cBD.NombreContacto = this.NombreContacto;
                cBD.MailContacto = this.MailContacto;
                cBD.Direccion = this.Direccion;
                cBD.Telefono = this.Telefono;
                cBD.IdActividadEmpresa = this.IdActividadEmpresa;
                cBD.IdTipoEmpresa = this.IdTipoEmpresa;

                bdd.SaveChanges();

                return true;



            }
            catch (Exception ex)
            {

                return false;
            }





        }
    }


}

