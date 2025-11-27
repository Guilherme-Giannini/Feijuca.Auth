using Feijuca.Auth.Application.Mappers;
using Feijuca.Auth.Common.Errors;
using Mattioli.Configurations.Models;
using Feijuca.Auth.Domain.Interfaces;
using LiteBus.Commands.Abstractions;

namespace Feijuca.Auth.Application.Commands.ClientScopes
{
    public class AddClientScopesCommandHandler(IClientScopesRepository clientScopesRepository) : ICommandHandler<AddClientScopesCommand, Result<bool>>
    {
        public async Task<Result<bool>> HandleAsync(AddClientScopesCommand command, CancellationToken cancellationToken)
        {
            foreach (var clientScope in command.AddClientScopesRequest)
            {
                var scopeEntity = clientScope.ToClientScopesEntity();
                var result = await clientScopesRepository.AddClientScopesAsync(scopeEntity, cancellationToken);

                if (!result)
                {
                    return Result<bool>.Failure(ClientScopesErrors.CreateClientScopesError);
                }
            }


            return Result<bool>.Success(true);
        }
    }
}
