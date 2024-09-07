using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFakeStore.Models;

namespace AppFakeStore.Services
{
    public interface ILoginService
    {
        Task<string> GetTokenAsync(string username, string password);
    }
}