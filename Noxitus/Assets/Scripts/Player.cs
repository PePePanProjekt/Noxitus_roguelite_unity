using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Hero hero;
    public static Player Instance;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private void Awake()
    {
        hero = gameObject.AddComponent<Berserker>();
    }

    public Hero GetHero()
    {
        return Instance.hero;
    }
    
}
