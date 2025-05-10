using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Result.DestinationResults;

namespace TraversalCoreProje.CQRS.Handers.DestinationHanders
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values= _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationId = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,

            };

        }  
    }
}
