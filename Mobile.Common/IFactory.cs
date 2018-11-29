using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Common
{
    public interface IFactory
    {
        Task<object> CreateAsync(Type type);
        Task<T> CreateAsync<T>();

        object Create(Type type);
        T Create<T>();
    }
}