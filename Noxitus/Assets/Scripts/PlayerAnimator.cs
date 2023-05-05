using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private const string IS_RUNNING = "IsRunning";
    
    [SerializeField] private Player player;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(IS_RUNNING,player.IsRunning());
    }

    private void Update()
    {
        _animator.SetBool(IS_RUNNING,player.IsRunning());
    }
}
