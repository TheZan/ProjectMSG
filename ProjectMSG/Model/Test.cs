using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Test
    {
        public Test()
        {
            Badge = new HashSet<Badge>();
            Question = new HashSet<Question>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual ICollection<Badge> Badge { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
