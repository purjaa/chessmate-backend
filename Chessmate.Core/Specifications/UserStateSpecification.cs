using Ardalis.Specification;
using Chessmate.Core.Entities;

namespace Chessmate.Core.Specifications;

public class UserStateSpecification : Specification<UserState>, ISingleResultSpecification
{
    public UserStateSpecification(string username)
    {
        Query.Where(userState => userState.Username == username);
    }
}
