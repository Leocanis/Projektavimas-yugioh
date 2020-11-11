using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Core.Entities.HealthNs
{
    public class Health
    {
        public int healthCount { get; set; }

        public Health(int health)
        {
            this.healthCount = health;
        }
    }
}
