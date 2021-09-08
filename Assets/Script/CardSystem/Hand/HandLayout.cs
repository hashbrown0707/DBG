using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    public class HandLayout
    {
        private float cardXSpace = 180f;
        private float cardYSpace;
        private float cardEular = 0.1f;
        private Transform handCenterPoint;

        public HandLayout(Transform handCenterPoint)
        {
            this.handCenterPoint = handCenterPoint;
        }

        public Vector3 CalculateTargetPosition(int cardIndex, int cardTotal)
        {
            Vector3 xPos;

            if (cardTotal % 2 == 1)
            {
                xPos = Vector3.left * (Mathf.Ceil(cardTotal / 2)) + Vector3.right * cardIndex;
                //yPos = Vector3.down * Mathf.Abs(Mathf.Ceil(cardTotal / 2) - cardIndex);
            }
            else
            {
                xPos = Vector3.left * ((cardTotal / 2) - 0.5f) + Vector3.right * cardIndex;
                //yPos = Vector3.down * Mathf.Abs(cardTotal / 2 - cardIndex - 0.5f);
            }

            return handCenterPoint.localPosition + cardXSpace * (xPos);   // + cardYSpace * (yPos);
        }

        public Quaternion CalculateTargetQuaternion(int cardIndex, int cardTotal)
        {
            if (cardTotal % 2 == 1)
                return Quaternion.LookRotation(Vector3.forward, Vector3.up + cardEular * Vector3.right * (cardIndex - Mathf.Ceil(cardTotal / 2)));
            else
                return Quaternion.LookRotation(Vector3.forward, Vector3.up + cardEular * Vector3.right * (cardIndex - ((cardTotal / 2) - 0.5f))); ;
        }
    }
}
