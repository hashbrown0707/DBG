using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CardSystem
{
    public class Piles
    {
        private List<ICard> drawPileList = new List<ICard>();
        private List<ICard> discardPileList = new List<ICard>();
        private List<ICard> exhaustPileList = new List<ICard>();

        public void InitAllPiles(Deck deck)
        {
            drawPileList.Clear();
            drawPileList.Clear();
            exhaustPileList.Clear();

            foreach (ICard card in deck.deckList)
                drawPileList.Add(card);
        }

        public ICard DrawCard()
        {
            if (drawPileList.Count <= 0)
                ReloadDrawPile();

            return drawPileList.PopFront();
        }

        /// <summary>
        /// 把棄牌堆所有牌重新洗牌到抽排堆
        /// </summary>
        public void ReloadDrawPile()
        {
            foreach (var card in discardPileList)
                drawPileList.Add(card);

            discardPileList.Clear();
            drawPileList.Shuffle();
        }

    }
}
