using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Section
    {
        public Section()
        {
            Article = new HashSet<Article>();
        }

        public int SectionId { get; set; }
        public string SectionName { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
