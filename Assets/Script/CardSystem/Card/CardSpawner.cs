using System;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;
using Utility;

namespace CardSystem
{
    public class CardSpawner : Singleton<CardSpawner>
    {
        public GameObject panel;

        public Card GetSpawndCard(CardData cardData)
        {
            //從pool拿出
            GameObject cardObj = ObjectPool.Instance.GetObjectFromPool("Card", panel.transform, cardData);
            return cardObj.GetComponent<Card>();
        }

        ///// <summary>
        ///// 把選擇卡生出來並可以選擇性給予在用這張選擇卡時的附加function
        ///// </summary>
        ///// <param name="action">可額外附加在這卡上的function</param>
        //public ChooseCard SpawnChooseCard(DialogueChunk dialogueChunk, Action action = null)
        //{
        //    GameObject cardObj = ObjectPool.Instance.GetObjectFromPool("ChooseCard", panel.transform, dialogueChunk, action);
        //    return cardObj.GetComponent<ChooseCard>();
        //}    
    }
}
