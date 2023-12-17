using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;

namespace Bible.Crawler;

/// <summary>
/// <see cref="IBibleCrawlerFactory" /> 의 구현체입니다.
/// </summary>
internal sealed class BibleCrawlerFactory : IBibleCrawlerFactory
{
    /// <inheritdoc cref="IBibleCrawlerFactory.CreateGodpiaCrawler(VersionType)" />
    public IBibleCrawler CreateGodpiaCrawler(VersionType version)
    {
        return new GodpiaCrawler(version);
    }
}
