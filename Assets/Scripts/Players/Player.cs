using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action ReceivedDamage;
    
    private float _health = 100;
    private float _maxHealth = 100;
    private int _money = 0;

    public int Money => _money;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ReceivedDamage?.Invoke();
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if ( _health <= 0 )
        {
            enabled = false;
        }
    }

    private void OnEnemyDied(int reward)
    {
        _money += reward;
    }
}
