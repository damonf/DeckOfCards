using System.Collections.Generic;

namespace DeckOfCards
{
    public interface ICreateCards
    {
        IList<Card> Create();
    }
}
