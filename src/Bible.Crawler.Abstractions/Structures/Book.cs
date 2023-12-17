namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경의 책 정보를 가지고 있는 구조체입니다.
/// </summary>
/// <param name="testament"> 구약인지 신약인지에 대한 <see cref="TestamentType" /> 형식 값입니다. </param>
/// <param name="abbreviationKey"> 성경 책을 찾을 수 있는 약어 Key 입니다. </param>
/// <param name="name"> 성경 책명입니다. </param>
public readonly struct Book(TestamentType testament, string abbreviationKey, string name) : IEquatable<Book>
{
    /// <summary>
    /// 구약인지 신약인지에 대해 <see cref="TestamentType" /> 형식의 값으로 가져옵니다.
    /// </summary>
    public TestamentType Testament => testament;

    /// <summary>
    /// 성경 책을 찾을 수 있는 약어 Key 를 가져옵니다.
    /// </summary>
    public string AbbreviationKey => abbreviationKey;

    /// <summary>
    /// 성경 책명을 가져옵니다.
    /// </summary>
    public string Name => name;

    /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
    public bool Equals(Book other)
    {
        return this == other;
    }

    /// <inheritdoc cref="object.Equals(object?)" />
    public override bool Equals(object? obj)
    {
        if (obj is Book otherBook)
        {
            return
                Testament == otherBook.Testament &&
                AbbreviationKey == otherBook.AbbreviationKey &&
                Name == otherBook.Name;
        }

        return false;
    }

    /// <inheritdoc cref="object.GetHashCode" />
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <inheritdoc cref="object.Equals(object?)" />
    public static bool operator ==(Book left, Book right)
    {
        return left.Equals(right);
    }

    /// <inheritdoc cref="object.Equals(object?)" />
    public static bool operator !=(Book left, Book right)
    {
        return !(left == right);
    }
}
