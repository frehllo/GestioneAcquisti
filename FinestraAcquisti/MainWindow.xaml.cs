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

namespace FinestraAcquisti
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtQuantità.IsEnabled = false;
            txtPrezzo.IsEnabled = false;
            cmbProdotto.IsEnabled = false;
            btnStampa.IsEnabled = false;
            btnPulisci.IsEnabled = false;
            btnRimuoviSelezione.IsEnabled = false;
            lstSelezione.IsEnabled = false;
        }

        private const string password = "narcis";
        private string utente;
        private void BtnAccedi_Click(object sender, RoutedEventArgs e)
        {
            if(txtPassword.Text == password)
            {
                utente = txtUtente.Text;
                txtUtente.IsEnabled = false;
                txtPassword.IsEnabled = false;
                txtErrore.Text = null;
                txtQuantità.IsEnabled = true;
                txtPrezzo.IsEnabled = true;
                cmbProdotto.IsEnabled = true;
                btnStampa.IsEnabled = true;
                btnPulisci.IsEnabled = true;
                btnRimuoviSelezione.IsEnabled = true;
                lstSelezione.IsEnabled = true;
            }
            else
            {
                txtErrore.Text = "Password errata";
            }
        }

        private void BtnButton_Click(object sender, RoutedEventArgs e)
        {
            string item;
            string prod = ((ComboBoxItem)cmbProdotto.SelectedItem).Content.ToString();
            double p = double.Parse(txtPrezzo.Text);
            int q = int.Parse(txtQuantità.Text);
            double prezzo = p * q;
            item = $"l'utente {utente} ha acquistato {q} {prod} al prezzo di {prezzo}€";
            lstSelezione.Items.Add(item);
        }

        private void BtnPulisci_Click(object sender, RoutedEventArgs e)
        {
            cmbProdotto.SelectedItem = null;
            txtPrezzo.Text = null;
            txtQuantità.Text = null;
        }

        private void BtnRimuoviSelezione_Click(object sender, RoutedEventArgs e)
        {
            lstSelezione.Items.RemoveAt(lstSelezione.SelectedIndex);
        }
    }
}
