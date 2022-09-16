using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] private SpriteRenderer _spritePlayer;
    private float _speed = 2f;

    public event Action Running;
    public event Action Stopped;

    private const float MaxUpBoundaries = -3f;
    private const float MinDownBoundaries = -5f;
    private const float MaxRightBoundaries = 7.1f;
    private const float MinLeftBoundaries = -7.2f;

    private Transform _transform;
    private float _horizontal;
    private float _vertical;
    private float _currentPosition;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _spritePlayer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if ( _horizontal != 0 || _vertical != 0 )
        {
            Running?.Invoke();
            
            if ( _horizontal != 0 )
            {
                if ( _horizontal < 0 )
                {
                    _spritePlayer.flipX = true;
                }
                else if ( _horizontal > 0 )
                {
                    _spritePlayer.flipX = false;
                }

                _currentPosition = transform.position.x + _horizontal;
                _currentPosition = CheckingBoundaries(_currentPosition, MinLeftBoundaries, MaxRightBoundaries);
                transform.DOMoveX(_currentPosition, .5f);
            }

            if ( _vertical != 0 )
            {
                _currentPosition = transform.position.y + _vertical;
                _currentPosition = CheckingBoundaries(_currentPosition, MinDownBoundaries, MaxUpBoundaries);
                transform.DOMoveY(_currentPosition, .5f);
            }
        }
        else
        {
            Stopped?.Invoke();
        }
    }

    private float CheckingBoundaries(float currentPosition, float minBoundaries, float maxBoundaries)
    {
        currentPosition = Mathf.Clamp(currentPosition, minBoundaries, maxBoundaries);
        return currentPosition;
    }
}