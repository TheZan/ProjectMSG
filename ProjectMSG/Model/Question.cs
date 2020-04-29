using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
            CorrectAnswer = new HashSet<CorrectAnswer>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }

        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<CorrectAnswer> CorrectAnswer { get; set; }
    }
}
