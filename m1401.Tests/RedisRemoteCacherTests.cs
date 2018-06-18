using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace m1401.Tests
{
    public class RedisRemoteCacherTests
    {
        private readonly ITestOutputHelper _output;

        private readonly IConfiguration _configuration =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("redissettings.real.json")
                .Build();


        public RedisRemoteCacherTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void GetSequenceTest()
        {
            var fib = new FibonacciGenerator(
                new RedisRemoteCacher(_configuration["redis:endpoint"],
                                      _configuration["redis:password"]));

            for (var i = 0; i < 20; i++)
            {
                _output.WriteLine($"{fib.Next}");
            }
        }
    }
}
