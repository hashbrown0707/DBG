using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace CardSystem
{
    [CreateAssetMenu(menuName = "Card")]
    public class CardData : SerializedScriptableObject
    {
        public int cardID;
        public int cost;

        public string cardName;
        [TextArea]
        public string description;

        public CardType cardType;
        public Dictionary<EffectType, int> effectTypes = new Dictionary<EffectType, int>();

        public Sprite image;
    }
}
