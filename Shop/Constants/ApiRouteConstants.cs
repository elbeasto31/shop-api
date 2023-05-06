namespace Shop.Constants
{
    public static class ApiRouteConstants
    {
        #region UserController

        public const string UserApiRoute = "api/users";

        public const string BirthdayMenRoute = "birthdaymen/{date}";
        public const string LastBuyersRoute = "last/{days}";
        public const string UserCategoriesRoute = "{id}/categories";

        #endregion
    }
}