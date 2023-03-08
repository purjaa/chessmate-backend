using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmate.Core.Entities;

public class AllOnlineUsersMessage
{
    public List<string> Users { get; set; }
    public AllOnlineUsersMessage(List<string> users)
    {
        Users = users;
    }
}
