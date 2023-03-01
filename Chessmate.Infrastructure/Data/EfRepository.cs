using Ardalis.Specification.EntityFrameworkCore;
using Chessmate.Core.Interfaces;

namespace Chessmate.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(UserStateContext dbContext) : base(dbContext)
    {
    }
}
