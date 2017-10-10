using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class StandardCards : ICreateCards
    {
        private readonly bool _includeJokers;

        public StandardCards(bool includeJokers)
        {
            _includeJokers = includeJokers;
        }

        public IList<Card> Create()
        {
            var cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                if (suit == Suit.Joker) continue;

                cards.Add(new Card(suit, Rank.Ace));
                cards.Add(new Card(suit, Rank.Two));
                cards.Add(new Card(suit, Rank.Three));
                cards.Add(new Card(suit, Rank.Four));
                cards.Add(new Card(suit, Rank.Five));
                cards.Add(new Card(suit, Rank.Six));
                cards.Add(new Card(suit, Rank.Seven));
                cards.Add(new Card(suit, Rank.Eight));
                cards.Add(new Card(suit, Rank.Nine));
                cards.Add(new Card(suit, Rank.Ten));
                cards.Add(new Card(suit, Rank.Jack));
                cards.Add(new Card(suit, Rank.Queen));
                cards.Add(new Card(suit, Rank.King));
            }

            if (_includeJokers)
            {
                cards.Add(new Card(Suit.Joker, Rank.Ace));
                cards.Add(new Card(Suit.Joker, Rank.Ace));
            }

            return cards;
        }
    }
}
