namespace ProjectMSG.Message
{
    public class SectionToArticle : IMessage
    {
        public SectionToArticle(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
