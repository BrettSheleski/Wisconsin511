using Autofac;
using Mobile.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wisconsin511.Mobile
{
    public class AutoFacFactory : IFactory
    {
        public AutoFacFactory()
        {
        }

        public AutoFacFactory(IContainer container)
        {
            this.Container = container;
        }

        public IContainer Container { get; set; }

        public object Create(Type type)
        {
            return Container.Resolve(type);
        }

        public T Create<T>()
        {
            return Container.Resolve<T>();
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
