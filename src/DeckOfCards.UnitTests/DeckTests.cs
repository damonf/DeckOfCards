using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace DeckOfCards.UnitTests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Should_be_able_to_deal_a_card()
        {
            var deck = Deck.CreateStandardDeck();

            var card = deck.DealCard();

            Assert.IsNotNull(card, "DealCard did not produce a card");
        }

        [Test]
        public void Should_remove_the_dealt_card_from_the_deck()
        {
            var deck = Deck.CreateStandardDeck();
            var count = deck.CardsRemaining;

            deck.DealCard();

            Assert.AreEqual(count - 1, deck.CardsRemaining, "Cards remaining did not decrease");
        }

        [Test]
        public void Should_be_able_to_deal_all_cards()
        {
            var deck = Deck.CreateStandardDeck();
            var totalCards = deck.CardsRemaining;
            var cardsDealt = new List<Card>();

            while (deck.CardsRemaining > 0)
            {
                cardsDealt.Add(deck.DealCard());
            }

            Assert.AreEqual(totalCards, cardsDealt.Count, "Cards dealt does not match the number of cards in the deck");
            var nullIndex = cardsDealt.IndexOf(null);
            Assert.IsTrue(nullIndex < 0, $"Card {nullIndex} dealt was null");
        }

        [Test]
        public void Should_be_dealt_2_jokers_from_a_standard_deck_with_jokers()
        {
            var deck = Deck.CreateStandardDeck(includeJokers: true);
            var cardsDealt = new List<Card>();

            while (deck.CardsRemaining > 0)
            {
                cardsDealt.Add(deck.DealCard());
            }

            var numberOfJokersDealt = cardsDealt.Count(c => c.Suit == Suit.Joker);
            Assert.AreEqual(2, numberOfJokersDealt, "Number of jokers was different from expected");
        }
    }
}
