using ProductAPI.Entities.DTO.Identity;
using ProductAPI.Entities.Schemas.IdentitySchema;

namespace ProductAPI.Entities.Extensions
{
    public static class UserExtensions
    {
        public static User ToUser(this UserCreateModel model)
        {
            return new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Username = model.Username,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                RoleId = model.RoleId,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy.ToUser(),
                CreatedById = model.CreatedById,
                UpdatedAt = model.LastUpdatedAt,
                UpdatedBy = model.LastUpdatedBy.ToUser(),
                UpdatedById = model.LastUpdatedId,
            };
        }

        public static User ToUser(this UserUpdateModel model, User user)
        {
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Username = model.Username;
            user.Email = model.Email;
            user.RoleId = model.RoleId;

            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            user.CreatedAt = model.CreatedAt;
            user.CreatedBy = model.CreatedBy.ToUser();
            user.CreatedById = model.CreatedById;
            user.UpdatedAt = model.LastUpdatedAt;
            user.UpdatedBy = model.LastUpdatedBy.ToUser();
            user.UpdatedById = model.LastUpdatedId;

            return user;
        }
        
        public static User? ToUser(this UserViewModel? viewModel)
        {
            if (viewModel == null)
                return null;
            
            return new User
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Username = viewModel.Username,
                Email = viewModel.Email,
                CreatedAt = viewModel.CreatedAt,
                CreatedById = viewModel.CreatedById,
                UpdatedAt = viewModel.LastUpdatedAt,
                UpdatedById = viewModel.LastUpdatedId
            };
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                Email = user.Email,
                RoleName = user.Role != null ? user.Role.Name : string.Empty,
                CreatedAt = user.CreatedAt,
                CreatedBy = user.CreatedBy?.ToUserViewModel(),
                CreatedById = user.CreatedById,
                LastUpdatedAt = user.UpdatedAt,
                LastUpdatedBy = user.UpdatedBy?.ToUserViewModel(),
                LastUpdatedId = user.UpdatedById
            };
        }
    }
}