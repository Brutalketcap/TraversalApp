using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Commands.GuideCommands;

namespace TraversalCoreProje.CQRS.Handers.GuideHanders
{
    public class CreateGuideCommentHendler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommentHendler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
