using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerEnemies : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.TryGetComponent<Enemy>(out Enemy enemy) )
        {
            enemy.gameObject.SetActive(false);
        }
    }
}