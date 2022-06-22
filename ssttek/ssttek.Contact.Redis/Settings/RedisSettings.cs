using StackExchange.Redis;

namespace ssttek.Contact.Redis.Settings
{
    public class RedisSettings
    {
        private readonly string _host;

        private readonly int _port;

        private ConnectionMultiplexer _ConnectionMultiplexer;

        public RedisSettings(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _ConnectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => _ConnectionMultiplexer.GetDatabase(db);
    }
}
