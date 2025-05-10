using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handers.DestinationHanders
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommend commend)
        {
            var values = _context.Destinations.Find(commend.DestinationId);
            values.City = commend.City;
            values.DayNight = commend.DayNight;
            values.Price = commend.Price;
            _context.SaveChanges();
        }

    }

}
