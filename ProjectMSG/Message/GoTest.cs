namespace ProjectMSG.Message
{
    public class GoTest : IMessage
    {
        public GoTest(int testId)
        {
            TestId = testId;
        }

        public int TestId { get; set; }
    }
}