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

namespace Caesar_Cypher
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

        private void CodeMessageWindowOpen(object sender, RoutedEventArgs e)
        {
            CodeMessageWindow codeMessageWindow = new CodeMessageWindow();
            codeMessageWindow.Show();
            this.Close();
        }

        private void DecodeMessageWindowOpen(object sender, RoutedEventArgs e)
        {
            DecodeMessageWindow decodeMessageWindow = new DecodeMessageWindow();
            decodeMessageWindow.Show();
            this.Close();
        }
    }
}