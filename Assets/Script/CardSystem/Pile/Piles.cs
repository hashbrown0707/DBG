using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CardSystem
{
    public enum Pile
    {
        drawPile,
        discardPile,
        exhaustPile
    }

    public class Piles
    {
        public static List<CardData> drawPileList { get; private set; } = new List<CardData>();
        public static List<CardData> discardPileList { get; private set; } = new List<CardData>();
        public static List<CardData> exhaustPileList  { get; private set; } = new List<CardData>();

        public void InitAllPiles(Deck deck)
        {
            drawPileList.Clear();
            discardPileList.Clear();
            exhaustPileList.Clear();

            foreach (var card in deck.deckList)
                drawPileList.Add(card);
        }

        public void AddCardTo(Pile pile, ICard card)
        {
            switch (pile)
            {
                case Pile.drawPile:
                    drawPileList.Add((card as Card).cardData);
                    break;
                case Pile.discardPile:
                    discardPileList.Add((card as Card).cardData);
                    break;
                case Pile.exhaustPile:
                    exhaustPileList.Add((card as Card).cardData);
                    break;
            }
        }

        public CardData GetTopOfDrawPile()
        {
            if (drawPileList.Count <= 0)
                ReloadDrawPile();

            return drawPileList.PopFront();
        }

        /// <summary>
        /// 把棄牌堆所有牌重新洗牌到抽排堆
        /// </summary>
        private void ReloadDrawPile()
        {
            foreach (var card in discardPileList)
                drawPileList.Add(card);

            discardPileList.Clear();
            drawPileList.Shuffle();
        }

    }
}
