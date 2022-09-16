using System;
using System.Collections;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    private const float WaitSecondCoroutine =.3f;
    private Coroutine _attackCoroutine;
    private EnemyBoss _enemyBoss;
    private Enemy _enemy;
    
    public event Action Attacking;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemy = enemy;

            if ( _attackCoroutine != null )
            {
                StopCoroutine(_attackCoroutine);
            }
            _attackCoroutine = StartCoroutine(AttackEnemy(enemy));
        }
        
        if (collision.TryGetComponent<EnemyBoss>(out EnemyBoss enemyBoss))
        {
            _enemyBoss = enemyBoss;

            if ( _attackCoroutine != null )
            {
                StopCoroutine(_attackCoroutine);
            }
            _attackCoroutine = StartCoroutine(AttackEnemyBoss(enemyBoss));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _enemy = null;
        _enemyBoss = null;
    }
    
    private IEnumerator AttackEnemyBoss(EnemyBoss enemy)
    {
        var waitSecond = new WaitForSeconds(WaitSecondCoroutine);
        
        while ( _enemy != null )
        {
            Attacking?.Invoke();
            enemy.TakeDamageBoss(_damage, enemy);
            yield return waitSecond;
        }
    }

    private IEnumerator AttackEnemy(Enemy enemy)
    {
        var waitSecond = new WaitForSeconds(WaitSecondCoroutine);
        
        while ( _enemy != null )
        {
            Attacking?.Invoke();
            enemy.TakeDamageEnemy(_damage, enemy);
            yield return waitSecond;
        }
    }
}