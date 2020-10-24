using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spender.Services
{
    public interface INavigation
    {
        Task GotoAsync(string url);
    }

    public class Navigation : INavigation
    {
        public async Task GotoAsync(string url)
        {
            await Shell.Current.GoToAsync(url);
        }
    }
}
