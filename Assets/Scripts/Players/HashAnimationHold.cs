using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimationHold : MonoBehaviour
{
    private int _isRun = Animator.StringToHash("IsRun");
    private int _isHit = Animator.StringToHash("IsHit");
    private int _isAttack = Animator.StringToHash("IsAttack");
    private int _isDied = Animator.StringToHash("IsDied");

    public int IsRun => _isRun;
    public int IsHit => _isHit;
    public int IsAttack => _isAttack;
    public int IsDied => _isDied;
}
