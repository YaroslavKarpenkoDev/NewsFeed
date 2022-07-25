using NewsFeed.Services;
using NewsFeed.ViewModels;
using NewsFeed.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace NewsFeed
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer)
			: base(initializer)
		{
			Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
		}

		protected override async void OnInitialized()
		{
			InitializeComponent();

			await NavigationService.NavigateAsync($"NavigationPage/{nameof(MainPage)}");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
			containerRegistry.RegisterSingleton<IValidationService, ValidationServiceImplemetation>();

			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<MainPage>();
			containerRegistry.RegisterForNavigation<NewsPage,NewsPageViewModel>();
		}
	}
}
