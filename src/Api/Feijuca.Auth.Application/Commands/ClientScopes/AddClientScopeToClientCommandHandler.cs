using Feijuca.Auth.Common.Errors;
using Mattioli.Configurations.Models;
using Feijuca.Auth.Domain.Interfaces;
using LiteBus.Commands.Abstractions;

namespace Feijuca.Auth.Application.Commands.ClientScopes
{
    public class AddClientScopeToClientCommandHandler(IClientScopesRepository clientScopesRepository) : ICommandHandler<AddClientScopeToClientCommand, Result<bool>>
    {
        public async Task<Result<bool>> HandleAsync(AddClientScopeToClientCommand request, CancellationToken cancellationToken)
        {
            var result = await clientScopesRepository.AddClientScopeToClientAsync(
                request.AddClientScopeToClientRequest.ClientId, 
                request.AddClientScopeToClientRequest.ClientScopeId,
                request.AddClientScopeToClientRequest.IsOpticionalScope, 
                cancellationToken);

            if(result)
                return Result<bool>.Success(true);

            return Result<bool>.Failure(ClientErrors.AddClientRoleError);
        }
    }
}
