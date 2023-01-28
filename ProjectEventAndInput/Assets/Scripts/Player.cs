using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    [SerializeField] private int startingHealth=100;
    [SerializeField] private GameEvent _gameEvent;

    private void Awake()
    {
        health = startingHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy=other.GetComponent<Enemy>();
        health = health - enemy._statsSo.damage;
        _gameEvent.Raise();
    }
}
