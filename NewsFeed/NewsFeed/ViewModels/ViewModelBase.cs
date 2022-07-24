using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using NewsFeed.Services;

namespace NewsFeed.ViewModels
{
	public class ViewModelBase : BindableBase, IInitialize, 
		INavigationAware, IDestructible
	{
		protected INavigationService NavigationService { get; private set; }
		protected IValidationService ValidationService { get; private set; }

		public ViewModelBase(INavigationService navigationService, IValidationService validationService)
		{
			NavigationService = navigationService;
			ValidationService = validationService;
		}

		public virtual void Initialize(INavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedFrom(INavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedTo(INavigationParameters parameters)
		{

		}

		public virtual void Destroy()
		{

		}
	}
}
