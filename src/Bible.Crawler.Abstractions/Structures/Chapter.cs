namespace Bible.Crawler.Abstractions.Structures;

/// <summary>
/// 성경의 장 정보를 가지고 있는 Data Model 입니다.
/// </summary>
/// <param name="book"> 성경의 책 정보를 가지고 있는 <see cref="Structures.Book" /> 구조체입니다. </param>
/// <param name="value"> 현재 성경의 장 정보입니다. </param>
public readonly struct Chapter(Book book, int value) : IEquatable<Chapter>
{
    /// <summary>
    /// 성경의 책 정보를 가지고 있는 <see cref="Structures.Book" /> 구조체를 가져옵니다.
    /// </summary>
    public Book Book => book;

    /// <summary>
    /// 현재 성경의 장 정보를 가져옵니다.
    /// </summary>
    public int Value => value;

    /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
    public bool Equals(Chapter other)
    {
        return this == other;
    }

    /// <inheritdoc cref="object.Equals(object?)" />
    public override bool Equals(object? obj)
    {
        if (obj is Chapter otherChapter)
        {
            return 
                Book == otherChapter.Book && 
                Value == otherChapter.Value;
        }

        return false;
    }

    /// <inheritdoc cref="object.GetHashCode" />
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <inheritdoc cref="object.Equals(object?)" />
    public static bool operator ==(Chapter left, Chapter right)
    {
        return left.Equals(right);
    }

    /// <inheritdoc cref="object.Equals(object?)" />
    public static bool operator !=(Chapter left, Chapter right)
    {
        return !(left == right);
    }
}
