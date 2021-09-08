using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockTextView : MonoBehaviour
{
    public Character character;
    public Text blockDisplay;

    private void Start()
    {
        character.OnCharacterBlockChanged += UpdateView;
        UpdateView();
    }

    private void OnDestroy()
    {
        character.OnCharacterBlockChanged -= UpdateView;
    }

    private void UpdateView()
    {
        blockDisplay.text = $"Block:{character.block}";
    }
}
