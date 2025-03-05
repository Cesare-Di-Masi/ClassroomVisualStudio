namespace OnitTutorial.Views;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
		BindingContext = new ListViewModel();
	}
}	