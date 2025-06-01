#pragma warning disable SKEXP0070 // Type is for evaluation purposes only. Suppressing to proceed.

using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using Microsoft.SemanticKernel;

namespace SemanticKernel.Ollama.Chat.Services;

public static class OllamaChatService
{
    public static async Task RunChatLoopAsync(Kernel kernel, IChatCompletionService chatService)
    {
        var settings = new OllamaPromptExecutionSettings
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        };

        var history = new ChatHistory("When saving outputs to a file, if it is news make sure to include links");

        Console.WriteLine("Write your message to the AI bot");

        while (true)
        {
            var input = GetUserInput();
            if (string.IsNullOrEmpty(input))
                break;

            await HandleChatAsync(input, history, chatService, kernel, settings);
        }
    }

    private static async Task HandleChatAsync(
        string userInput,
        ChatHistory history,
        IChatCompletionService chatService,
        Kernel kernel,
        OllamaPromptExecutionSettings settings)
    {
        history.AddUserMessage(userInput);

        try
        {
            var result = await chatService.GetChatMessageContentAsync(
                history,
                executionSettings: settings,
                kernel: kernel);

            history.AddMessage(result.Role, result.Content ?? string.Empty);

            Console.WriteLine($"AI: {result.Content}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static string? GetUserInput()
    {
        Console.Write("You: ");
        return Console.ReadLine();
    }
}