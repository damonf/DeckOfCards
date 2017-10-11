using FluentAssertions;
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

            card.Should().NotBeNull();
            card.Suit.Should().Be(Suit.Clubs, "because the card is a Club");
            card.Rank.Should().Be(Rank.Two, "because the card is a Two");
        }

        [Test]
        public void Should_convert_to_human_readable_string()
        {
            var card = new Card(Suit.Clubs, Rank.Two);

            card.Should()
                .Match(c => c.ToString() == "Two of Clubs", "because the card is a Two of Clubs");
        }

        [Test]
        public void Joker_should_convert_to_human_readable_string()
        {
            var card = new Card(Suit.Joker, Rank.Ace);

            card.Should().Match(c => c.ToString() == "Joker", "because the card is a Joker");
        }

        [Test]
        public void Same_cards_should_be_equal()
        {
            var firstCard = new Card(Suit.Clubs, Rank.Two);
            var secondCard = new Card(Suit.Clubs, Rank.Two);

            firstCard.Should().Be(secondCard, "because they have the same suit and rank");
        }

        [Test]
        public void Different_cards_should_not_be_equal()
        {
            var firstCard = new Card(Suit.Clubs, Rank.Two);
            var secondCard = new Card(Suit.Clubs, Rank.Three);

            firstCard.Should().NotBe(secondCard, "because they do not have the same suit and rank");
        }
    }
}
