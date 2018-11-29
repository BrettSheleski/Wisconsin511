using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Common
{
    public class ActivatorFactory : IFactory
    {
        public object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public T Create<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public Task<object> CreateAsync(Type type)
        {
            return Task.FromResult(Create(type));
        }

        public Task<T> CreateAsync<T>()
        {
            return Task.FromResult(Create<T>());
        }
    }
}
