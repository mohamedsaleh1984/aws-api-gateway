using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace GatewayLambda.Demo
{
    /*
     Deploy:
     dotnet lambda deploy-function GatewayLambdaDemo

    GateWay Link
    https://gn7pzmiiwl.execute-api.us-east-1.amazonaws.com/prod

     */
    public class Function
    {
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            string name = "No-Name";
            if(request.QueryStringParameters != null && request.QueryStringParameters.ContainsKey("name")) {
                name = request.QueryStringParameters["name"];
            }
            context.Logger.LogLine($"Got name {name}");
            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = $"User name passed : {name}",
            };
        }
    }
}