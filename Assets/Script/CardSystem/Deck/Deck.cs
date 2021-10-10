using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CardSystem
{
    public class Deck
    {
        private BinaryFormatter bf;
        private Stream s;

        public List<CardData> deckList { get; private set; } = new List<CardData>();

        public Deck()
        {
            bf = new BinaryFormatter();
        }

        /// <summary>
        /// 用SO初始化Deck, 在賦予遊戲內定義牌組(初始牌組)時使用
        /// </summary>
        /// <param name="handPanel">Parent transform</param>
        /// <param name="deckData">scriptable object class</param>
        public void InitDeck(DeckData deckData)
        {
            foreach (var cardData in deckData.cardDatas)
            {
                deckList.Add(cardData);

                //ICard card = cardSpawner.GetSpawndCard(handPanel, cardData);
                //deckList.Add(card);
            }
        }

        public void SaveDeck()
        {
            s = File.Open(Application.dataPath + "DeckBinaryFile.dat", FileMode.Create);
            bf.Serialize(s, deckList);
            s.Close();
        }

        public void LoadDeck()
        {
            s = File.Open(Application.dataPath + "DeckBinaryFile.dat", FileMode.Open);
            deckList = bf.Deserialize(s) as List<CardData>;
            s.Close();

            if (deckList == null)
                Debug.LogError("Deck Binary File Loaded Failed.");
        }
    }
}
