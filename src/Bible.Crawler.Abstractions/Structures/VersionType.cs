using System.ComponentModel;

namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경 역본 종류입니다.
/// </summary>
[Flags]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S2346:Flags enumerations zero-value members should be named \"None\"", Justification = "None 이 있을 이유가 없습니다.")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1008:열거형에는 0 값이 있어야 합니다.", Justification = "None 이 있을 이유가 없습니다.")]
public enum VersionType
{
    /// <summary>
    /// <c> 개역개정 </c> 입니다.
    /// </summary>
    [Description("개역개정")]
    GAE = 0,

    /// <summary>
    /// <c> 개역한글 </c> 입니다.
    /// </summary>
    [Description("개역한글")]
    HAN = 1,

    /// <summary>
    /// <c> 표준새번역 </c> 입니다.
    /// </summary>
    [Description("표준새번역")]
    SAE = 1 << 1,

    /// <summary>
    /// <c> 새번역 </c> 입니다.
    /// </summary>
    [Description("새번역")]
    SAENEW = 1 << 2,

    /// <summary>
    /// <c> 공동번역 </c> 입니다.
    /// </summary>
    [Description("공동번역")]
    COG = 1 << 3,

    /// <summary>
    /// <c> 공동번역 개정판 </c> 입니다.
    /// </summary>
    [Description("공동번역 개정판")]
    COGNEW = 1 << 4,

    /// <summary>
    /// <c> CEV </c> 입니다.
    /// </summary>
    [Description("CEV")]
    CEV = 1 << 5,

    /// <summary>
    /// <c> NIV </c> 입니다.
    /// </summary>
    [Description("NIV")]
    NIV = 1 << 6,

    /// <summary>
    /// <c> 쉬운성경 </c> 입니다.
    /// </summary>
    [Description("쉬운성경")]
    EASY = 1 << 7,

    /// <summary>
    /// <c> 현대인의 성경 </c> 입니다.
    /// </summary>
    [Description("현대인의 성경")]
    HYUN = 1 << 8
}
