using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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

            card.Should().NotBeNull("because it was dealt from the deck");
        }

        [Test]
        public void Should_remove_the_dealt_card_from_the_deck()
        {
            var deck = Deck.CreateStandardDeck();
            var totalCards = deck.CardsRemaining;

            deck.DealCard();

            deck.CardsRemaining.Should()
                .Be(totalCards - 1, $"because 1 card was dealt from the deck of {totalCards}");
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

            cardsDealt.Count.Should()
                .Be(totalCards, $"because there were {totalCards} in the deck");

            cardsDealt.Count(c => c == null)
                .Should()
                .BeLessThan(1, "because there cannot be any null cards dealt from the deck");
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


            const int expectedJokers = 2;
            cardsDealt.Count(c => c.Suit == Suit.Joker)
                .Should()
                .Be(expectedJokers,
                    $"because there are {expectedJokers} jokers in a standard deck");
        }
    }
}
