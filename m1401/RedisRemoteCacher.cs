using StackExchange.Redis;

namespace m1401
{
    public class RedisRemoteCacher : ICacher
    {
        private readonly IDatabase _cache;

        public RedisRemoteCacher(string endpoint, string password)
        {
            this._cache = ConnectionMultiplexer
                .Connect($"{endpoint},password={password}")
                .GetDatabase();
        }

        public int Previous
        {
            get => (int)this._cache.StringGet("previous");
            set => this._cache.StringSet("previous", value.ToString());
        }

        public int Current
        {
            get => (int)this._cache.StringGet("current");
            set => this._cache.StringSet("current", value.ToString());
        }

        ~RedisRemoteCacher()
        {
            _cache.KeyDelete("previous");
            _cache.KeyDelete("current");
        }
    }
}
