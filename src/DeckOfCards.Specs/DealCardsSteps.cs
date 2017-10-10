using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
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
            // TODO: use the should library
            Assert.AreEqual(cardsRemainingInDeck, _deck.CardsRemaining); 
        }

        [When(@"I deal a card")]
        public void WhenIDealACard()
        {
            _cardsDealt.Add(_deck.DealCard());
        }
        
        [Then(@"a card should be produced")]
        public void ThenACardShouldBeProduced()
        {
            Assert.AreEqual(1, _cardsDealt.Count);
            Assert.IsNotNull(_cardsDealt[0]);
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
            Assert.AreEqual(expectedNumberOfCards, _cardsDealt.Count, "Fewer cards dealt than expected");
        }
        
        [Then(@"there should be the following cards")]
        public void ThenThereShouldBeTheFollowingCards(IEnumerable<Card> expectedCards)
        {
            foreach (var expectedCard in expectedCards)
            {
                var exists =_cardsDealt.Exists(cardDealt => cardDealt == expectedCard);

                Assert.IsTrue(exists, $"card not found '{expectedCard}'");
            }
        }
        
        [Then(@"there should be (.*) jokers")]
        public void ThenThereShouldBeJokers(int numberOfJokers)
        {
            var jokersDealt = _cardsDealt.Count(c => c.Suit == Suit.Joker);
            Assert.AreEqual(numberOfJokers, jokersDealt, "Incorret number of Jokers were dealt");
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
            Assert.IsNotNull(_error);
            Assert.IsTrue(_error.Message.Contains("deck is empty"));
        }
    }
}
