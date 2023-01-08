using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TimeManager.SetupTool.Models
{
    public class Definitions
    {
        public List<Users> users { get; set; } = new List<Users> { };
        public List<Vhosts> vhosts { get; set; } = new List<Vhosts> { };
        public List<Permissions> permissions { get; set; } = new List<Permissions> { };
        public List<Queues> queues { get; set; } = new List<Queues> { };
        public List<Exchanges> exchanges { get; set; } = new List<Exchanges> { };
        public List<Bindings> bindings { get; set; } = new List<Bindings> { };
    }

    public class Users
    {
        public string name { get; set; }
        public string password_hash { get; set; }
        public string hashing_algorithm { get; set; } = "rabbit_password_hashing_sha256";
        public string[] tags { get; set; }
        public Limits limits { get; set; } = new Limits();
    }

    public class Vhosts
    {
        public string name { get; set; }
    }

    public class Permissions
    {
        public string user { get; set; }
        public string vhost { get; set; } = "/";
        public string configure { get; set; } = ".*";
        public string write { get; set; } = ".*";
        public string read { get; set; } = ".*";

    }

    public class Queues
    {
        public string name { get; set; }
        public string? vhost { get; set; } = "/";
        public bool? durable { get; set; } = true;
        public bool? auto_delete { get; set; } = false;
        public Arguments arguments { get; set; } = new Arguments() { xqueuemode = "lazy", xqueuetype ="classic"};
    }

    public class Exchanges
    {
        public string? name { get; set; }
        public string? vhost { get; set; } = "/";
        public string? type { get; set; } = "direct";
        public bool? durable { get; set; } = true;
        public bool? auto_delete{ get; set; } = false;
        public bool? @internal { get; set; } = false;
        public Object? arguments { get; set; } = new Object();
    }

    public class Bindings
    {
        public string? source { get; set; }
        public string? vhost { get; set; } = "/";
        public string? destination { get; set; }
        public string? destination_type { get; set; } = "queue";
        public string? routing_key { get; set; }
        public Object? arguments { get; set; } = new Object();
    }

    public class Arguments
    {
        [JsonProperty(PropertyName = "x-queue-mode")]
        public string? xqueuemode { get; set; } = null;

        [JsonProperty(PropertyName = "x-queue-type")]
        public string? xqueuetype { get; set; } = null;
    }

    public class Limits
    {

    }
}
