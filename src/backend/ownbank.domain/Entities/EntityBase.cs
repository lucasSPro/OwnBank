using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ownbank.domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
