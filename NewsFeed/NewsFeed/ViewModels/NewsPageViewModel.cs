using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NewsFeed.AuxiliaryAdditions;
using NewsFeed.Models;
using NewsFeed.Services;
using NewsFeed.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace NewsFeed.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        public NewsPageViewModel(INavigationService navigationService, IValidationService validationService, IWebApiService webApiService) : 
            base(navigationService, validationService, webApiService)
        {
            
        }

        #region Properties&Fields

        public ObservableCollection<ArticleModel> NewsList { get; set; }
        
        public ArticleModel SelectedItem { get; set; }
        
        public bool IsLoading { get; set; }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                if (_searchText.Length >= 3)
                {
                    ToSearchNews(_searchText);
                }
                else if(_searchText.Length == 0)
                {
                    ToSearchNews(string.Empty);
                }
            }
        }

        #endregion

        #region Commands

        public DelegateCommand ToDetailsPageCommand => new DelegateCommand(ToDetailsPage);

        #endregion


        #region Lifecycle

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsLoading = true;
            var response = await WebApiService.GetRequest<NewsModel>(Endpoints.GET_NEWS);
            if (response.Articles != null)
            {
                NewsList = new ObservableCollection<ArticleModel>(response.Articles);
                IsLoading = false;
            }
            IsLoading = false;
        }

        #endregion

        #region Methods

        private async void ToDetailsPage()
        {
            if (SelectedItem != null)
            {
                NavigationParameters parameters = new NavigationParameters()
                {
                    {"Article", SelectedItem}
                };
            
                await NavigationService.NavigateAsync(nameof(NewsDetailPage), parameters);
            }
        }

        private async void ToSearchNews(string keyword)
        {
            IsLoading = true;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var response = await WebApiService.GetRequest<NewsModel>(Endpoints.GET_NEWS, keyword);
                if (response.Articles != null)
                {
                    NewsList = new ObservableCollection<ArticleModel>(response.Articles);
                }
                IsLoading = false;
            }
            else
            {
                var response = await WebApiService.GetRequest<NewsModel>(Endpoints.GET_NEWS);
                if (response.Articles != null)
                {
                    NewsList = new ObservableCollection<ArticleModel>(response.Articles);
                }
                IsLoading = false;
            }
            IsLoading = false;
            
        }
        #endregion
    }
}