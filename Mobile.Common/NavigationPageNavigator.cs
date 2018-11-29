using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Common
{
    public class NavigationPageNavigator : INavigator
    {
        public NavigationPageNavigator(IFactory viewModelFactory, IFactory pageFactory)
        {
            this.ViewModelFactory = viewModelFactory;
            this.PageFactory = pageFactory;
        }

        public NavigationPage NavigationPage { get; set; }

        public Task<Page> NavigateToAsync<T>() where T : ViewModel
        {
            return NavigateToAsync<T>(null);
        }

        public Task<Page> NavigateToAsync<T>(Action<T> preInitAction) where T : ViewModel
        {
            return NavigateToAsync<T>(CancellationToken.None, preInitAction);
        }


        public Dictionary<Type, Type> RegistryByViewModel { get; } = new Dictionary<Type, Type>();
        public Dictionary<Type, Type> RegistryByPage { get; } = new Dictionary<Type, Type>();
        public IFactory ViewModelFactory { get; }
        public IFactory PageFactory { get; }

        internal void RegisterPage(Type pageType, Type viewModelType)
        {
            RegistryByPage[pageType] = viewModelType;
            RegistryByViewModel[viewModelType] = pageType;
        }

        public Task<Page> NavigateToAsync<T>(CancellationToken cancellationToken) where T : ViewModel
        {
            return NavigateToAsync<T>(cancellationToken, null);
        }

        public async Task<Page> NavigateToAsync<T>(CancellationToken cancellationToken, Action<T> preInitAction) where T : ViewModel
        {
            Type vmType = typeof(T);
            Type pageType;

            if (!RegistryByViewModel.TryGetValue(vmType, out pageType))
            {
                throw new InvalidOperationException();
            }

            Page page = (Page)await PageFactory.CreateAsync(pageType);
            T viewModel = await ViewModelFactory.CreateAsync<T>();

            preInitAction?.Invoke(viewModel);

            page.BindingContext = viewModel;

            await this.NavigationPage.PushAsync(page);

            await viewModel.InitializeAsync(CancellationToken.None);

            return page;
        }

        static readonly Type pageType = typeof(Page);

        public void RegisterPagesInAssembly(Assembly assembly)
        {
            var pageTypes = assembly.GetExportedTypes()
                                 .Where(t => pageType.IsAssignableFrom(t))
                                 .Where(t => !t.IsAbstract)
                                 .Select(x => new
                                 {
                                     PageType = x,
                                     ViewModelType = x.GetTypeInfo().GetCustomAttributesData().Where(a => a.AttributeType == typeof(ViewModelAttribute)).SelectMany(a => a.ConstructorArguments).Where(a => a.ArgumentType == typeof(Type)).Select(a => (Type)a.Value).FirstOrDefault()
                                 })
                                 .Where(x => x.ViewModelType != null)
                                 .ToList();


            foreach (var pageType in pageTypes)
            {
                this.RegisterPage(pageType.PageType, pageType.ViewModelType);
            }
        }
    }
}
