using AppFakeStore.Models;
using AppFakeStore.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppFakeStore.ViewModels;

public partial class UsuarioDetalleViewModel : BaseViewModel
{
    [ObservableProperty]
    Usuario usuario;

    public UsuarioDetalleViewModel()
    {
        Title = "Detalle del Usuario";
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}
