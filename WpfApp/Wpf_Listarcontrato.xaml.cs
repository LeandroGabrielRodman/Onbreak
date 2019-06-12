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
    /// Lógica de interacción para Wpf_Listarcontrato.xaml
    /// </summary>
    public partial class Wpf_Listarcontrato : MetroWindow
    {
        Wpf_AdminContrato ventana_origen;
        public Wpf_Listarcontrato()
        {
            InitializeComponent();
            dgv_listacon.ItemsSource = new Contrato().ReadAll2();
            

            btn_traspasar.Visibility = Visibility.Hidden;


        }
        public Wpf_Listarcontrato(Wpf_AdminContrato vo)
        {
            InitializeComponent();
            ventana_origen = vo;
            dgv_listacon.ItemsSource = new Contrato().ReadAll2();
        }



        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_traspasar_Click(object sender, RoutedEventArgs e)
        {
            Contrato co = (Contrato)dgv_listacon.SelectedItem;
            ventana_origen.txt_contrato.Text = co.Numero;
            ventana_origen.Buscar();
            this.Close();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_filtrarc_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void dgv_listacon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_tipoevento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_terminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
