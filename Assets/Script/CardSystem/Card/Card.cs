using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace CardSystem
{
    public class Card : MonoBehaviour, ICard, IPoolable<CardData>
    {
        public CardData cardData;
        public Player player;
        public Hand hand;

        public Image cardImage;
        public Text cardName;
        public Text cardDescription;

        private Dictionary<IEffect, int> effects;

        private void Start()
        {
            player = FindObjectOfType<Player>();
            hand = FindObjectOfType<Hand>();
        }

        #region ICard
        GameObject ICard.gameObject => this.gameObject;

        public void OnHover()
        {
            Debug.Log("on hover");
        }

        public void OnHoverExit()
        {
            Debug.Log("not hover");
        }

        public void OnUse(Character target)
        {

            //TODO :  get card target in CardView

            foreach(var e in effects.Keys)
            {
                e.Execute(player, target, effects[e]);
            }

            hand.DiscardCard(this);
        }
        #endregion

        #region IPoolable
        public void OnSpawned(CardData cardData)
        {
            this.cardData = cardData;
            cardName.text = cardData.cardName;
            cardDescription.text = cardData.description;
            cardImage.sprite = cardData.image;

            if (effects == null)
                effects = new Dictionary<IEffect, int>();
            else
                effects.Clear();

            //Add Effect class from cardData.effectTypes
            foreach (var effectType in cardData.effectTypes.Keys)
            {
                EffectDictionary.EffectDict.TryGetValue(effectType, out var effect);

                if (effect != null)
                    effects.Add(effect, cardData.effectTypes[effectType]);
            }
        }

        public void OnDespawned()
        {
            effects.Clear();
            this.cardData = ScriptableObject.CreateInstance(typeof(CardData)) as CardData;
        }
        #endregion

    }
}
