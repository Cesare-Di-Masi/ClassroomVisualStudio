using LibVERIFICA_APRILE_DIMASI;
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

namespace VERIFICA_APRILE_DIMASI
{
    /// <summary>
    /// Logica di interazione per GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameLogic currGameLogic;
        GridManager currGridManager;
        Player currPlayer;
        public GameWindow(GameLogic gameLogic,GridManager gridManager,Player player)
        {
            InitializeComponent();
            currGameLogic = gameLogic;
            currGridManager = gridManager;
            currPlayer = player;

            lblAttemptsDone.Content= "0";
            lblAttemptsLeft.Content = currGridManager.NAttempts;

        }
        /// <summary>
        /// Dato il bottone controllo che la sua posizione sia corretta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TryAttempt(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                

                Button btn = (Button)sender;
                string str = (string)btn.Content;//vado a trasformare il contenuto del bottone che premo in una stringa

                string sr = "";//creò un altra stringa vuoto
                sr += str[0];//attribuisco a quella stringa il primo valore della stringa che era all'interno del bottone
                
                int x = Int32.Parse(sr);//trasformo quella stringa in intero

                sr = "";//ripeto il processo
                sr += str[1];

                int y = Int32.Parse(sr);

                currGridManager.makeATry(x, y);//mando le coordinate

                if (currGridManager.GameStatus == GameState.PLAYING)//controllo della vittoria
                {
                    btn.Background = Brushes.Red;//colore rosso se non è corretto
                    btn.IsHitTestVisible = false;//disabilito il bottone
                } 
                else if (currGridManager.GameStatus == GameState.WON)
                {
                    btn.Background = Brushes.Green;//colore verde se è corretto
                    btn.IsHitTestVisible = false;//disabilito il bottone
                    MessageBox.Show("YOU HAVE WON", "RESULT");

                }else
                {
                    btn.IsHitTestVisible = false;//disabilito il bottone
                    btn.Background = Brushes.Red;//colore rosso se non è corretto

                    MessageBox.Show("YOU HAVE LOST", "RESULT");
                }

                currPlayer.makeAnAttempt();
                lblAttemptsDone.Content = currPlayer.CurrentAttempt;//aggiorno le label
                lblAttemptsLeft.Content = currGridManager.NAttempts;

            }
        }

        private void ReturnToMain(object sender, RoutedEventArgs e)//torno al main Window
        {
            var a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
