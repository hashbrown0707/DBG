using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextView : MonoBehaviour
{
    public Character character;
    public Text healthDisplay;

    private void Start()
    {
        character.OnCharacterHealthChanged += UpdateView;
        UpdateView();
    }

    private void OnDestroy()
    {
        character.OnCharacterHealthChanged -= UpdateView;
    }

    private void UpdateView()
    {
        healthDisplay.text = $"Health:{character.health}/{character.maxHealth}" ;
    }
}
