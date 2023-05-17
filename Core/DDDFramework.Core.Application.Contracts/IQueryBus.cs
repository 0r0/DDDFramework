namespace DDDFramework.Core.Application.Contracts;

public interface IQueryBus
{
    Task<TResult> Execute<TQuery,TResult>(TQuery query) where TQuery : IQuery<TResult>;
}