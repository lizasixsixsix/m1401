namespace m1401
{
    public class FibonacciGenerator
    {
        private readonly ICacher _cacher;

        public FibonacciGenerator(ICacher cacher)
        {
            this._cacher = cacher;

            this._cacher.Previous = -1;
            this._cacher.Current = 1;
        }

        public int Next
        {
            get
            {
                this._cacher.Current += this._cacher.Previous;

                this._cacher.Previous = this._cacher.Current - this._cacher.Previous;

                return this._cacher.Current;
            }
        }
    }
}
