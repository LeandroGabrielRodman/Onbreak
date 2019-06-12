using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliotecaClases;
using MahApps.Metro.Controls;
namespace WpfApp
{
    /// <summary>
    /// Lógica de interacción para Wpf_AdmClnt.xaml
    /// </summary>
    public partial class Wpf_AdmClnt : MetroWindow
    {
        Cliente clie = new Cliente();
        public Wpf_AdmClnt()
        {

            InitializeComponent();


            BibliotecaClases.ActividadEmpresa ae = new ActividadEmpresa();

            var i = ae.listar();

            cb_actividad.Items.Add("Seleccione");
            cb_actividad.SelectedIndex = 0;
            foreach (var item in i)
            {
                ComboActividadEmpresa combo = new ComboActividadEmpresa();
                combo.id = item.idactividadEmpresa;
                combo.texto = item.Descripcion;
                cb_actividad.Items.Add(combo);

            }

            BibliotecaClases.TipoEmpresa te = new TipoEmpresa();
            var x = te.listar();
            cb_tipo.Items.Add("Seleccione");
            cb_tipo.SelectedIndex = 0;
            foreach (var item in x)
            {
                ComboTipoEmpresa comb = new ComboTipoEmpresa();
                comb.id = item.idTipoEmpresa;
                comb.texto = item.Descripcion;
                cb_tipo.Items.Add(comb);
            }
            
        }   
    

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }


                            //LISTAR
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Wpf_ListaClientes lista_clientes = new Wpf_ListaClientes(this);
            lista_clientes.Show();
            lista_clientes.btn_Traspasar.Visibility = Visibility;

        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                String RutCliente = txt_rut.Text;
                String RazonSocial = txt_razon_social.Text;
                String NombreContacto = txt_nombre.Text;
                String MailContacto = txt_email.Text;
                String Direcion = txt_direccion.Text;
                String Telefono = txt_telefono.Text;
                ComboActividadEmpresa idac = (ComboActividadEmpresa)cb_actividad.SelectedItem;
                ComboTipoEmpresa idtp = (ComboTipoEmpresa)cb_tipo.SelectedItem;


                Cliente cli = new Cliente();
                cli.RutCliente = RutCliente;
                cli.NombreContacto = NombreContacto;
                cli.RazonSocial = RazonSocial;
                cli.MailContacto = MailContacto;
                cli.Direccion = Direcion;
                cli.Telefono = Telefono;
                cli.IdActividadEmpresa = idac.id;
                cli.IdTipoEmpresa = idtp.id;
                bool resp = cli.Guardar();
                if (resp==true )
                {
                    MessageBox.Show("Se ha guardado el cliente exitosamente" );
                }
                else
                {
                    MessageBox.Show("Operecion cancelada");
                }
                
            }
            catch (Exception exe)
            {

                MessageBox.Show("¡No Grabo!. Asegurece que esten todos los parametros en orden ");
                throw new ArgumentException(exe.Message);
            }
            
        }

        private void cb_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_Actividad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Buscar()
        {
     
        }

        private void btn_buscar1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clie.Buscar(txt_rut.Text);
                txt_nombre.Text = clie.NombreContacto;
            }
            catch (Exception)
            {

                MessageBox.Show("Debe ingresar un rut valido para buscar");
            }
          
        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)
        {

            txt_direccion.Clear();
            txt_email.Clear();
            txt_nombre.Clear();
            txt_razon_social.Clear();
            txt_rut.Clear();
            txt_telefono.Clear();
            cb_actividad.SelectedIndex = 0;
            cb_tipo.SelectedIndex = 0;
        }

        private void btn_actualizar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!txt_rut.Text.Equals("") && !txt_direccion.Text.Equals("") &&
                   !txt_email.Text.Equals("") && !txt_nombre.Text.Equals("") &&
                   !txt_razon_social.Text.Equals("") && !txt_telefono.Text.Equals(""))
                {
                    String RutCliente = txt_rut.Text;
                    String RazonSocial = txt_razon_social.Text;
                    String NombreContacto = txt_nombre.Text;
                    String MailContacto = txt_email.Text;
                    String Direcion = txt_direccion.Text;
                    String Telefono = txt_telefono.Text;
                    ComboActividadEmpresa idac = (ComboActividadEmpresa)cb_actividad.SelectedItem;
                    ComboTipoEmpresa idtp = (ComboTipoEmpresa)cb_tipo.SelectedItem;


                    Cliente cli = new Cliente();
                    cli.RutCliente = RutCliente;
                    cli.NombreContacto = RazonSocial;
                    cli.RazonSocial = NombreContacto;
                    cli.MailContacto = MailContacto;
                    cli.Direccion = Direcion;
                    cli.Telefono = Telefono;
                    cli.IdActividadEmpresa = idac.id;
                    cli.IdTipoEmpresa = idtp.id;

                    if (cli.Modificar() == true)
                    {
                        //await this.ShowMessageAsync("Mensaje:",
                        //    string.Format("Modificado Correctamente"));
                        MessageBox.Show("ola");
                    }
                    else
                    {
                        //await this.ShowMessageAsync("Mensaje:",
                        //   string.Format("Error al Modificar"));
                        MessageBox.Show("error ola");
                    }


                }
                else
                {
                    //await this.ShowMessageAsync("Mensaje:",
                    //    string.Format("Debe rellenar todos los campos"));
                    MessageBox.Show("rellene los ola");
                }




            }
            catch (Exception ex)
            {

                //await this.ShowMessageAsync("Mensaje:",
                //    string.Format("Error al Modificar"));
                MessageBox.Show("error al modificar la ola");
            }
        }
    }
}
