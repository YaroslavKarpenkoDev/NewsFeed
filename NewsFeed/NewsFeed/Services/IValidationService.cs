namespace NewsFeed.Services
{
    public interface IValidationService
    {
        bool ValidateAuthData(string login, string password);
    }
}