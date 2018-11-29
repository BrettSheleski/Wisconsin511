using Autofac;
using Mobile.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Wisconsin511.Mobile
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            AutoFacFactory autoFacFactory = new AutoFacFactory();
            ActivatorFactory activatorFactory = new ActivatorFactory();

            NavigationPageNavigator navigator = new NavigationPageNavigator(autoFacFactory, activatorFactory);


            Pages.MainPage mainPage = new Pages.MainPage()
            {
            };

            NavigationPage navPage = new NavigationPage(mainPage);

            navigator.NavigationPage = navPage;



            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance<INavigator>(navigator).SingleInstance();

            var thisAssembly = this.GetType().Assembly;

            navigator.RegisterPagesInAssembly(thisAssembly);

            RegisterViewModels(containerBuilder, thisAssembly);

            containerBuilder.RegisterType<Wisconsin511.WisconsinService>().As<Wisconsin511.IWisconsinService>().SingleInstance();

            var container = containerBuilder.Build(Autofac.Builder.ContainerBuildOptions.None);

            autoFacFactory.Container = container;

            var vm = container.Resolve<Pages.MainPageViewModel>();

            mainPage.BindingContext = vm;

            MainPage = mainPage;
		}

        static readonly Type viewModelBaseType = typeof(ViewModel);

        private static void RegisterViewModels(ContainerBuilder containerBuilder, Assembly assembly)
        {
            var vmTypes = (assembly.GetTypes() ?? new Type[] { })
                                  .Where(t => viewModelBaseType.IsAssignableFrom(t))
                                  .Where(t => !t.IsAbstract);

            foreach (var vmType in vmTypes)
            {
                containerBuilder.RegisterType(vmType);
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
