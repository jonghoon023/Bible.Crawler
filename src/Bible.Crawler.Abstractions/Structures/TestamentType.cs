using System.ComponentModel;

namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경의 구약과 신약에 대한 종류입니다.
/// </summary>
public enum TestamentType
{
    /// <summary>
    /// <c> 구약 </c> 입니다.
    /// </summary>
    [Description("구약")]
    TheOldTestament,

    /// <summary>
    /// <c> 신약 </c> 입니다.
    /// </summary>
    [Description("신약")]
    TheNewTestament,
}
