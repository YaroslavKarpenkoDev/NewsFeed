using NewsFeed.Models;
using NewsFeed.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Essentials;

namespace NewsFeed.ViewModels
{
    public class NewsDetailPageViewModel : ViewModelBase
    {
        public NewsDetailPageViewModel(INavigationService navigationService, IValidationService validationService, IWebApiService webApiService) : base(navigationService, validationService, webApiService)
        {
        }

        #region Properties

        public ArticleModel NewsDetail { get; set; }

        #endregion

        #region Commands

        public DelegateCommand ToFullVersionCommand => new DelegateCommand(ToFullVersion);

        public DelegateCommand BackNavigationCommand => new DelegateCommand(BackNavigation);

        #endregion

        #region Lifecycle

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.TryGetValue<ArticleModel>("Article", out ArticleModel detail))
            {
                NewsDetail = detail;
            }
        }

        #endregion

        #region Methods

        private async void ToFullVersion()
        {
            if (!string.IsNullOrWhiteSpace(NewsDetail.Url))
            {
                await Browser.OpenAsync(NewsDetail.Url, BrowserLaunchMode.SystemPreferred);
            }
        }

        private async void BackNavigation()
        {
            await NavigationService.GoBackAsync();
        }
        #endregion
    }
}