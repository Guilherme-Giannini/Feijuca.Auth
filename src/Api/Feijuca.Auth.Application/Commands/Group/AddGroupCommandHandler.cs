using Mattioli.Configurations.Models;
using Feijuca.Auth.Domain.Interfaces;
using LiteBus.Commands.Abstractions;

namespace Feijuca.Auth.Application.Commands.Group
{
    public class AddGroupCommandHandler(IGroupRepository groupRepository) : ICommandHandler<AddGroupCommand, Result<bool>>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;

        public async Task<Result<bool>> HandleAsync(AddGroupCommand request, CancellationToken cancellationToken)
        {
            var result = await _groupRepository.CreateAsync(request.AddGroupRequest.Name, request.AddGroupRequest.Attributes, cancellationToken);
            if (result.IsSuccess)
            {
                return Result<bool>.Success(true);
            }

            return Result<bool>.Failure(result.Error);
        }
    }
}
