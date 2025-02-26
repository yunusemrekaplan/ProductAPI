namespace ProductAPI.Constants
{
    public static class ErrorMessages
    {
        # region AuthController

        public const string InvalidUsernameOrPassword = "Invalid username or password";
        public const string InvalidRefreshToken = "Invalid Refresh Token";
        public const string UsernameAlreadyExists = "Username already exists";
        public const string UserNotFound = "User not found";

        # endregion

        # region BrandController

        public const string BrandNameExists = "Brand name already exists";
        public const string CannotDeleteBrandWithProductModels = "Cannot delete brand with associated product models";

        # endregion

        #region ProductController

        public const string ProductNotFound = "Product not found";
        public const string ProductNameExists = "Product name already exists";

        #endregion

        # region ProductModelController

        public const string BrandNotFound = "Brand not found";
        public const string ProductModelNameExists = "Product model name already exists for this brand";
        public const string CannotDeleteProductModelWithProducts = "Cannot delete product model with associated products";

        # endregion

        #region UserController

        public const string EmailAlreadyExists = "Email already exists";
        public const string RoleNotFound = "Role not found";

        #endregion
    }
}