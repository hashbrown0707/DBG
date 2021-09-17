using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    [CreateAssetMenu(menuName = "CardSystem/Deck")]
    public class DeckData : ScriptableObject
    {
        public List<CardData> cardDatas;
    }
}