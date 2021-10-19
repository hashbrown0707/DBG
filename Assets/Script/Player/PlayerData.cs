using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public int maxHealth;

    public DeckData deckData;
}
