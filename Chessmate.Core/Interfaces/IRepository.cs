using Ardalis.Specification;

namespace Chessmate.Core.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}