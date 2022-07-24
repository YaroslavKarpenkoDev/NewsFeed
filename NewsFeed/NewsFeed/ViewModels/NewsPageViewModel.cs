using NewsFeed.Services;
using Prism.Navigation;

namespace NewsFeed.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        public NewsPageViewModel(INavigationService navigationService, IValidationService validationService) : 
            base(navigationService, validationService)
        {
        }
    }
}