using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Badge
    {
        public Badge()
        {
            Result = new HashSet<Result>();
        }

        public int BadgeId { get; set; }
        public string BadgeName { get; set; }
        public byte[] BadgeImage { get; set; }
        public int TestId { get; set; }

        public virtual Test Test { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
