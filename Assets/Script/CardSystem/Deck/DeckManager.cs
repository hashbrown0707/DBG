using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CardSystem
{
    public class DeckManager : Singleton<DeckManager>
    {
        public Deck deckData;

        private List<CardData> deckList = new List<CardData>();

        public void InitDeck()
        {
            foreach (var cardData in deckData.cardDatas)
                deckList.Add(cardData);  //CardSpawner.Instance.SpawnCard(cardData)

            deckList.Shuffle();
        }

        public CardData DrawCardOnTop()
        {
            if (deckList.Count <= 0)
                InitDeck();

            return deckList.PopFront();
        }
    }
}
