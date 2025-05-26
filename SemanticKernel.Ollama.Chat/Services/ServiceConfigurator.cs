#pragma warning disable SKEXP0070 // Type is for evaluation purposes only. Suppressing to proceed.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

public static class ServiceConfigurator
{
    public static Kernel BuildKernel(IConfiguration configuration)
    {
        var model = configuration["Ollama:ModelName"];
        var uri = configuration["Ollama:BaseUri"];

        if (model == null || uri == null )
        {
            throw new ArgumentNullException("Invalid config!");
        }

        var builder = Kernel
            .CreateBuilder()
            .AddOllamaChatCompletion(model, new Uri(uri));

        builder.Services.AddLogging(logging => logging
            .AddConsole()
            .SetMinimumLevel(LogLevel.Warning));

        return builder.Build();
    }
}