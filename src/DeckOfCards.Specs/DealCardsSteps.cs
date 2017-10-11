using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DeckOfCards.Specs
{
    [Binding]
    public class DealCardsSteps
    {
        private Deck _deck;
        private readonly List<Card> _cardsDealt = new List<Card>();
        private Exception _error;

        [Given(@"I have a new deck of cards")]
        public void GivenIHaveANewDeckOfCards()
        {
            _deck = Deck.CreateStandardDeck();
        }
        
        [Given(@"I have a new standard deck of cards with jokers")]
        public void GivenIHaveANewStandardDeckOfCardsWithJokers()
        {
            _deck = Deck.CreateStandardDeck(includeJokers: true);
        }

        [When(@"I deal no cards")]
        public void WhenIDealNoCards()
        {
            // do nothing
        }
        
        [Then(@"there should be (.*) cards in the deck")]
        public void ThenThereShouldBeCardsInTheDeck(int cardsRemainingInDeck)
        {
            _deck.CardsRemaining.Should()
                .Be(cardsRemainingInDeck,
                    $"because there should be {cardsRemainingInDeck} cards remaining in the deck");
        }

        [When(@"I deal a card")]
        public void WhenIDealACard()
        {
            _cardsDealt.Add(_deck.DealCard());
        }
        
        [Then(@"a card should be produced")]
        public void ThenACardShouldBeProduced()
        {
            _cardsDealt.Count.Should().Be(1, "because 1 card was dealt from the deck");
            _cardsDealt[0].Should().NotBeNull("because a null card cannot be dealt from the deck");
        }

        [When(@"I deal all the cards")]
        public void WhenIDealAllTheCards()
        {
            while (_deck.CardsRemaining > 0)
            {
                var card = _deck.DealCard();
                _cardsDealt.Add(card);
            }
        }
        
        [Then(@"there should be (.*) cards")]
        public void ThenThereShouldBeCards(int expectedNumberOfCards)
        {
            _cardsDealt.Count.Should()
                .Be(expectedNumberOfCards,
                    $"because {expectedNumberOfCards} should have been dealt");
        }
        
        [Then(@"there should be the following cards")]
        public void ThenThereShouldBeTheFollowingCards(IEnumerable<Card> expectedCards)
        {
            foreach (var expectedCard in expectedCards)
            {
                var exists =_cardsDealt.Exists(cardDealt => cardDealt == expectedCard);

                exists.Should().BeTrue($"because {expectedCard} should have been dealt");
            }
        }
        
        [Then(@"there should be (.*) jokers")]
        public void ThenThereShouldBeJokers(int numberOfJokersExpected)
        {
            var jokersDealt = _cardsDealt.Count(c => c.Suit == Suit.Joker);

            jokersDealt.Should()
                .Be(numberOfJokersExpected,
                    $"because {numberOfJokersExpected} jokers should have been dealt");
        }

        [Given(@"I have an empty deck")]
        public void GivenIHaveAnEmptyDeck()
        {
            _deck = Deck.CreateStandardDeck();
            while (_deck.CardsRemaining > 0)
            {
                _deck.DealCard();
            }
        }
        
        [When(@"I try to deal a card")]
        public void WhenITryToDealACard()
        {
            try
            {
                _deck.DealCard();
            }
            catch (Exception e)
            {
                _error = e;
            }
        }
        
        [Then(@"I am presented with an error")]
        public void ThenIAmPresentedWithAnError()
        {
            _error.Should().NotBeNull("because there should have been an error");
            _error.Message.Should().Contain("deck is empty", "because the deck was empty");
        }
    }
}
