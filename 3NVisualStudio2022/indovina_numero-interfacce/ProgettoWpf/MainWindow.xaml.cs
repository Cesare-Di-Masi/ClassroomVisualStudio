using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoreLibrary;

namespace ProgettoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        public MainWindow()
        {
            InitializeComponent();

            game = new Game();
        }

        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            txtAttempts.Text = string.Empty;
            lblMessage.Content = string.Empty;
        }
        

        private void Play(object sender, RoutedEventArgs e)
        {
            try
            {
                lstBoxAttempts.ItemsSource = null;
                int attempts = int.Parse(txtAttempts.Text);
                GameStatus status = game.Attempts(attempts);
                switch(status)
                {
                    case GameStatus.IN_PROGRESS:
                        lblMessage.Content = "Non hai indovinato! Ritenta";
                        break;
                    case GameStatus.WIN:
                        ManageWin();
                        break;
                    case GameStatus.LOSE:
                        ManageLose();
                        break;
                }

                lstBoxAttempts.ItemsSource = game.AllAttempts;                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageLose()
        {
            lblMessage.Foreground = Brushes.IndianRed;
            lblMessage.FontSize = 22;
            lblMessage.Content = "HAI PERSO! mi spiace non hai indovinato la tua partita finisce qui!";
            btnTry.IsEnabled = false;
        }
        private void ManageWin()
        {
            lblMessage.Foreground = Brushes.GreenYellow;
            lblMessage.FontSize = 22;
            lblMessage.Content = "HAI VINTO! Complimenti!";
            btnTry.IsEnabled = false;
        }
    }
}