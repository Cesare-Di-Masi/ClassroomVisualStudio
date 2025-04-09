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
using LibVERIFICA_APRILE_DIMASI;

namespace VERIFICA_APRILE_DIMASI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic currGameLogic;
        GridManager currGridManager;
        Player currPlayer;


        int gridSize;
        int nAttempts;

        Button[,] buttonsGrid;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ConfirmSettings(object sender, RoutedEventArgs e)
        {
            bool error = false;
            
            try
            {
                gridSize = 5;
                nAttempts = int.Parse(txtInsertNAttempts.Text);
            }
            catch (Exception ex)
            {
                var errorMessage = MessageBox.Show(ex.ToString(), "qualcosa è andato storto, riprovare");
                error = true;
                return;
            }

            if (error == false)
            {
                currGameLogic = new GameLogic(gridSize);
                GridManager currGridManager = new GridManager(currGameLogic.GameGrid, nAttempts);
                currPlayer = new Player("player");

                var a = new GameWindow(currGameLogic, currGridManager, currPlayer);
                a.Show();
                this.Close();
            }
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox)
            {
                TextBox textBox = (TextBox)sender;
                if(textBox.Text == "Write Here")
                    textBox.Text = "";
            }
        }

        private void GiveText(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textBox = (TextBox)sender;
                if (textBox.Text == " " || textBox.Text =="")
                    textBox.Text = "Write Here";

            }
        }

        private void btnDeveloperMode_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                bool error = false;
                do
                {
                    error = false;
                    try
                    {
                        gridSize = 5;
                        nAttempts = int.Parse(txtInsertNAttempts.Text);
                    }
                    catch (Exception ex)
                    {
                        var errorMessage = MessageBox.Show(ex.ToString(), "qualcosa è andato storto, riprovare");
                        error = true;
                    }
                } while (error);

                FixedGenerator generator = new FixedGenerator();

                currGameLogic = new GameLogic(gridSize, generator);
                GridManager currGridManager = new GridManager(currGameLogic.GameGrid, nAttempts);
                currPlayer = new Player("player");

                var a = new GameWindow(currGameLogic, currGridManager, currPlayer);
                a.Show();
                this.Close();

            }
        }
    }
}