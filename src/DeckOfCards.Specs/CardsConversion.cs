using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DeckOfCards.Specs
{
    [Binding]
    internal class CardsConversion
    {
        private class CardsOfSuit
        {
            public Suit Suit { get; set; }
            public string Values { get; set; }
        }

        [StepArgumentTransformation]
        public IEnumerable<Card> CardsTransformation(Table table)
        {
            var cardsBySuit = table.CreateSet<CardsOfSuit>();

            return cardsBySuit.SelectMany(cardsOfSuit =>
                cardsOfSuit
                    .Values
                    .Split(',')
                    .Select(rank =>
                    {
                        if (Enum.TryParse<Rank>(rank.Trim(), true, out var suitValue))
                        {
                            return new Card(cardsOfSuit.Suit, suitValue);
                        }

                        throw new ArgumentOutOfRangeException($"Cannot convert suit value for '{rank}'");
                    }));
        }
    }
}
