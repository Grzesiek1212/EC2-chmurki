using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

// UWAGA: Ta linia odpowiada za serializację JSON wejścia i wyjścia
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LogBackupEvent;

public class Function
{
    public Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
    {
        string region = input?.QueryStringParameters?["region"] ?? "unknown";
        string message = input?.QueryStringParameters?["message"] ?? "Brak wiadomości";

        context.Logger.LogLine($"[BackupLog] Region: {region} | Wiadomość: {message} | Timestamp: {DateTime.UtcNow}");

        return Task.FromResult(new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = "Backup został zalogowany."
        });
    }
}
