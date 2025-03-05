using CommunityToolkit.Mvvm.Input;
namespace OnitTutorial.Views;

public partial class OrderPage : ContentPage
{
	public OrderPage()
	{
		InitializeComponent();
		BindingContext = new ListViewModel();
	}

	[RelayCommand]
	public async Task NewOrder()
	{
		await Navigation.PushAsync(new OrderPage());
	}

}