using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CardSystem
{
    public class Hand : MonoBehaviour
    {
        public int maxCardAmount;

        public Transform handCenterPoint;
        private CardSpawner cardSpawner;
        private HandLayout handLayout;
        private Piles piles;
        private List<ICard> handList = new List<ICard>();

        #region Unity Call Back Function
        private void Awake()
        {
            handLayout = new HandLayout(handCenterPoint);
            piles = new Piles();
            cardSpawner = new CardSpawner();
        }

        #endregion

        #region Layout
        public void UpdateLayout()
        {
            foreach (var card in handList)
            {
                card.gameObject.transform.localPosition = handLayout.CalculateTargetPosition(handList.IndexOf(card), handList.Count); 
                //handLayout.CalculateTargetQuaternion()
            }
        }

        #endregion
        
        #region Logic
        public void DrawUntilMax()
        {
            for (int i = 0; i < maxCardAmount; ++i)
                AddCard(piles.GetTopOfDrawPile());
        }

        public void DrawCards(int amount)
        {
            for (int i = 0; i < amount; ++i)
                AddCard(piles.GetTopOfDrawPile());
        }

        //目前在這邊把卡實體化
        public void AddCard(CardData cardData)
        {
            if (handList.Count >= maxCardAmount)
            {
                Debug.Log("Hand is full.");
                return;
            }

            if(cardData == null)
            {
                Debug.LogWarning("CardData null");
                return;
            }

            handList.Add(cardSpawner.GetSpawndCard(handCenterPoint.parent.transform, cardData));
            UpdateLayout();
        }

        public void DiscardAllCard()
        {
            foreach (var card in handList)
            {
                piles.AddCardTo(Pile.discardPile, card);
                ObjectPool.Instance.ReturnObjectToPool(card.gameObject);
            }

            handList.Clear();
            UpdateLayout();
        }

        public void DiscardCard(ICard card)
        {
            if (handList.Contains(card))
            {
                ObjectPool.Instance.ReturnObjectToPool(card.gameObject);
                piles.AddCardTo(Pile.discardPile, card);
                handList.Remove(card);
                UpdateLayout();
            }
        }
        #endregion
    }
}
