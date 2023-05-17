namespace DDDFramework.Core.Application.Contracts;

public interface IQueryHandler<in TQuery,TResult> where TQuery:IQuery<TResult>
{
    Task<TResult> Handle(TQuery query);
}