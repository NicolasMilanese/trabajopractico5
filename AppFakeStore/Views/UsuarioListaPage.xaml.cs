using AppFakeStore.Services;
using AppFakeStore.ViewModels;

namespace AppFakeStore.Views;

public partial class UsuarioListaPage : ContentPage
{
    public UsuarioListaPage()
    {
        UsuarioService service = new UsuarioService();
        UsuarioListaViewModel vm = new UsuarioListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as UsuarioListaViewModel;

        if (vm != null)
        {
            await vm.GetUsuariosCommand.ExecuteAsync(null);
        }
    }
}