using ProjectMSG.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Article
    {
        public Article()
        {
            Photo = new HashSet<Photo>();
            Test = new HashSet<Test>();
        }

        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleText { get; set; }
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Photo> Photo { get; set; }
        public virtual ICollection<Test> Test { get; set; }

        public static implicit operator Article(ContentViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
