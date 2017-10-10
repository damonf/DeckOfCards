
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public class Deck
    {
        private readonly List<Card> _cards;

        public int CardsRemaining => _cards.Count;

        public static Deck CreateStandardDeck(bool includeJokers = false)
        {
            return new Deck(new StandardCards(includeJokers));
        }

        public Deck(ICreateCards cards)
        {
            _cards = cards?.Create().ToList() ?? throw new ArgumentNullException(nameof(cards));
        }

        public Card DealCard()
        {
            if (_cards.Count < 1)
            {
                throw new InvalidOperationException("Cannot deal any more cards, the deck is empty!");
            }

            var card = _cards[_cards.Count - 1];
            _cards.RemoveAt(_cards.Count - 1);

            return card;
        }
    }
}
