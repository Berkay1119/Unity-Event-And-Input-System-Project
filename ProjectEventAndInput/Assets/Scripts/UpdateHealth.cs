using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateHealth : MonoBehaviour
{
    private Player _player;
    private TextMeshProUGUI _textMeshProUGUI;
    private void Awake()
    {
        _textMeshProUGUI=GetComponent<TextMeshProUGUI>();
        _player=FindObjectOfType<Player>();
    }

    public void UpdateHealthCount()
    {
        _textMeshProUGUI.text = "Health: " + _player.health;
    }
}
