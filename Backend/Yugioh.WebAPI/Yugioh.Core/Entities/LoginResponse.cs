using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Core.Entities
{
    public class LoginResponse
    {
        public Guid gameId { get; set; }
        public Guid playerId { get; set; }
    }
}
