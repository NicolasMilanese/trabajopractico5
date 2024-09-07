using AppFakeStore.ViewModels;
using Microsoft.Maui.Controls; 

namespace AppFakeStore.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}