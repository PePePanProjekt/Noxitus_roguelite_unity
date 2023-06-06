using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Hero hero;

    private void Awake()
    {
        hero = gameObject.AddComponent<Berserker>();
    }

    public Hero GetHero()
    {
        return hero;
    }
    
}
