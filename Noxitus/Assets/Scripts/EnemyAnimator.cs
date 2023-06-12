using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    private const string IS_ENEMY_RUNNING = "IsEnemyRunning";
    private const string IS_ENEMY_ATTACK = "IsEnemyAttack";
    private const string IS_ENEMY_Death = "IsEnemyDeath";
    private const string IS_ENEMY_STUNNED = "IsEnemyStunned";
    [SerializeField] private Enemy enemy;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(IS_ENEMY_RUNNING,enemy.IsEnemyRunning());
        _animator.SetBool(IS_ENEMY_ATTACK,enemy.IsEnemyAttack());
    }

    private void Update()
    {
        _animator.SetBool(IS_ENEMY_RUNNING,enemy.IsEnemyRunning());
        _animator.SetBool(IS_ENEMY_ATTACK,enemy.IsEnemyAttack());
        if (enemy.IsEnemyGetHit())
        {
            _animator.SetTrigger("TriggGetHit");
        }
        else
        {
            _animator.ResetTrigger("TriggGetHit");
        }
        _animator.SetBool(IS_ENEMY_Death,enemy.IsEnemyDeath());
        _animator.SetBool(IS_ENEMY_STUNNED,enemy.IsEnemyStunned());
        
    }
}
