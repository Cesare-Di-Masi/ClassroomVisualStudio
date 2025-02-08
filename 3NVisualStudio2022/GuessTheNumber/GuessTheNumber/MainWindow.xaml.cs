using GuessTheNumberLib;

using System.Windows;
using System.Windows.Controls;

namespace GuessTheNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private GameManager game;

        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                TextBox txtBox = sender as TextBox;

                txtBox.Text = "";
            }
        }

        private void btnConfirmSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int attempts = int.Parse(txtNumberOfAttempts.Text);
                int number = int.Parse(txtMaxNumber.Text);

                game = new GameManager(attempts, number);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore:{ex.Message}", "error in the settings you have chosen");
            }
        }
    }
}