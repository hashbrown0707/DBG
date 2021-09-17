using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CardSystem
{
    public class Hand : MonoBehaviour
    {
        public int maxCardAmount;
        private int currentCardAmount;

        public Transform handCenterPoint;
        private HandLayout handLayout;
        private Piles piles;
        private List<ICard> handList = new List<ICard>();

        #region Unity Call Back Function
        private void Awake()
        {
            handLayout = new HandLayout(handCenterPoint);
            piles = new Piles();

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
            for (int i = 0; i < maxCardAmount; i++)
                AddCard(piles.DrawCard());
        }

        public void AddCard(ICard card)
        {
            if (currentCardAmount >= maxCardAmount)
            {
                Debug.Log("Hand is full.");
                return;
            }

            handList.Add(card);
            UpdateLayout();
        }

        public void RemoveAllCard()
        {
            foreach (var card in handList)
                ObjectPool.Instance.ReturnObjectToPool(card.gameObject);

            handList.Clear();
            UpdateLayout();
        }

        public void RemoveCard(ICard card)
        {
            if (handList.Contains(card))
            {
                ObjectPool.Instance.ReturnObjectToPool(card.gameObject);
                handList.Remove(card);
                UpdateLayout();
            }
        }
        #endregion
    }
}
