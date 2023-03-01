using Chessmate.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chessmate.Infrastructure.Data;

public class UserStateContext : DbContext
{
    #pragma warning disable CS8618 // Required by Entity Framework
    public UserStateContext(DbContextOptions<UserStateContext> options) : base(options) { }

    public DbSet<UserState> UserStates { get; set; }
}
