using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;

    [SerializeField] private Player _target;

    public Player Target => _target;

    public event Action Dying;

    public void TakeDamageBoss(int damage, EnemyBoss enemyBoss)
    {
        _health -= damage;

        if ( _health < 0 )
        {
            enemyBoss.gameObject.SetActive(false);
        }
    }
}
