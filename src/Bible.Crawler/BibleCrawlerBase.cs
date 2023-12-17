using System.Text;
using HtmlAgilityPack;
using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;

namespace Bible.Crawler;

/// <summary>
/// <see cref="IBibleCrawler" /> 의 추상 Class 구현체입니다.
/// </summary>
internal abstract class BibleCrawlerBase : IBibleCrawler
{
    private readonly HtmlWeb _htmlWeb;

    /// <summary>
    /// <see cref="BibleCrawlerBase" /> 를 초기화합니다.
    /// </summary>
    /// <param name="version"> 성경 역본입니다. </param>
    /// <param name="uri"> 성경을 읽어올 수 있는 Uri 주소 정보가 있는 <see cref="System.Uri" /> 객체입니다. </param>
    protected BibleCrawlerBase(VersionType version, string uri)
    {
        if (!SupportVersion.HasFlag(version))
        {
            throw new NotSupportedException($"{version} 에 대한 성경 역본은 지원하지 않습니다.");
        }

        if (Uri.TryCreate(uri, UriKind.Absolute, out Uri? baseUri))
        {
            BaseUri = baseUri;
        }

        _htmlWeb = new HtmlWeb();
        CurrentVersion = version;

        ArgumentNullException.ThrowIfNull(BaseUri);
    }

    /// <inheritdoc cref="IBibleCrawler.CurrentVersion" />
    public VersionType CurrentVersion { get; }

    /// <inheritdoc cref="IBibleCrawler.SupportVersion" />
    public abstract VersionType SupportVersion { get; }

    /// <summary>
    /// 성경을 읽어올 수 있는 기본 Uri 주소를 가져옵니다.
    /// </summary>
    protected Uri BaseUri { get; }

    /// <inheritdoc cref="IBibleCrawler.GetBooksAsync" />
    public abstract IAsyncEnumerable<Book> GetBooksAsync();

    /// <inheritdoc cref="IBibleCrawler.GetChaptersAsync(Book)" />
    public abstract IAsyncEnumerable<Chapter> GetChaptersAsync(Book book);

    /// <inheritdoc cref="IBibleCrawler.GetVersesAsync(Chapter)" />
    public abstract IAsyncEnumerable<Verse> GetVersesAsync(Chapter chapter);

    /// <summary>
    /// <see cref="Chapter" /> 정보를 가져올 수 있는 <see cref="Uri" /> 주소를 가져옵니다.
    /// </summary>
    /// <param name="book"> 성경의 책 정보가 있는 <see cref="Book" /> 구조체입니다.  </param>
    /// <returns> <see cref="Uri" /> 객체를 가져옵니다. </returns>
    protected abstract Uri GetChapterUri(Book book);

    /// <summary>
    /// <see cref="Verse" /> 정보를 가져올 수 있는 <see cref="Uri" /> 주소를 가져옵니다.
    /// </summary>
    /// <param name="chapter"> 성경의 장 정보가 있는 <see cref="Chapter" /> 구조체입니다.  </param>
    /// <returns> <see cref="Uri" /> 객체를 가져옵니다. </returns>
    protected abstract Uri GetVerseUri(Chapter chapter);

    /// <summary>
    /// <see cref="Uri" /> 주소의 Web Page 를 읽어온 후 <see cref="HtmlDocument" /> 객체로 변환하여 가져옵니다.
    /// </summary>
    /// <param name="uri"> Web Page 의 주소가 담긴 <see cref="Uri" /> 객체입니다. </param>
    /// <returns> <see cref="HtmlDocument" /> 객체로 가져옵니다. </returns>
    protected Task<HtmlDocument> LoadAsync(Uri uri)
    {
        return _htmlWeb.LoadFromWebAsync(uri, Encoding.UTF8, null);
    }
}
