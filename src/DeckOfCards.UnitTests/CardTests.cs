using System;
using NUnit.Framework;

namespace DeckOfCards.UnitTests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void Should_create_new_card()
        {
            var card = new Card(Suit.Clubs, Rank.Two);

            Assert.IsNotNull(card);
            Assert.AreEqual(Suit.Clubs, card.Suit, "Card has incorrect suit.");
            Assert.AreEqual(Rank.Two, card.Rank, "Card has incorrect rank.");
        }

        [Test]
        public void Should_convert_to_human_readable_string()
        {
            var card = new Card(Suit.Clubs, Rank.Two);

            Assert.IsNotNull(card);
            Assert.AreEqual("Two of Clubs", card.ToString(), "Card did not convert to correct string.");
        }

        [Test]
        public void Joker_should_convert_to_human_readable_string()
        {
            var card = new Card(Suit.Joker, Rank.Ace);

            Assert.IsNotNull(card);
            Assert.AreEqual("Joker", card.ToString());
        }

        [Test]
        public void Same_cards_should_be_equal()
        {
            var firstCard = new Card(Suit.Clubs, Rank.Two);
            var secondCard = new Card(Suit.Clubs, Rank.Two);

            Assert.IsTrue(firstCard == secondCard, "Cards should be equal.");
        }

        [Test]
        public void Different_cards_should_not_be_equal()
        {
            var firstCard = new Card(Suit.Clubs, Rank.Two);
            var secondCard = new Card(Suit.Clubs, Rank.Three);

            Assert.IsTrue(firstCard != secondCard, "Cards should not be equal.");
        }
    }
}
