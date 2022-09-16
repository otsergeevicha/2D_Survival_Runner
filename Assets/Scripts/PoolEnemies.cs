using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private readonly List<Enemy> Pool = new List<Enemy>();

    protected void Initialize(Enemy prefab)
    {
        for ( int i = 0; i < _capacity; i++ )
        {
            Enemy enemy = Instantiate(prefab, _container.transform);
            enemy.gameObject.SetActive(false);
        
            Pool.Add(enemy);
        }
    }

    protected bool TryGetObject(out Enemy enemy)
    {
        enemy = Pool.FirstOrDefault(enemy => enemy.gameObject.activeSelf == false);
        return enemy != null;
    }
}
