using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Common
{
    public interface INavigator
    {

        Task<Page> NavigateToAsync<T>(CancellationToken cancellationToken) where T : ViewModel;
        Task<Page> NavigateToAsync<T>(CancellationToken cancellationToken, Action<T> preInitAction) where T : ViewModel;

        Task<Page> NavigateToAsync<T>() where T : ViewModel;
        Task<Page> NavigateToAsync<T>(Action<T> preInitAction) where T : ViewModel;
    }
}
