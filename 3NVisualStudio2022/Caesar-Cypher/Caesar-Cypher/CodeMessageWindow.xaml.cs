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
using Caesar_CypherLib;

namespace Caesar_Cypher
{
    /// <summary>
    /// Logica di interazione per CodeMessageWindow.xaml
    /// </summary>
    public partial class CodeMessageWindow : Window
    {
        CypherCode cypherCode;

        public CodeMessageWindow()
        {
            InitializeComponent();
        }

        public void removeText(object sender, EventArgs e)
        {
            if(sender is TextBox textBox)
            {
                if (textBox.Text == "Write here")
                    textBox.Text = "";
            }
        }

        public void giveText(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "")
                    textBox.Text = "Write here";
            }
        }

        private void CodeMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = txtWriteYourMessage.Text;
                int key = int.Parse(txtWriteYourKey.Text);

                cypherCode = new CypherCode(message, key);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            string codedMessage = cypherCode.codeMessage();

            lblCodedMessage.Content = codedMessage;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
