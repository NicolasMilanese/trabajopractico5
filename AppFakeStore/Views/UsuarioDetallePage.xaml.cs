using AppFakeStore.Models;
using AppFakeStore.ViewModels;


namespace AppFakeStore.Views;

public partial class UsuarioDetallePage : ContentPage
{
    public UsuarioDetallePage(Usuario param)
    {
        InitializeComponent();

        UsuarioDetalleViewModel vm = new UsuarioDetalleViewModel();
        this.BindingContext = vm;
        vm.Usuario = param;
    }
}