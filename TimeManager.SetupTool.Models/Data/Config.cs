using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.SetupTool.Models
{
    public class Config
    {
        public UsersData usersdata { get; set; }
        public string[] vhosts { get; set; }
        public Names names { get; set; }
    }

    public class UsersData
    {
        public string[] name { get; set; }
        public string[] password_hash { get; set; }
        public string[][] tags { get; set; }

    }

    public class Names
    {
        public string[] reply { get; set; }
        public string[] queues { get; set; }
        public string[] exchanges { get; set; }
        public string[] routingKey { get; set; }

    }

}
