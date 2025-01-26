using System;

namespace Bible.Crawler.Models
{
    /// <summary>
    /// 성경의 구절 정보를 가지고 있는 Data Model 입니다.
    /// </summary>
    public readonly struct Verse : IEquatable<Verse>
    {
        /// <summary>
        /// <see cref="Verse" /> 를 초기화합니다.
        /// </summary>
        /// <param name="chapter"> 성경의 장 정보를 가지고 있는 <see cref="Models.Chapter" /> 구조체입니다. </param>
        /// <param name="value"> 성경의 절 정보입니다. </param>
        /// <param name="text"> 성경 구절입니다. </param>
        public Verse(Chapter chapter, int value, string text)
        {
            Chapter = chapter;
            Value = value;
            Text = text;
        }

        /// <summary>
        /// 성경 장 정보를 가지고 있는 <see cref="Models.Chapter" /> 구조체를 가져옵니다.
        /// </summary>
        public Chapter Chapter { get; }

        /// <summary>
        /// 성경 절 정보를 가져옵니다.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// 성경 구절을 가져옵니다.
        /// </summary>
        public string Text { get; }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(Verse other)
        {
            return this == other;
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object? obj)
        {
            if (obj is Verse otherVerse)
            {
                return
                    Chapter == otherVerse.Chapter &&
                    Value == otherVerse.Value &&
                    Text == otherVerse.Text;
            }

            return false;
        }

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public static bool operator ==(Verse left, Verse right)
        {
            return left.Equals(right);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public static bool operator !=(Verse left, Verse right)
        {
            return !(left == right);
        }
    }
}
