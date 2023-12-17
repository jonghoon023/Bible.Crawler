using Bible.Crawler.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Crawler.Extensions;

/// <summary>
/// <see cref="IServiceCollection" /> 에 대한 확장 함수가 있는 정적 Class 입니다.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// <see cref="IBibleCrawlerFactory" /> 의 구현체를 등록 후 <see cref="IServiceCollection" /> 구현체를 반환합니다.
    /// </summary>
    /// <param name="services"> <see cref="IBibleCrawlerFactory" /> 의 구현체를 등록할 <see cref="IServiceCollection" /> 구현체입니다. </param>
    /// <returns> <see cref="IBibleCrawlerFactory" /> 의 구현체를 등록한 <see cref="IServiceCollection" /> 구현체를 반환합니다.  </returns>
    public static IServiceCollection AddBibleCrawlerFactory(this IServiceCollection services)
    {
        return services.AddSingleton<IBibleCrawlerFactory, BibleCrawlerFactory>();
    }
}
