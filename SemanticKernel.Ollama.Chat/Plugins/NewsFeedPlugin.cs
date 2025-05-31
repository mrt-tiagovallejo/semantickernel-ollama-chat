using Microsoft.SemanticKernel;
using SimpleFeedReader;
using System.ComponentModel;

namespace SemanticKernel.Ollama.Chat.Plugins;

public class NewsFeedPlugin
{
    [KernelFunction("get_news")]
    [Description("Gets news from BBC News")]
    [return: Description("A list of current news")]
    public async Task<IEnumerable<FeedItem>> GetNews(Kernel kernel, string continent)
    {
        var reader = new FeedReader();
        return (await reader.RetrieveFeedAsync(
                $"https://feeds.bbci.co.uk/news/world/{continent.ToLower()}/rss.xml"))
            .Take(5)
            .ToList();
    }
}
