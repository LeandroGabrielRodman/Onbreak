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

namespace WpfApp
{
    /// <summary>
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar(ListaCompleta cli)
        {
            InitializeComponent();
            Cliente cle = new Cliente();
            txt_rut.Text =cli.RutCLiente;
            txt_rut.IsEnabled = false;
            txt_RazonSocial.Text = cli.RazonSocial;
            txt_Nombre.Text = cli.NombreContacto;
            txt_MailContacto.Text = cli.MailContacto;
            txt_Direccion.Text = cli.Direccion;
            txt_telefono.Text = cli.Telefono;




            BibliotecaClases.ActividadEmpresa ae = new ActividadEmpresa();
            var li = ae.listar();
            cb_ActividadEmpresa.Items.Add("Seleccione");
            cb_ActividadEmpresa.SelectedIndex = 0;
            foreach (var item in li)
            {
                ComboActividadEmpresa combo = new ComboActividadEmpresa();
                combo.id = item.idactividadEmpresa;
                combo.texto = item.Descripcion;
                cb_ActividadEmpresa.Items.Add(combo);

            }

            cb_ActividadEmpresa.SelectedIndex = 0;



            BibliotecaClases.TipoEmpresa te = new BibliotecaClases.TipoEmpresa();
            var lis = te.listar();
            cb_TipoEmpresa.Items.Add("Seleccione");
            cb_TipoEmpresa.SelectedIndex = 0;
            foreach (var item in lis)
            {
                ComboTipoEmpresa comb = new ComboTipoEmpresa();

                comb.id = item.idTipoEmpresa;
                comb.texto = item.Descripcion;
                cb_TipoEmpresa.Items.Add(comb);

            }

            cb_TipoEmpresa.SelectedIndex = 0;



          


            }

        private void btn_Modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!txt_rut.Text.Equals("") && !txt_Direccion.Text.Equals("") &&
                   !txt_MailContacto.Text.Equals("") && !txt_Nombre.Text.Equals("") &&
                   !txt_RazonSocial.Text.Equals("") && !txt_telefono.Text.Equals(""))
                {
                    string RutCliente = txt_rut.Text;
                    string RazonSocial = txt_RazonSocial.Text;
                    string NombreContacto = txt_Nombre.Text;
                    string MailContacto = txt_MailContacto.Text;
                    string Direccion = txt_Direccion.Text;
                    string Telefono = txt_telefono.Text;

                    ComboActividadEmpresa IdActividadEmpresa = (ComboActividadEmpresa)cb_ActividadEmpresa.SelectedItem;
                    ComboTipoEmpresa IdTipoEmpresa = (ComboTipoEmpresa)cb_TipoEmpresa.SelectedItem;

                    Cliente cliente = new Cliente();
                    cliente.RutCliente = RutCliente;
                    cliente.RazonSocial = RazonSocial;
                    cliente.NombreContacto = NombreContacto;
                    cliente.MailContacto = MailContacto;
                    cliente.Direccion = Direccion;
                    cliente.Telefono = Telefono;
                    cliente.IdActividadEmpresa = IdActividadEmpresa.id;
                    cliente.IdTipoEmpresa = IdTipoEmpresa.id;

                    if (cliente.Modificar() == true)
                    {
                        //await this.ShowMessageAsync("Mensaje:",
                        //    string.Format("Modificado Correctamente"));
                        MessageBox.Show("Se guardo correctamente");
                    }
                    else
                    {
                        //await this.ShowMessageAsync("Mensaje:",
                        //string.Format("Error al Modificar"));
                        MessageBox.Show("No se Guardo Correctamente");
                    }


                }
                else
                {
                    //await this.ShowMessageAsync("Mensaje:",
                    //    string.Format("Debe rellenar todos los campos"));
                    MessageBox.Show("Se deben rellenar los campos");
                }




            }
            catch (Exception ex)
            {

                //await this.ShowMessageAsync("Mensaje:",
                //    string.Format("Error al Modificar"));
                MessageBox.Show("Error al modificar");
            }


        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
