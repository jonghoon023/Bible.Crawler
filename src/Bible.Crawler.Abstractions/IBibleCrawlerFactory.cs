using Bible.Crawler.Abstractions.Structures;

namespace Bible.Crawler.Abstractions;

/// <summary>
/// <see cref="IBibleCrawler" /> 의 구현체를 생성하는 Factory Service 입니다. 
/// </summary>
public interface IBibleCrawlerFactory
{
    /// <summary>
    /// <c> GODpia </c> 의 성경을 읽어오는 <see cref="IBibleCrawler" /> 의 구현체를 생성합니다.
    /// </summary>
    /// <remarks>
    /// 지원하는 성경 역본 종류는 아래와 같습니다. <br /> <br />
    /// <see cref="VersionType.GAE" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.NIV" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.HAN" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.EASY" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.COGNEW" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.HYUN" /> 역본을 지원합니다. <br />
    /// <see cref="VersionType.SAENEW" /> 역본을 지원합니다. <br />
    /// </remarks>
    /// <param name="version"> <c> GODpia </c> 에서 읽어올 성경 역본입니다. </param>
    /// <returns> <see cref="IBibleCrawler" /> 의 구현체를 생성하여 가져옵니다. </returns>
    /// <exception cref="NotSupportedException"> <paramref name="version" /> 의 값이 지원하지 않는 성경 역본일 때 발생합니다. </exception>
    IBibleCrawler CreateGodpiaCrawler(VersionType version);
}
