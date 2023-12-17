using System.Web;
using System.Collections.Specialized;

namespace Bible.Crawler.Extensions;

/// <summary>
/// <see cref="Uri" /> Class 에 대한 확장 함수가 있는 정적 Class 입니다.
/// </summary>
internal static class UriExtensions
{
    /// <summary>
    /// 현재 <see cref="Uri" /> 에 매개변수를 추가하여 가져옵니다.
    /// </summary>
    /// <param name="uri"> 현재 <see cref="Uri" /> 객체입니다. </param>
    /// <param name="key"> 추가할 매개변수의 Key 입니다. </param>
    /// <param name="value"> 추가할 매개변수의 값입니다. </param>
    /// <returns></returns>
    public static Uri AddParameter<TValue>(this Uri uri, string key, TValue value)
    {
        NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uri.Query);
        nameValueCollection.Add(key, value?.ToString());

        UriBuilder uriBuilder = new(uri)
        {
            Query = nameValueCollection.ToString()
        };

        return uriBuilder.Uri;
    }
}
