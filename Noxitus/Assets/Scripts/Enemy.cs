using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    public float damage;
    private float currentlyHealth;

    [SerializeField] private Player player;
    
    private bool isEnemyRunning, isEnemyAttack, isGetHit, isDeath,isAttack, isStunning;
    Transform playerPos;
    
    [SerializeField] float enemySpeed = 4f;
    float dis, disHome, disDetect, oldSpeed;
    
    Vector3 startPos;
    
    void Start()
    {
        oldSpeed = enemySpeed;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = transform.position;
        currentlyHealth = maxHealth;
        damage = 5;
        
    }
    
    void Update()
    {
        
        if (!isStunning && !player.GetHero().IsDeath() && !isDeath)
        {
            var position = transform.position;
            dis = Vector3.Distance(position, playerPos.position);
            disHome = Vector3.Distance(position, startPos);
        
            disDetect = player.GetHero().GetDetectability();

            if (dis > 0.7f && dis <= disDetect)
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
                if (!isAttack)
                {
                    isAttack = true;
                    StartCoroutine(ResetAttack());
                    Attack();
                }
            }
            
            if (currentlyHealth <= 0)
            {
                DeathEnemy();
            }
        }
    }
    
    private void TakeDamage(float playerDamage)
    {
        currentlyHealth -= playerDamage;
        if (player.GetHero().IsStunning() && player.GetHero().IsAttack())
        {
            isStunning = true;
            enemySpeed = 0.0f;
            StartCoroutine(ResetStun());
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
        isAttack = true;
        enemySpeed = 0.0f;
        isDeath = true;
        
    }
    
    void Chase()
    {
        if (!isStunning)
        {
            transform.LookAt(playerPos);
            transform.Translate(0, 0, enemySpeed * Time.deltaTime);
        }
    }

    void GoHome()
    {
        Transform transform1;
        (transform1 = transform).LookAt(startPos);
        transform.position = Vector3.Lerp(transform1.position, startPos, (enemySpeed * Time.deltaTime)/2);
    }
    
    void Attack()
    {
        player.GetHero().TakeDamage(damage);
        TakeDamage(player.GetHero().ReflectingDamage(damage));
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
    
    public bool IsEnemyStunned()
    {
        return isStunning;
    }

    IEnumerator ResetGetHit()
    {
        
        yield return new WaitForSeconds(1.0f);
        isGetHit = false;
    }
    
    IEnumerator ResetStun()
    {
        yield return new WaitForSeconds(3.0f);
        enemySpeed = oldSpeed;
        isStunning = false;
    }
    
    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.0f);
        isAttack = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && !isDeath && player.GetHero().IsAttack())
        {
            StartCoroutine(ResetGetHit());
            isGetHit = true;
            TakeDamage(player.GetHero().TotalDamage());
        }
    }
}
