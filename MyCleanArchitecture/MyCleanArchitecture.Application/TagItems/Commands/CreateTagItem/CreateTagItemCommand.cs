using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCleanArchitecture.Application.Common.Interfaces;
using MyCleanArchitecture.Application.Common.Models;
using MyCleanArchitecture.Domain.Entities;

namespace MyCleanArchitecture.Application.TagItems.Commands.CreateTagItem
{
    public record CreateTagItemCommand : IRequest<Result<int>>
    {
        public required string Name { get; init; }
    }

    public class CreateTagItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTagItemCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<Result<int>> Handle(CreateTagItemCommand request, CancellationToken cancellationToken)
        {
            TagItem? entity = await _context.TagItems.SingleOrDefaultAsync(tag => tag.Name.ToUpper() == request.Name.ToUpper());
            if (entity is not null)
            {
                return Result<int>.Failure("Тег уже существует");
            }

            entity = new TagItem
            {
                Name = request.Name
            };

            _context.TagItems.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<int>.SuccessResult(entity.Id);
        }
    }
}
