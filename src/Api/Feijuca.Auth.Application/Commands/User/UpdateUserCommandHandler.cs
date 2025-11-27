using Feijuca.Auth.Application.Mappers;
using Mattioli.Configurations.Models;
using Feijuca.Auth.Domain.Interfaces;
using Feijuca.Auth.Services;
using LiteBus.Commands.Abstractions;

namespace Feijuca.Auth.Application.Commands.User
{
    public class UpdateUserCommandHandler(IUserRepository _userRepository, ITenantService tenantService) : ICommandHandler<UpdateUserCommand, Result<bool>>
    {
        public async Task<Result<bool>> HandleAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.UserRequest.ToDomain(tenantService.Tenant.Name);
            var result = await _userRepository.UpdateUserAsync(request.Id, user, cancellationToken);
            return result;
        }
    }
}
