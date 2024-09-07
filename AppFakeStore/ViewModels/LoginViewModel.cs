using AppFakeStore.Services;
using System.Windows.Input;
using AppFakeStore.Views;

namespace AppFakeStore.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;


        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }

        public LoginViewModel(ILoginService loginService = null)
        {
            _loginService = loginService ?? new LoginService();
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingrese usuario y contraseña", "OK");
                return;
            }

            var token = await _loginService.GetTokenAsync(Username, Password);
            if (!string.IsNullOrEmpty(token))
            {
                // Login exitoso
                await App.Current.MainPage.DisplayAlert("Éxito", "Login Correcto", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Login fallido", "OK");
            }
        }
    }
}