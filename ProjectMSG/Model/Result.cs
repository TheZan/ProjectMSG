using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public int BadgeId { get; set; }

        public virtual Badge Badge { get; set; }
        public virtual Users User { get; set; }
    }
}
