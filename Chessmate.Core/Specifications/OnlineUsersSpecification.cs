
using Ardalis.Specification;
using Chessmate.Core.Entities;

namespace Chessmate.Core.Specifications;

public class OnlineUsersSpecification : Specification<UserState>
{
    public OnlineUsersSpecification()
    {
        Query.Where(userState => userState.IsOnline);
    }
}
