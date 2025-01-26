using Bible.Crawler.Models.Enums;
using Bible.Crawler.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Bible.Crawler.Extensions;

namespace Bible.Crawler
{
    /// <summary>
    /// Godpia 에 대한 <see cref="BibleCrawlerBase" /> 의 구현체입니다.
    /// </summary>
    internal sealed class GodpiaCrawler : BibleCrawlerBase
    {
        private const string VerseNumberClass = "num";
        private const string SelectOptionXPathFormat = "//select[@id='{0}']/option";
        private const string SpanXPathFormat = "//span[@class='{0}']";
        private readonly string _verseNumberXPath;

        /// <summary>
        /// <see cref="GodpiaCrawler" /> 를 초기화합니다.
        /// </summary>
        /// <param name="version"> 성경 역본입니다. </param>
        public GodpiaCrawler(VersionType version) : base(version, "http://bible.godpia.com/read/reading.asp")
        {
            _verseNumberXPath = $".//span[@class='{VerseNumberClass}']";
        }

        /// <inheritdoc cref="BibleCrawlerBase.SupportVersion" />
        public override VersionType SupportVersion => VersionType.GAE | VersionType.NIV | VersionType.HAN | VersionType.EASY | VersionType.COGNEW | VersionType.HYUN | VersionType.SAENEW;

        /// <inheritdoc cref="BibleCrawlerBase.GetBooksAsync" />
        public override async IAsyncEnumerable<Book> GetBooksAsync()
        {
            HtmlDocument htmlDocument = await LoadAsync(BaseUri).ConfigureAwait(false);

            string theOldTestamentXPath = string.Format(CultureInfo.InvariantCulture, SelectOptionXPathFormat, "selectBibleSub1");
            string theNewTestamentXPath = string.Format(CultureInfo.InvariantCulture, SelectOptionXPathFormat, "selectBibleSub2");

            foreach (HtmlNode theOldTestamentNode in htmlDocument.DocumentNode.SelectNodes(theOldTestamentXPath))
            {
                string abbreviationKey = theOldTestamentNode.Attributes["value"].Value;
                string name = theOldTestamentNode.InnerText.Trim();

                yield return new Book(TestamentType.TheOldTestament, abbreviationKey, name);
            }

            foreach (HtmlNode theNewTestamentNode in htmlDocument.DocumentNode.SelectNodes(theNewTestamentXPath))
            {
                string abbreviationKey = theNewTestamentNode.Attributes["value"].Value;
                string name = theNewTestamentNode.InnerText.Trim();

                yield return new Book(TestamentType.TheNewTestament, abbreviationKey, name);
            }
        }

        /// <inheritdoc cref="BibleCrawlerBase.GetChaptersAsync(Book)" />
        public override async IAsyncEnumerable<Chapter> GetChaptersAsync(Book book)
        {
            Uri chapterUri = GetChapterUri(book);
            HtmlDocument htmlDocument = await LoadAsync(chapterUri).ConfigureAwait(false);

            string chapterXPath = string.Format(CultureInfo.InvariantCulture, SelectOptionXPathFormat, "selectBibleSub3");
            foreach (HtmlNode chapterNode in htmlDocument.DocumentNode.SelectNodes(chapterXPath))
            {
                string valueString = chapterNode.InnerText.Trim();
                int value = Convert.ToInt32(valueString, CultureInfo.InvariantCulture);

                yield return new Chapter(book, value);
            }
        }

        /// <inheritdoc cref="BibleCrawlerBase.GetVersesAsync(Chapter)" />
        public override async IAsyncEnumerable<Verse> GetVersesAsync(Chapter chapter)
        {
            Uri verseUri = GetVerseUri(chapter);
            HtmlDocument htmlDocument = await LoadAsync(verseUri).ConfigureAwait(false);

            string verseXPath = string.Format(CultureInfo.InvariantCulture, SpanXPathFormat, "txt");
            foreach (HtmlNode verseNode in htmlDocument.DocumentNode.SelectNodes(verseXPath))
            {
                string verseNumberString = verseNode.SelectSingleNode(_verseNumberXPath).InnerText.Trim();
                IEnumerable<string> innerTexts = verseNode.ChildNodes.Where(node => !node.HasClass(VerseNumberClass)).Select(node => node.InnerText);

                int verseNumber = Convert.ToInt32(verseNumberString, CultureInfo.InvariantCulture);
                string text = string.Concat(innerTexts).Trim();

                yield return new Verse(chapter, verseNumber, text);
            }
        }

        /// <inheritdoc cref="BibleCrawlerBase.GetChapterUri(Book)" />
        protected override Uri GetChapterUri(Book book)
        {
            return BaseUri.AddParameter("ver", CurrentVersion).AddParameter("vol", book.AbbreviationKey);
        }

        /// <inheritdoc cref="BibleCrawlerBase.GetVersesAsync(Chapter)" />
        protected override Uri GetVerseUri(Chapter chapter)
        {
            return GetChapterUri(chapter.Book).AddParameter("chap", chapter.Value);
        }
    }
}
