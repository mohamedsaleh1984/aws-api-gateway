using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;
using System.Xml.Linq;
using System.Collections.Generic;

namespace GatewayLambda.Demo.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestAPIResponseWithQueryParameter()
        {
            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var request = new APIGatewayProxyRequest()
            {
                Path = "/prod?name=Mohamed",
                QueryStringParameters = new Dictionary<string, string>
                {
                    {"name","Mohamed" }
                }
            };

            var expected =  new APIGatewayProxyResponse()
            {
                StatusCode = 200,
                Body = $"User name passed : Mohamed"
            };

            var actual = function.FunctionHandler(request, context);

            Assert.Equal(expected.Body, actual.Body);
        }
        [Fact]
        public void TestAPIResponseWithoutQueryParameter()
        {
            var function = new Function();
            var context = new TestLambdaContext();
            var request = new APIGatewayProxyRequest
            {
                Path = "/"
            };

            var expected = new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = $"User name passed : No-Name",
            };

            var actual = function.FunctionHandler(request, context);

            Assert.Equal(expected.Body, actual.Body);
        }
    }
}
