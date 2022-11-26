using Xunit;
using Amazon.Lambda.TestUtilities;

namespace GatewayLambda.Demo.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var upperCase = function.FunctionHandler(context);
            Assert.Equal("Helo World", upperCase);
        }
    }
}
