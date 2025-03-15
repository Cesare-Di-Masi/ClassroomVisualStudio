using RestauranCalendarLib;
using RestauranCalendarMatrix;
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

namespace RestaurantCalendarMatrix
{
    /// <summary>
    /// Logica di interazione per AddRestaurantWindow.xaml
    /// </summary>
    public partial class AddRestaurantWindow : Window
    {
        RestaurantCalendar _calendar;
        public AddRestaurantWindow(RestaurantCalendar calendar)
        {
            _calendar = calendar;
            InitializeComponent();
        }

        private void RemovetxtBoxText(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox)
            {
                if(txtbboxAddRestaurant.Text == "digitare il nome del ristorante")
                txtbboxAddRestaurant.Text = string.Empty;
            }
        }

        private void RetrievetxtBoxText(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox)
            {
                if(txtbboxAddRestaurant.Text == null)
                {
                    txtbboxAddRestaurant.Text = "digitare il nome del ristorante";
                }
            }
        }

        private void addRestaurant(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                string restaurant = txtbboxAddRestaurant.Text;
                _calendar.addRestaurant(restaurant);
                txtbboxAddRestaurant.Text = "digitare il nome del ristorante";
            }
        }

        private void ReturnToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow(_calendar);
            a.Show();
            this.Close();
        }
    }
}
