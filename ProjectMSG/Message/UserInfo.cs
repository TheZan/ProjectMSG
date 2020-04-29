using System.Collections.Generic;

namespace ProjectMSG.Message
{
    public class UserInfo : IMessage
    {
        public UserInfo(List<Info> info)
        {
            this.info = info;
        }

        public List<Info> info { get; set; }
    }

    public class Info
    {
        public string Login { get; set; }
        public string Role { get; set; }
    }
}
