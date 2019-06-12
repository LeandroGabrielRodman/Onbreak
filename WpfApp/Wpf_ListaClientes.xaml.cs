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
    /// Lógica de interacción para Wpf_ListaClientes.xaml
    /// </summary>
    public partial class Wpf_ListaClientes : MetroWindow
    {

        Wpf_AdmClnt ventana_origen = null;

        public Wpf_ListaClientes()
        {
            InitializeComponent();
            llenar();
        }

        private void llenar()
        {

            btn_Traspasar.Visibility = Visibility.Hidden;

            BibliotecaClases.ActividadEmpresa ae = new ActividadEmpresa();

            Cliente cli = new Cliente();
            var todos = cli.ReadAll2();
            dgv_Listar.ItemsSource = todos;

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

        public Wpf_ListaClientes(Wpf_AdmClnt vo)
        {
            InitializeComponent();
            llenar();
            ventana_origen = vo;

            
        }


        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Traspasar_Click(object sender, RoutedEventArgs e)
        {



            
            ListaCompleta cl = (ListaCompleta)dgv_Listar.SelectedItem;
            ventana_origen.txt_rut.Text = cl.RutCLiente;
            ventana_origen.txt_nombre.Text = cl.NombreContacto;
            ventana_origen.txt_razon_social.Text = cl.RazonSocial;
            ventana_origen.txt_email.Text = cl.MailContacto; 
            ventana_origen.txt_direccion.Text = cl.Direccion;
            ventana_origen.txt_telefono.Text = cl.Telefono;
            ventana_origen.cb_actividad.Text = cl.IdActividadEmpresa;
            ventana_origen.cb_tipo.Text = cl.IdTipoEmpresa;
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente CL = new Cliente();
               
                    ListaCompleta cli = (ListaCompleta)dgv_Listar.SelectedItem;
                    CL.RutCliente = cli.RutCLiente;
               
                
                
                
                 MessageBoxResult respuesta =
                MessageBox.Show(" ¿Desea elminar al cliente? ","Eliminar",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (respuesta == MessageBoxResult.Yes)
                {
                    if (CL.Eliminar() == true)
                    {
                        MessageBox.Show("Se Elimino");
                    }
                    else
                    {
                        MessageBox.Show("No se elimino");
                    }
                }
                else
                {
                    MessageBox.Show("Operacion Cancelada");
                }
                

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Selecione para poder Eliminar"+ex.Message);
            }
            //Update Table 
            Cliente CLE = new Cliente();
            var todos = CLE.ReadAll2();
            dgv_Listar.ItemsSource = todos;

        }

        private void btn_Filtrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboTipoEmpresa tipo = (ComboTipoEmpresa)cb_tipo.SelectedItem;
                if (cb_actividad.SelectedIndex != -1)
                {
                    Cliente cliente = new Cliente();
                    var lista = cliente.ReadAll2();
                    lista = lista.Where(x => x.IdTipoEmpresa.Equals(tipo.texto)).ToList();
                    dgv_Listar.ItemsSource = lista;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Elija un tipo de empresa valido");
            }
            
        }

        private void cb_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_filtrar_actividad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboActividadEmpresa tipo = (ComboActividadEmpresa)cb_actividad.SelectedItem;
                if (cb_actividad.SelectedIndex != -1)
                {
                    Cliente cliente = new Cliente();
                    var lista = cliente.ReadAll2();
                    lista = lista.Where(x => x.IdActividadEmpresa.Equals(tipo.texto)).ToList();
                    dgv_Listar.ItemsSource = lista;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Elija una actividad valida");
            }
        }

        private void btn_filtrar_rut_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txt_buscar_rut.Text != string.Empty)
                {

                    Cliente cli = new Cliente();
                    string rut = txt_buscar_rut.Text;
                    dgv_Listar.ItemsSource = cli.Buscar(rut);


                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgv_Listar.SelectedItem==null)
                {
                    return;
                }
                ListaCompleta CLE = (ListaCompleta)dgv_Listar.SelectedItem;
                Modificar mod = new Modificar(CLE);
                mod.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una opcion valida");
            }
        }

        private void cb_tipo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgv_Listar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
