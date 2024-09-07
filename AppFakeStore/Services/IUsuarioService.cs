using AppFakeStore.Models;

namespace AppFakeStore.Services;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetProductsAsync();
}
