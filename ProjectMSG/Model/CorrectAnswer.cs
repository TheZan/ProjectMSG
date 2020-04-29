using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class CorrectAnswer
    {
        public int CorrectAnswerId { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
    }
}
