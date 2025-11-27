using Feijuca.Auth.Application.Mappers;
using Feijuca.Auth.Domain.Interfaces;
using Feijuca.Auth.Application.Responses;
using LiteBus.Queries.Abstractions;

namespace Feijuca.Auth.Application.Queries.ClientScopes;

public class GetClientScopesQueryHandler(IClientScopesRepository clientScopesRepository) : IQueryHandler<GetClientScopesQuery, IEnumerable<ClientScopesResponse>>
{
    public async Task<IEnumerable<ClientScopesResponse>> HandleAsync(GetClientScopesQuery request, CancellationToken cancellationToken)
    {
        var scopes = await clientScopesRepository.GetClientScopesAsync(cancellationToken);
        return scopes.ToClientScopesResponse();
    }
}
