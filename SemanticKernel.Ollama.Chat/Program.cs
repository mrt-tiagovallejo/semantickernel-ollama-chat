using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel.ChatCompletion;
using SemanticKernel.Ollama.Chat.Services;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var kernel = ServiceConfigurator.BuildKernel(configuration);

await OllamaChatService.RunChatLoopAsync(
    kernel, 
    kernel.GetRequiredService<IChatCompletionService>());