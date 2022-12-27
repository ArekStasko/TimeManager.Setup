using TimeManager.Setup.Services;
using Newtonsoft.Json;

namespace TimeManager.Setup.ConfigBuilder
{
    public class MQDefinitionsBuilder
    {
        public Config configFile { get; set; }
        public Definitions definitions { get; set; }


        public MQDefinitionsBuilder()
        {
            configFile = BuildConfig();
            definitions = BuildDefinitions();
        }

        private Config BuildConfig()
        {
            string path = PathService.GetConfigFilePath();           
            string file = File.ReadAllText($"{path}\\config\\definitions_data.json");
            return JsonConvert.DeserializeObject<Config>(file);
        }

        public Definitions BuildDefinitions()
        {
            var definitions = new Definitions();

            for (int i = 0; i < configFile.usersdata.name.Length; i++)
            {
                var user = new Users()
                {
                    name = configFile.usersdata.name[i],
                    password_hash = configFile.usersdata.password_hash[i],
                    tags = configFile.usersdata.tags[i]
                };
                definitions.users.Add(user);

                var permission = new Permissions()
                {
                    user = configFile.usersdata.name[i]
                };
                definitions.permissions.Add(permission);

            }

            for (int i = 0; i < configFile.vhosts.Length; i++) definitions.vhosts.Add(new Vhosts() { name = configFile.vhosts[i] });


            for (int i = 0; i < configFile.names.queues.Length; i++)
            {
                var queue = new Queues()
                {
                    name = configFile.names.queues[i]
                };
                definitions.queues.Add(queue);

                var binding = new Bindings()
                {
                    source = configFile.names.exchanges[i],
                    destination =configFile.names.queues[i],
                    routing_key = configFile.names.routingKey[i]
                };
                definitions.bindings.Add(binding);

                var exchange = new Exchanges()
                {
                    name = configFile.names.exchanges[i]
                };
                definitions.exchanges.Add(exchange);
            }

            for (int i = 0; i < configFile.names.reply.Length; i++)
            {
                var replyQueue = new Queues()
                {
                    name = configFile.names.reply[i]
                };
                definitions.queues.Add(replyQueue);

            }

            return definitions;
        }


        public void Execute()
        {
            var definitionsData = JsonConvert.SerializeObject(definitions);
            string path = $"{PathService.GetConfigFilePath()}\\rabbitmq\\definitions.json";


            FileService.CreateFile(path);
            FileService.WriteData($"{PathService.GetConfigFilePath()}\\rabbitmq\\definitions.json", definitionsData);
        }
    }
}
