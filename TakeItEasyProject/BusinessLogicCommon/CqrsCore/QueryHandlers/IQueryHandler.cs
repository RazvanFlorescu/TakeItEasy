using BusinessLogicCommon.CqrsCore.Queries;

namespace BusinessLogicCommon.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResult>
    where TQuery: IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
