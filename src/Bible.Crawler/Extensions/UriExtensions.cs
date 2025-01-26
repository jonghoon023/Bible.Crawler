using System;
using System.Collections.Specialized;
using System.Web;

namespace Bible.Crawler.Extensions
{
    /// <summary>
    /// <see cref="Uri" /> Class 에 대한 확장 함수가 있는 정적 Class 입니다.
    /// </summary>
    internal static class UriExtensions
    {
        /// <summary>
        /// 현재 <see cref="Uri" /> 에 매개변수를 추가합니다.
        /// </summary>
        /// <param name="uri"> 현재 <see cref="Uri" /> 객체입니다. </param>
        /// <param name="key"> 추가할 매개변수의 Key 입니다. </param>
        /// <param name="value"> 추가할 매개변수의 값입니다. </param>
        /// <returns> 매개변수를 추가한 <see cref="Uri" /> 객체를 반환합니다. </returns>
        public static Uri AddParameter<TValue>(this Uri uri, string key, TValue value)
        {
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uri.Query);
            nameValueCollection.Add(key, value?.ToString());

            UriBuilder uriBuilder = new UriBuilder(uri)
            {
                Query = nameValueCollection.ToString()
            };

            return uriBuilder.Uri;
        }
    }
}
