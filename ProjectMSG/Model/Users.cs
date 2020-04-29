using System;
using System.Collections.Generic;

namespace ProjectMSG.Model
{
    public partial class Users
    {
        public Users()
        {
            Result = new HashSet<Result>();
        }

        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Result> Result { get; set; }
    }
}
