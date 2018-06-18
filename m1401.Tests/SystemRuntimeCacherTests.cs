using Xunit;
using Xunit.Abstractions;

namespace m1401.Tests
{
    public class SystemRuntimeCacherTests
    {
        private readonly ITestOutputHelper _output;

        public SystemRuntimeCacherTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void GetSequenceTest()
        {
            var fib = new FibonacciGenerator(new SystemRuntimeCacher());

            for (var i = 0; i < 20; i++)
            {
                _output.WriteLine($"{fib.Next}");
            }
        }
    }
}
