using MediatR;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery: IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
