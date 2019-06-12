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
    /// Lógica de interacción para Wpf_AdminContrato.xaml
    /// </summary>
    public partial class Wpf_AdminContrato : MetroWindow
    {
        ServiceReference1.Service1Client ws = new ServiceReference1.Service1Client();
        
        /*TipoEvento evento;
        double asistentes;
        double valorbase;
        double total;*/

        public Wpf_AdminContrato()
        {

            InitializeComponent();
            
            ServiceReference1.Service1Client ws = new ServiceReference1.Service1Client();
            lbl_uf.Content = ws.Uf().ToString();
            lbl_valortotal.Content = "0";
            txt_contrato.Text = DateTime.Now.ToString("yyyyMMddHHmm");
            txt_creacion.Text = DateTime.Now.ToString("yyyy/MM/dd/HHmm");
            TipoEvento tpevent = new TipoEvento();
            BibliotecaClases.TipoEvento BTE = new TipoEvento();
            var bts = BTE.listar();
            cb_tipoevento.Items.Add("Seleccione");
            cb_tipoevento.SelectedIndex = 0;
            foreach (var item in bts)
            {
                ComboTipoEvento CTE = new ComboTipoEvento();
                CTE.id = item.IdTipoEvento;
                CTE.texto = item.Descripcion;
                cb_tipoevento.Items.Add(CTE);
            }

        }




        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente();
                ModalidadServicio modd = new ModalidadServicio();
                TipoEvento Tipeve = new TipoEvento();
                Contrato contr = new Contrato();
                DateTime Termino;
                Double ValorTotalContrato;
                String Numero = txt_contrato.Text;
                DateTime Creacion = DateTime.Now;
                cli.RutCliente = txt_buscarporrut.Text;
                DateTime FechaHoraInicio = (DateTime)dpkFechaInicio.SelectedDate;
                DateTime FechaHoraTermino = (DateTime)dpkFechaTermino.SelectedDate;
                int Asistentes = int.Parse(txt_cantasis.Text);
                int PersonalAdicional = int.Parse(txt_personalextra.Text);
                if (rbs_yes.IsChecked == true)
                {

                    contr.Realizado = false;
                    Termino = dpkFechaTermino.SelectedDate.Value;
                }
                else
                {
                    contr.Realizado = true;
                    Termino = dpkFechaTermino.SelectedDate.Value;
                }

                int personalAdicional = int.Parse(txt_personalextra.Text);
                try
                {
                    if (lbl_valortotal != null)
                    {
                        ValorTotalContrato = Double.Parse(lbl_valortotal.Content.ToString());
                    }
                    else
                    {
                        ValorTotalContrato = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede guardar vacio el valor total" + ex);
                    throw new ArgumentException();
                }

                String Observaciones = txt_observaciones.Text;
                Contrato Contrat = new Contrato();

                Contrat.Numero = Numero;
                Contrat.Creacion = Creacion;
                Contrat.Termino = Termino;
                Contrat.RutCliente = cli.RutCliente;
                Contrat.IdModalidad = ((ComboModalidadServicio)cb_ModalidadServicio.SelectedItem).IdModalidad;
                Contrat.IdTipoEvento = ((ComboTipoEvento)cb_tipoevento.SelectedItem).id;
                Contrat.FechaHoraInicio = FechaHoraInicio;
                Contrat.FechaHoraTermino = FechaHoraTermino;
                Contrat.Asistentes = Asistentes;
                Contrat.PersonalAdicional = personalAdicional;
                Contrat.ValorTotalContrato = ValorTotalContrato;
                Contrat.Observaciones = Observaciones;
                Contrat.Realizado = false;
                Boolean resp = Contrat.Guardar();
                if (resp == true)
                {
                    MessageBox.Show("Se ha guardado el contrato exitosamente");
                }
                else
                {
                    MessageBox.Show("Operacion cancelada");
                }
            }
            catch (Exception exe)
            {

                MessageBox.Show("¡No Grabo!. Asegurece que esten todos los parametros en orden ");
               
            }
        }

        public void Buscar()
        {
           
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_contrato.Text != string.Empty)
                {
                    Contrato contra = new Contrato();
                    string Numero = txt_contrato.Text;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se encontro ningun contrato"+ex);
            }
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Wpf_Listarcontrato vista_lista_contrato = new Wpf_Listarcontrato(this);
            vista_lista_contrato.Show();
        }

        private void txt_contrato_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)
        {

            txt_direccion.Clear();
            txt_cantasis.Clear();
            txt_valorbase.Clear();
            txt_personalbase.Clear();
            txt_observaciones.Clear();
            cb_tipoevento.SelectedIndex = 0;
            txt_nombrecliente.Clear();
            txt_buscarporrut.Clear();
            lbl_valortotal.Content = "";
            txt_personalextra.Clear();
            cb_ModalidadServicio.SelectedIndex = 0;
           


        }

        private void cb_tipoevento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (cb_tipoevento.SelectedItem.ToString() !="Seleccione")
                {
                    int id = ((ComboTipoEvento)cb_tipoevento.SelectedItem).id;

                    ComboModalidadServicio modd = new ComboModalidadServicio();
                    cb_ModalidadServicio.Items.Clear();
                    foreach (var item in modd.ModServ(id))
                    {
                        ComboModalidadServicio CMS = new ComboModalidadServicio();
                        CMS.IdModalidad = item.IdModalidad;
                        CMS.IdTipoEvento = item.IdTipoEvento;
                        CMS.Nombre = item.Nombre;
                        CMS.PersonalBase = item.PersonalBase;
                        CMS.ValorBase = item.ValorBase;
                        cb_ModalidadServicio.Items.Add(CMS);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_cantasis_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void txt_valorbase_TextChanged(object sender, TextChangedEventArgs e)

        {
            
        }

        private void txt_personalbase_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_personalextra_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private Double CalculoValorTotal()
        {
            int asistente = 0;
            int ca = 0;
            if (int.TryParse(txt_cantasis.Text, out ca))
            {
                if (ca >= 1 && ca <= 20)
                {
                    asistente = 3;
                }
                if (ca >= 21 && ca <= 50)
                {
                    asistente = 5;
                }
                if (ca > 50)
                {
                    asistente = 5;
                    int more = (int)((ca - 50) / 20);
                    asistente = asistente + more;
                }

            }
            Double personalextra = 0;
            int pe = 0;
            if (int.TryParse(txt_personalextra.Text, out pe))
            {
                if (pe > 0 && pe <= 2)
                {
                    personalextra = 2;
                }
                if (pe > 2 && pe <= 3)
                {
                    personalextra = 3;
                }
                if (pe > 3 && pe <= 4)
                {
                    personalextra = 3.5;
                }
                if (pe > 4)
                {
                    personalextra = 3.5;
                    int mas = (int)((int)(pe - 4) * 0.5);
                    personalextra = personalextra + mas;
                }
            }
            Double final = Math.Truncate((personalextra + asistente) * ws.Uf())+int.Parse(txt_valorbase.Text);
            return final;
        }

        private void Grid_Main_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_BuscarPorRut_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Wpf_ListaClientes lista_clientes = new Wpf_ListaClientes();
            lista_clientes.Show();
            lista_clientes.btn_Traspasar.Visibility = Visibility;
        }

        private void btn_CalCularTotal_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            lbl_valortotal.Content = CalculoValorTotal();

            //lbl_valortotal.Content = "$" + total_eve.ToString();
        }

        private void cb_ModalidadServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                txt_personalbase.Text = ((ComboModalidadServicio)cb_ModalidadServicio.SelectedItem).PersonalBase.ToString();
                txt_valorbase.Text = Math.Truncate(((ComboModalidadServicio)cb_ModalidadServicio.SelectedItem).ValorBase * ws.Uf()).ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
                
            
            
    }
}


