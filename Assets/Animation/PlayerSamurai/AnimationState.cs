using UnityEngine;

[RequireComponent(typeof(HashAnimationHold))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerBattle))]

public class AnimationState : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _movementPlayer;
    [SerializeField] private PlayerBattle _playerBattle;
    [SerializeField] private HashAnimationHold _hashAnimationHold;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movementPlayer = GetComponent<PlayerMovement>();
        _playerBattle = GetComponent<PlayerBattle>();
        _hashAnimationHold = GetComponent<HashAnimationHold>();
    }

    private void OnEnable()
    {
        _player.ReceivedDamage += OnAnimationHit;
        _movementPlayer.Running += OnAnimationRunning;
        _movementPlayer.Stopped += OffAnimationRunning;
        _playerBattle.Attacking += OnAnimationAttack;
    }

    private void OnDisable()
    {
        _player.ReceivedDamage -= OnAnimationHit;
        _movementPlayer.Running -= OnAnimationRunning;
        _movementPlayer.Stopped -= OffAnimationRunning;
        _playerBattle.Attacking -= OnAnimationAttack;
    }

    private void OnAnimationHit()
    {
        _animator.SetTrigger(_hashAnimationHold.IsHit);
    }
    
    private void OnAnimationAttack()
    {
        _animator.SetTrigger(_hashAnimationHold.IsAttack);
    }
    
    private void OnAnimationRunning()
    {
        _animator.SetBool(_hashAnimationHold.IsRun, true);
    }
    
    private void OffAnimationRunning()
    {
        _animator.SetBool(_hashAnimationHold.IsRun, false);
    }
}
