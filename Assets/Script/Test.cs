using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;

public class Test : MonoBehaviour
{
    public Player player;
    public CardSystem.Hand hand;
    public CardSystem.CardData cardData1;
    public CardSystem.CardData cardData2;

    public int damage;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool b = (Random.Range(1, 3) == 1) ? false : true;
            CardData cardData = b ? cardData1 : cardData2;
            ICard card = CardSpawner.Instance.GetSpawndCard(cardData);
            hand.AddCard(card);
            //CardSystem.CardSpawner.Instance.SpawnCard(cardData);
            //player.SetBlock(damage);
            //player.TakeDamage(damage);
        }
    }
}
