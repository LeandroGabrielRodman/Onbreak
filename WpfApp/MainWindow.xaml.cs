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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
namespace WpfApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_AdmClnt_Click(object sender, RoutedEventArgs e)
        {
            Wpf_AdmClnt vista_amd_clnt = new Wpf_AdmClnt();
            vista_amd_clnt.Show();
        }

        private void btn_LstClnt_Click(object sender, RoutedEventArgs e)
        {
            Wpf_ListaClientes lc = new Wpf_ListaClientes();
            lc.Show();
        }

        private void btn_AdmCntr_Click(object sender, RoutedEventArgs e)
        {
            Wpf_AdminContrato vista_admi_contract = new Wpf_AdminContrato();
            vista_admi_contract.Show();
        }

        private void btn_LstCntr_Click(object sender, RoutedEventArgs e)
        {
            Wpf_Listarcontrato vista_list_contract = new Wpf_Listarcontrato();
            vista_list_contract.Show();
        }
    }
}

