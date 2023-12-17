using Xunit;
using Bible.Crawler.Extensions;
using Bible.Crawler.Abstractions;
using Bible.Crawler.Abstractions.Structures;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Crawler.Tests;

/// <summary>
/// Godpia 기반의 <see cref="IBibleCrawler" /> 의 구현체를 Test 합니다.
/// </summary>
public sealed class GodpiaCrawlerTests
{
    [Theory]
    [InlineData(VersionType.SAE)]
    [InlineData(VersionType.COG)]
    [InlineData(VersionType.CEV)]
    public void GivenNotSupportedVersion_WhenCreate_ThenThrowNotSupportedException(VersionType notSupportedVersion)
    {
        // When / Then
        Assert.Throws<NotSupportedException>(() => GetGodpiaCrawler(notSupportedVersion));
    }

    [Fact]
    public void GivenGAE_WhenGetBooksAsync_ThenBookCountIs66()
    {
        // Given
        IBibleCrawler crawler = GetGodpiaCrawler(VersionType.GAE);

        // When
        Book[] books = crawler.GetBooksAsync().ToBlockingEnumerable().ToArray();

        // Then
        Assert.Equal(66, books.Length);
    }

    [Theory]
    [InlineData(TestamentType.TheOldTestament, "gen", "창세기", 50)]
    [InlineData(TestamentType.TheOldTestament, "exo", "출애굽기", 40)]
    [InlineData(TestamentType.TheOldTestament, "lev", "레위기", 27)]
    [InlineData(TestamentType.TheOldTestament, "num", "민수기", 36)]
    [InlineData(TestamentType.TheOldTestament, "deu", "신명기", 34)]
    [InlineData(TestamentType.TheOldTestament, "jos", "여호수아", 24)]
    [InlineData(TestamentType.TheOldTestament, "jdg", "사사기", 21)]
    [InlineData(TestamentType.TheOldTestament, "rut", "룻기", 4)]
    [InlineData(TestamentType.TheOldTestament, "1sa", "사무엘상", 31)]
    [InlineData(TestamentType.TheOldTestament, "2sa", "사무엘하", 24)]
    [InlineData(TestamentType.TheOldTestament, "1ki", "열왕기상", 22)]
    [InlineData(TestamentType.TheOldTestament, "2ki", "열왕기하", 25)]
    [InlineData(TestamentType.TheOldTestament, "1ch", "역대상", 29)]
    [InlineData(TestamentType.TheOldTestament, "2ch", "역대하", 36)]
    [InlineData(TestamentType.TheOldTestament, "ezr", "에스라", 10)]
    [InlineData(TestamentType.TheOldTestament, "neh", "느헤미야", 13)]
    [InlineData(TestamentType.TheOldTestament, "est", "에스더", 10)]
    [InlineData(TestamentType.TheOldTestament, "job", "욥기", 42)]
    [InlineData(TestamentType.TheOldTestament, "psa", "시편", 150)]
    [InlineData(TestamentType.TheOldTestament, "pro", "잠언", 31)]
    [InlineData(TestamentType.TheOldTestament, "ecc", "전도서", 12)]
    [InlineData(TestamentType.TheOldTestament, "sng", "아가", 8)]
    [InlineData(TestamentType.TheOldTestament, "isa", "이사야", 66)]
    [InlineData(TestamentType.TheOldTestament, "jer", "예레미야", 52)]
    [InlineData(TestamentType.TheOldTestament, "lam", "예레미야애가", 5)]
    [InlineData(TestamentType.TheOldTestament, "ezk", "에스겔", 48)]
    [InlineData(TestamentType.TheOldTestament, "dan", "다니엘", 12)]
    [InlineData(TestamentType.TheOldTestament, "hos", "호세아", 14)]
    [InlineData(TestamentType.TheOldTestament, "jol", "요엘", 3)]
    [InlineData(TestamentType.TheOldTestament, "amo", "아모스", 9)]
    [InlineData(TestamentType.TheOldTestament, "oba", "오바댜", 1)]
    [InlineData(TestamentType.TheOldTestament, "jnh", "요나", 4)]
    [InlineData(TestamentType.TheOldTestament, "mic", "미가", 7)]
    [InlineData(TestamentType.TheOldTestament, "nam", "나훔", 3)]
    [InlineData(TestamentType.TheOldTestament, "hab", "하박국", 3)]
    [InlineData(TestamentType.TheOldTestament, "zep", "스바냐", 3)]
    [InlineData(TestamentType.TheOldTestament, "hag", "학개", 2)]
    [InlineData(TestamentType.TheOldTestament, "zec", "스가랴", 14)]
    [InlineData(TestamentType.TheOldTestament, "mal", "말라기", 4)]
    [InlineData(TestamentType.TheNewTestament, "mat", "마태복음", 28)]
    [InlineData(TestamentType.TheNewTestament, "mrk", "마가복음", 16)]
    [InlineData(TestamentType.TheNewTestament, "luk", "누가복음", 24)]
    [InlineData(TestamentType.TheNewTestament, "jhn", "요한복음", 21)]
    [InlineData(TestamentType.TheNewTestament, "act", "사도행전", 28)]
    [InlineData(TestamentType.TheNewTestament, "rom", "로마서", 16)]
    [InlineData(TestamentType.TheNewTestament, "1co", "고린도전서", 16)]
    [InlineData(TestamentType.TheNewTestament, "2co", "고린도후서", 13)]
    [InlineData(TestamentType.TheNewTestament, "gal", "갈라디아서", 6)]
    [InlineData(TestamentType.TheNewTestament, "eph", "에베소서", 6)]
    [InlineData(TestamentType.TheNewTestament, "php", "빌립보서", 4)]
    [InlineData(TestamentType.TheNewTestament, "col", "골로새서", 4)]
    [InlineData(TestamentType.TheNewTestament, "1th", "데살로니가전서", 5)]
    [InlineData(TestamentType.TheNewTestament, "2th", "데살로니가후서", 3)]
    [InlineData(TestamentType.TheNewTestament, "1ti", "디모데전서", 6)]
    [InlineData(TestamentType.TheNewTestament, "2ti", "디모데후서", 4)]
    [InlineData(TestamentType.TheNewTestament, "tit", "디도서", 3)]
    [InlineData(TestamentType.TheNewTestament, "phm", "빌레몬서", 1)]
    [InlineData(TestamentType.TheNewTestament, "heb", "히브리서", 13)]
    [InlineData(TestamentType.TheNewTestament, "jas", "야고보서", 5)]
    [InlineData(TestamentType.TheNewTestament, "1pe", "베드로전서", 5)]
    [InlineData(TestamentType.TheNewTestament, "2pe", "베드로후서", 3)]
    [InlineData(TestamentType.TheNewTestament, "1jn", "요한1서", 5)]
    [InlineData(TestamentType.TheNewTestament, "2jn", "요한2서", 1)]
    [InlineData(TestamentType.TheNewTestament, "3jn", "요한3서", 1)]
    [InlineData(TestamentType.TheNewTestament, "jud", "유다서", 1)]
    [InlineData(TestamentType.TheNewTestament, "rev", "요한계시록", 22)]
    public void GivenBook_WhenGetChaptersAsync_ThenEqualsExpectedCount(TestamentType testament, string abbreviationKey, string name, int expectedCount)
    {
        // Given
        Book book = new(testament, abbreviationKey, name);
        IBibleCrawler crawler = GetGodpiaCrawler(VersionType.GAE);

        // When
        Chapter[] chapters = crawler.GetChaptersAsync(book).ToBlockingEnumerable().ToArray();

        // Then
        Assert.Equal(expectedCount, chapters.Length);
    }

    private static IBibleCrawler GetGodpiaCrawler(VersionType version)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddBibleCrawlerFactory();

        IServiceProvider provider = services.BuildServiceProvider();
        IBibleCrawlerFactory factory = provider.GetRequiredService<IBibleCrawlerFactory>();

        return factory.CreateGodpiaCrawler(version);
    }
}
