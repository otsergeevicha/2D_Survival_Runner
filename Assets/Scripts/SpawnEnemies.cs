using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnEnemies : PoolEnemies
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private readonly Random Random = new Random();
    private float _elapsedTime = 0f;

    private void Start()
    {
        for ( int i = 0; i < _enemies.Length; i++ )
        {
            Initialize(_enemies[i]);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if ( _elapsedTime > _secondsBetweenSpawn )
        {
            if ( TryGetObject(out Enemy enemy) )
            {
                int spawnPointNumber = Random.Next(0, _spawnPoints.Length);
                _elapsedTime = 0;
            
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
