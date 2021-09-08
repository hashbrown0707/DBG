using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    [CreateAssetMenu(menuName = "EventSystem/DeckData")]
    public class Deck : ScriptableObject
    {
        public List<CardData> cardDatas;
    }
}