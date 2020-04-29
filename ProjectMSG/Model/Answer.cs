using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Answer
    {
        public Answer()
        {
            CorrectAnswer = new HashSet<CorrectAnswer>();
        }

        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<CorrectAnswer> CorrectAnswer { get; set; }
    }
}
