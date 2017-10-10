using System;

namespace DeckOfCards
{
    public class Card : IEquatable<Card>
    {
        //private readonly int _rankValue;

        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card() : this(Suit.Joker, Rank.Ace)
        {
        }

        public Card(Suit suit, Rank rankValue)
        {
            Suit = suit;
            Rank = rankValue;
            //_rankValue = GetRankValue(rankValue);
        }

        public override string ToString()
        {
            return Suit == Suit.Joker ? $"{Suit}" : $"{Rank} of {Suit}";
        }

        //private static int GetRankValue(Rank value)
        //{
        //    return (int) value;
        //}

        #region equality

        public static bool operator ==(Card a, Card b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Suit == b.Suit && a.Rank == b.Rank;
        }

        public static bool operator !=(Card a, Card b)
        {
            return !(a == b);
        }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Suit.Equals(other.Suit) &&
                   Rank.Equals(other.Rank);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 23 + Suit.GetHashCode();
            hash = hash * 23 + Rank.GetHashCode();
            return hash;
        }

        #endregion
    }
}
