using Feijuca.Auth.Common.Errors;
using Mattioli.Configurations.Models;
using Feijuca.Auth.Domain.Interfaces;
using LiteBus.Commands.Abstractions;

namespace Feijuca.Auth.Application.Commands.ClientScopeMapper
{
    public class AddClientScopeMapperCommandHandler(IClientScopesRepository clientScopesRepository) : ICommandHandler<AddClientScopeMapperCommand, Result<bool>>
    {
        public async Task<Result<bool>> HandleAsync(AddClientScopeMapperCommand request, CancellationToken cancellationToken)
        {
            var result = await clientScopesRepository.AddUserPropertyMapperAsync(request.ClientScopeId, request.UserPropertyName, request.ClaimName, cancellationToken);
            if (result)
            {
                return Result<bool>.Success(true);
            }

            return Result<bool>.Failure(ClientScopesErrors.CreateAudienceMapperProtocolError);
        }
    }
}
