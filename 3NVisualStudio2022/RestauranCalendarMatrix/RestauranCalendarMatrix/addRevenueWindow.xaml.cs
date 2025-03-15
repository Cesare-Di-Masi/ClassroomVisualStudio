using RestauranCalendarLib;
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
    /// Logica di interazione per addRevenueWindow.xaml
    /// </summary>
    public partial class addRevenueWindow : Window
    {
        RestaurantCalendar _calendar;
        public addRevenueWindow(RestaurantCalendar calendar)
        {
            _calendar = calendar;
            InitializeComponent();
        }



    }
}
