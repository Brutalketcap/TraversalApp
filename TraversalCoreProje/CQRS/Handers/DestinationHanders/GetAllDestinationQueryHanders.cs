using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Result.DestinationResults;

namespace TraversalCoreProje.CQRS.Handers.DestinationHanders
{
    public class GetAllDestinationQueryHanders
    {
        private readonly Context _context;

        public GetAllDestinationQueryHanders(Context context)
        {
            _context = context;
        }
        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id=x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price
            }).AsNoTracking().ToList();
           
            return values;

        }
    }
}
