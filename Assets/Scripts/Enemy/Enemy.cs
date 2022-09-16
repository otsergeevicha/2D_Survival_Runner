using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    private float _maxHealth = 30;

    private void Update()
    {
        transform.Translate(-_speed * Time.deltaTime, 0, 0);
    }

    public void TakeDamageEnemy(int damage, Enemy enemy)
    {
        _health -= damage;

        if ( _health <= 0 )
        {
            enemy.gameObject.SetActive(false);
            enemy._health = _maxHealth;
        }
    }
}
