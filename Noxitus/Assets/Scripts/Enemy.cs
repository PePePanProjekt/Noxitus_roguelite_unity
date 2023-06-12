using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int damage;
    private int currentlyHealth;

    [SerializeField] private Player player;
    private bool isEnemyRunning, isEnemyAttack, isGetHit, isDeath;
    Transform playerPos;
    [SerializeField] float enemySpeed = 6f;
    float dis, disHome;
    Vector3 startPos;
    private float disDetect;
    private bool block, isStunning;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = transform.position;
        InvokeRepeating(nameof(ClearBlock), 1.0f, 1.0f);
        currentlyHealth = maxHealth;
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        player = Player.Instance;
        var position = transform.position;
        dis = Vector3.Distance(position, playerPos.position);
        disHome = Vector3.Distance(position, startPos);
        
        disDetect = player.GetHero().GetDetectability();
        if (!isStunning)
        {
            if (dis is > 0.7f && dis <= disDetect)
            {
                isEnemyAttack = false;
                isEnemyRunning = true;
                Chase();
            }

            if (dis > disDetect)
            {
                isEnemyAttack = false;
                isEnemyRunning = true;
                GoHome();
            }

            if (disHome < 0.5f)
            {
                isEnemyAttack = false;
                isEnemyRunning = false;
            }

            if (dis < 1f)
            {
                isEnemyRunning = false;
                isEnemyAttack = true;
                if (!block)
                {
                    block = true;
                    Attack();
                }
            }
        }

        if (currentlyHealth <= 0)
        {
            DeathEnemy();
        }
    }
    
    private void TakeDamage(int playerDamage)
    {
        currentlyHealth -= playerDamage;
        if (player.GetHero().IsStunning())
        {
            isStunning = true;
        }

        if (player.GetHero().IsInstantKill())
        {
            DeathEnemy();
        }
        
        if (player.GetHero().HpCollecting() > currentlyHealth)
        {
            DeathEnemy();
        }
    }

    void DeathEnemy()
    {
        isDeath = true;
    }
    
    void Chase()
    {
        transform.LookAt(playerPos);
        transform.Translate(0, 0, enemySpeed * Time.deltaTime);
    }

    void ClearBlock()
    {
        block = false;
    }

    void GoHome()
    {
        Transform transform1;
        (transform1 = transform).LookAt(startPos);
        transform.position = Vector3.Lerp(transform1.position, startPos, (enemySpeed * Time.deltaTime)/2);
    }
    
    void  Attack()
    {
        player.GetHero().TakeDamage(damage);
        TakeDamage(player.GetHero().ReflectingDamage());
    }
    
    public bool IsEnemyGetHit()
    {
        return isGetHit;
    }
    
    public bool IsEnemyDeath()
    {
        return isDeath;
    }

    public bool IsEnemyAttack()
    {
        return isEnemyAttack;
    }
    
    public bool IsEnemyRunning()
    {
        return isEnemyRunning;
    }
    
    public void DisableRoll()
    {
        isGetHit = false;

    }
    
    IEnumerator ResetGetHit()
    {
        
        yield return new WaitForSeconds(1.0f);
        isGetHit = false;
    }
    
    IEnumerator ResetStun()
    {
        yield return new WaitForSeconds(2.0f);
        isStunning = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && !isGetHit)
        {
            StartCoroutine(ResetGetHit());
            isGetHit = true;
            TakeDamage(player.GetHero().TotalDamage());
       
        }
    }
}
