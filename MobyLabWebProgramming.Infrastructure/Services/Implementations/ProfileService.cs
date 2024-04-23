using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;
       // private readonly IUserService _userService;

        public ProfileService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<ProfileDTO>> GetProfile(Guid userId, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new ProfileProjectionSpec(userId), cancellationToken);

            return result != null ? 
                ServiceResponse<ProfileDTO>.ForSuccess(result) :
                ServiceResponse<ProfileDTO>.FromError(CommonErrors.UserNotFound);
        }

        public async Task<ServiceResponse<PagedResponse<ProfileDTO>>> GetProfiles(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        {
            var result = await _repository.PageAsync(pagination, new ProfileProjectionSpec(), cancellationToken);

            return ServiceResponse<PagedResponse<ProfileDTO>>.ForSuccess(result);
        }

        public async Task<ServiceResponse<int>> GetProfileCount(CancellationToken cancellationToken = default) =>
            ServiceResponse<int>.ForSuccess(await _repository.GetCountAsync<Profile>(cancellationToken));

        public async Task<ServiceResponse> AddProfile(ProfileDTO profile, UserDTO user, CancellationToken cancellationToken = default)
        {
          
            
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add profiles!", ErrorCodes.CannotAdd));
            }


            // Verificăm dacă există deja un profil pentru acest utilizator
            var existingProfile = await _repository.GetAsync<Profile>(new ProfileProjectionSpec(profile.UserId), cancellationToken);
            if (existingProfile != null)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "A profile already exists for this user!", ErrorCodes.ProfileAlreadyExistsForUser));
            }

            

            var existingUser = await _repository.GetAsync<User>(new UserProjectionSpec(profile.UserId), cancellationToken);

            await _repository.AddAsync(new Profile
            {
                Address = profile.Address,
                ImageUrl = profile.ImageUrl,
                Description = profile.Description,
                User = existingUser,
                UserId = user.Id
            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> UpdateProfile(ProfileDTO profile, UserDTO user, CancellationToken cancellationToken = default)
        {
            // Verificăm dacă utilizatorul are dreptul să actualizeze profilul
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can update profiles!", ErrorCodes.CannotUpdate));
            }

            if (user == null)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.NotFound, "User not found!", ErrorCodes.EntityNotFound));
            }


            // Obținem profilul utilizatorului
            var existingProfile = await _repository.GetAsync<Profile>(new ProfileProjectionSpec(user.Id), cancellationToken);
            if (existingProfile == null)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.NotFound, "Profile not found!", ErrorCodes.EntityNotFound));
            }

            // Actualizăm profilul cu noile date
            existingProfile.Address = profile.Address;
            existingProfile.ImageUrl = profile.ImageUrl;
            existingProfile.Description = profile.Description;

            await _repository.UpdateAsync(existingProfile, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteProfile(Guid id, UserDTO user, CancellationToken cancellationToken = default)
        {
            // Verificăm dacă utilizatorul are dreptul să șteargă profilul
            if (user != null && user.Role != UserRoleEnum.Admin)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can delete profiles!", ErrorCodes.CannotDelete));
            }

            // Ștergem profilul
            await _repository.DeleteAsync<Profile>(id, cancellationToken);

            return ServiceResponse.ForSuccess();
        }
    }

}
