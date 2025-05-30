﻿using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Queries.GuideQueries;

namespace TraversalCoreProje.CQRS.Handers.GuideHanders
{
    public class GetGuideByIDQueryHandler: IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
             var values= await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIDQueryResult
            {
                GuideID = values.GuideID,
                Name = values.Name,
                Description = values.Description
            };
        }
    }
    
}
