using RestauranCalendarLib;
using RestaurantCalendarMatrix;
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

namespace RestauranCalendarMatrix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        RestaurantCalendar _calendar = new RestaurantCalendar();

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(RestaurantCalendar calendar)
        {
            _calendar = calendar;
            InitializeComponent();
        }

        private void btnAddRestaurant_Click(object sender, RoutedEventArgs e)
        {
            AddRestaurantWindow a = new AddRestaurantWindow(_calendar);
            a.Show();
            this.Close();
        }

        private void btnAddRevenue_Click(object sender, RoutedEventArgs e)
        {
            var a = new addRevenueWindow(_calendar);
            a.Show();
            this.Close();
        }

        private void btnSeeRestaurantScore_Click(object sender, RoutedEventArgs e)
        {
            //var a = new ManageRestaurantWindow(_cale);
            //a.Show();
            this.Close();
        }
    }
}