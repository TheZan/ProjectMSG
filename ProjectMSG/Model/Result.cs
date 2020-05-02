using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int CountCorrect { get; set; }

        public virtual Test Test { get; set; }
        public virtual Users User { get; set; }
    }
}
