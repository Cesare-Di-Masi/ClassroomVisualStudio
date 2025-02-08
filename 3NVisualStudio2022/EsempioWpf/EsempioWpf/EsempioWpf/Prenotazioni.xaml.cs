using System.Windows;
using System.Windows.Controls;

namespace EsempioWpf
{
    /// <summary>
    /// Logica di interazione per Prenotazioni.xaml
    /// </summary>
    public partial class Prenotazioni : Window
    {
        private Ristorante ristorante;

        public Prenotazioni(Ristorante r)
        {
            this.ristorante = r;
            InitializeComponent();
            lblNomeRistorante.Content = r.Nome.ToUpper();
            updateLabel();
        }

        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            //per sicurezza verifico che il sender sia un textbox
            if (sender is TextBox)
            {
                //pulisco il contenuto del testo
                TextBox txtBox = sender as TextBox;
                txtBox.Text = "";
            }
        }

        private void txtPrendiPrenotazioniRewriteText(object sender, RoutedEvent e)
        {
            if (sender is TextBox)
            {
                TextBox txtBox = sender as TextBox ;
                txtBox.Text = " 1-4";
            }
        }


        private void updateLabel()
        {
            lblCopertiLiberi.Content = "Posti liberi:" + ristorante.NCoperti;
            lblTavoliLiberi.Content = "Tavoli liberi:" + ristorante.TavoliLiberi;
            lblTavoliOccupati.Content = "Tavoli occupati:" + ristorante.TavoliOccupati;
            txtPrendiPrenotazione.Text = null ;
        }

        private void btnConfermaPrenotazione_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nPersone = int.Parse(txtPrendiPrenotazione.Text);


                ristorante.prenotaUnTavolo(nPersone);

                updateLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore:{ex.Message}", "Errore nella prenotazione del tavolo");
            }
        }
    }
}