using Bible.Crawler.Abstractions.Structures;

namespace Bible.Crawler.Abstractions;

/// <summary>
/// 모든 성경 Crawler Class 가 구현해야 하는 Interface 입니다.
/// </summary>
public interface IBibleCrawler
{
    /// <summary>
    /// 현재 성경 역본을 가져옵니다.
    /// </summary>
    VersionType CurrentVersion { get; }

    /// <summary>
    /// 지원하는 성경 역본을 가져옵니다.
    /// </summary>
    VersionType SupportVersion { get; }

    /// <summary>
    /// 성경의 책 정보를 비동기로 순차적으로 가져옵니다.
    /// </summary>
    /// <returns> 성경의 책 정보가 있는 <see cref="Book" /> 구조체를 순차적으로 반환합니다. </returns>
    IAsyncEnumerable<Book> GetBooksAsync();

    /// <summary>
    /// 성경의 장 정보를 비동기로 순차적으로 가져옵니다.
    /// </summary>
    /// <param name="book"> 성경 책 정보입니다. </param>
    /// <returns> 성경의 장 정보가 있는 <see cref="Chapter" /> 구조체를 순차적으로 반환합니다. </returns>
    IAsyncEnumerable<Chapter> GetChaptersAsync(Book book);

    /// <summary>
    /// 성경의 구절 정보를 순차적으로 가져옵니다.
    /// </summary>
    /// <param name="chapter"> 성경 장 정보입니다. </param>
    /// <returns> 성경의 구절 정보가 있는 <see cref="Verse" /> 구조체를 순차적으로 반환합니다. </returns>
    IAsyncEnumerable<Verse> GetVersesAsync(Chapter chapter);
}
