using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class HotDogStand : BaseEntity
    {
        public string Address { get; set; }
        public virtual ICollection<HotDogStandProduct> StandProducts { get; set; }
    }
}
