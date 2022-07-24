using NewsFeed.Utils.StaticModels;

namespace NewsFeed.Services
{
    public class ValidationServiceImplemetation : IValidationService
    {
        public bool ValidateAuthData(string login, string password)
        {
            if (login == UserAuthInfo.Login && password == UserAuthInfo.Password)
            {
                return true;
            }

            return false;
        }
    }
}