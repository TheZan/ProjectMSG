using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Photo
    {
        public int ArticlePhotoId { get; set; }
        public byte[] ArticlePhoto { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
