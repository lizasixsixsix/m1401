using System.Runtime.Caching;

namespace m1401
{
    public class SystemRuntimeCacher : ICacher
    {
        private readonly ObjectCache _cache = MemoryCache.Default;

        private readonly CacheItemPolicy _policy = new CacheItemPolicy();

        public int Previous
        {
            get => (int)this._cache["previous"];
            set => this._cache.Set("previous", value, this._policy);
        }

        public int Current
        {
            get => (int)this._cache["current"];
            set => this._cache.Set("current", value, this._policy);
        }

        ~SystemRuntimeCacher()
        {
            _cache.Remove("previous");
            _cache.Remove("current");
        }
    }
}
