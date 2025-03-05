using OnitTutorial.Views;
namespace OnitTutorial
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListPage());
        }
    }
}
