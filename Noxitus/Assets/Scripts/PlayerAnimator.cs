using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private const string IS_RUNNING = "IsRunning";

    private const string IS_PICK_UP = "IsPickUp";
    private const string IS_DEATH = "IsDeath";
    private const string IS_GET_HIT = "IsGetHit";
    private const string IS_STRONG_ATTACK = "IsStrongAttack";

    [SerializeField] private Player player;

    private Animator _animator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _animator = GetComponent<Animator>();
        // _animator.SetBool(IS_RUNNING,player.GetHero().IsRunning());
        //
        // _animator.SetBool(IS_PICK_UP,player.GetHero().IsPickUp());
        // _animator.SetBool(IS_DEATH,player.GetHero().IsDeath());
        // _animator.SetBool(IS_GET_HIT,player.GetHero().IsGetHit());
        // _animator.SetBool(IS_STRONG_ATTACK,player.GetHero().IsStrongAttack());
    }

    private void Update()
    {
        _animator.SetBool(IS_RUNNING,player.GetHero().IsRunning());
        if (player.GetHero().IsRoll())
        {
            _animator.SetTrigger("TriggRoll");
        }
        else
        {
            _animator.ResetTrigger("TriggRoll");
        }
        
        if (player.GetHero().IsAttack())
        {
            _animator.SetTrigger("TriggAttack");
        }
        else
        {
            _animator.ResetTrigger("TriggAttack");
        }
        
       
        _animator.SetBool(IS_PICK_UP,player.GetHero().IsPickUp());
        _animator.SetBool(IS_DEATH,player.GetHero().IsDeath());
        _animator.SetBool(IS_GET_HIT,player.GetHero().IsGetHit());
        _animator.SetBool(IS_STRONG_ATTACK,player.GetHero().IsStrongAttack());

    }
    
    
}
