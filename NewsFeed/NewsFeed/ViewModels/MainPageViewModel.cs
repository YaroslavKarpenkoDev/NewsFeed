using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsFeed.Services;
using NewsFeed.Utils.StaticModels;
using NewsFeed.Views;

namespace NewsFeed.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		public MainPageViewModel(INavigationService navigationService, IValidationService validationService, IWebApiService webApiService) : 
			base(navigationService, validationService, webApiService)
		{
			
		}

		#region Properties&Fields

		public string UserLogin { get; set; }
		public string UserPassword { get; set; }
		
		public bool IsValid { get; set; }

		#endregion

		#region Commands

		public DelegateCommand AuthCommand => new DelegateCommand(Auth);
		

		#endregion

		#region Lifecycle

		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			UserLogin = UserAuthInfo.Login;
			UserPassword = UserAuthInfo.Password;
			IsValid = true;

		}

		#endregion

		#region Methods

		private async void Auth()
		{
			if (ValidationService.ValidateAuthData(UserLogin, UserPassword))
			{
				await NavigationService.NavigateAsync(nameof(NewsPage));
			}
			else
			{
				IsValid = false;
			}
		}

		#endregion
	}
}
