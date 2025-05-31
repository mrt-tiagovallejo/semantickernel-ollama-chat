using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SemanticKernel.Ollama.Chat.Plugins;

public class ArchivePlugin
{
    [KernelFunction("archive_data")]
    [Description("Saves data to a file on computer")]
    public async Task WriteData(Kernel kernel, string filename, string data)
    {
        await File.WriteAllTextAsync($"{filename}.txt", data);
    }
}
