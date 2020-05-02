using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Test
    {
        public Test()
        {
            Question = new HashSet<Question>();
            Result = new HashSet<Result>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
