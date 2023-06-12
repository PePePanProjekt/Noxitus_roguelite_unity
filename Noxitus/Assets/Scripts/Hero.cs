using System;
using System.Collections;
using DefaultNamespace;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public abstract class Hero : MonoBehaviour
{
    //Stats
    [SerializeField] private int maxHealth = 100;
    private int maxEnergy = 100;
    private int maxExperience = 100;
    private int  punchesSeries;
    private float rotateSpeed = 10f, detectability;
    
    private float[] allStats = new float[Enum.GetNames(typeof(StatsEnum)).Length];
    private float[] allBuffStats = new float[Enum.GetNames(typeof(StatsEnum)).Length];
    
    private int currentlyHealth, currentlyEnergy, money, level, currentlyExperience;

    // Animation variables
    private bool isRunning, isRoll, isAttack, isPickUp, isDeath, isGetHit, isStrongAttack;
    private bool isSpecial, iSCombat;

    //UI
    private HealthBarScript healthBar;
    private EnergyBarScript energyBar;
    private ExperienceBarScript experienceBar;
    private MoneyScript moneyDisplay;
    private LevelScript lvlDisplay;
    private SkillTreeScript skillTree;
    
    
    private System.Random random = new System.Random();
    void Awake()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarScript>(); 
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBarScript>();
        experienceBar = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<ExperienceBarScript>();
        moneyDisplay = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScript>();
        lvlDisplay = GameObject.FindGameObjectWithTag("Lvl").GetComponent<LevelScript>();
        skillTree = GameObject.FindGameObjectWithTag("SkillTree").GetComponent<SkillTreeScript>();
        Init();
        InvokeRepeating(nameof(Regenerate), 1.0f, 1.0f);
    }
    
    private void Update()
    {
        var inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isRoll)
        {
            StartCoroutine(ResetIsRoll());
            isRoll = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isAttack)
        {
            StartCoroutine(ResetIsAttack());
            StartCoroutine(OutOfCombat());
            isAttack = true;
            iSCombat = false;
            IncreaseEnergy(GetStat(StatsEnum.EnergyAfterDealingDamage));
            IncreaseExperience(20);
            punchesSeries++;
        }
        
        if (Input.GetKey(KeyCode.E) && !isPickUp)
        {
            AddMoney(5);
            StartCoroutine(ResetIsPickUp());
            isPickUp = true;
        }
        
        if(Input.GetKeyDown(KeyCode.I))
        {
            skillTree.ShowMenu();
        }
        
        if(Input.GetKeyDown(KeyCode.Q) && currentlyEnergy == maxEnergy)
        {
            isSpecial = true;
            SpecialSpell();
            GetBuffs();
        }

        if (currentlyHealth <= 0)
        {
            DeathPlayer();
        }
        
        inputVector = inputVector.normalized;

        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        var playerSize = .5f;

        bool canMove = !Physics.Raycast(transform.position, moveDir, playerSize);

        if (canMove)
        {
            transform.position += moveDir * (GetStat(StatsEnum.MoveSpeed) * Time.deltaTime);
            
        if(isRoll){
            transform.position += moveDir * (GetStat(StatsEnum.MoveSpeed) * Time.deltaTime);
        }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            transform.position = new Vector3(0, 0, 0);
            SceneManager.LoadScene("Base");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            transform.position = new Vector3(0, 0, 0);
            SceneManager.LoadScene("Trader_Metal");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            transform.position = new Vector3(0, 0, 0);
            SceneManager.LoadScene("Trader_Forest");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneEnum[] allMaps = (SceneEnum[])Enum.GetValues(typeof(SceneEnum));
            var currentScene = SceneManager.GetActiveScene().name;
            SceneEnum randomMap;
            do
            {
                int randomIndex = random.Next(allMaps.Length);
                randomMap = allMaps[randomIndex];
            } while (currentScene == randomMap.ToString());
            
            transform.position = new Vector3(0, 0, 0);
            SceneManager.LoadScene(randomMap.ToString());
        }   
        
     
        isRunning = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime * rotateSpeed);
    }
    
    public void RestartStats()
    {
        SetStat(StatsEnum.RegenerationRate, 1.0f); 
        SetStat(StatsEnum.Damage, 5.0f); 
        SetStat(StatsEnum.Resistance, 0.0f); 
        SetStat(StatsEnum.CriticalDamage, 0.0f); 
        SetStat(StatsEnum.AttackCooldown, 0.54f); 
        SetStat(StatsEnum.DodgeChance, 1.0f); 
        SetStat(StatsEnum.MoveSpeed, 7.0f);
        SetStat(StatsEnum.ReflectingDamage, 1.0f);
        SetStat(StatsEnum.RollCooldown, 0.48f);
        SetStat(StatsEnum.CollectPercentageHealth, 0.0f);
        SetStat(StatsEnum.CriticalHitChance, 0.0f);
        SetStat(StatsEnum.InstantKillChance, 0.0f);
        SetStat(StatsEnum.StunningHitChance, 0.0f);
        SetStat(StatsEnum.EnergyAfterDealingDamage, 10.0f);
        SetStat(StatsEnum.EnergyAfterTakingDamage, 10.0f);
        
        for (int i=0; i < Enum.GetNames(typeof(StatsEnum)).Length; i++)
        {
            allBuffStats[i] = 0.0f;
        }
    }

    float GetStat(StatsEnum stat)
    {
        return allStats[(int)stat];
    }
    
    public bool IsStunning()
    {
        return Luck(GetStat(StatsEnum.StunningHitChance));
    }
    
    public bool IsInstantKill()
    {
        return Luck(GetStat(StatsEnum.InstantKillChance));
    }
    
    public int HpCollecting()
    {
        return (int)GetStat(StatsEnum.CollectPercentageHealth);
    }
    
    public void IncreaseBuffStat(StatsEnum stat, float value)
    {
        allBuffStats[(int)stat] += value;
    }

    void SetStat(StatsEnum stat, float value)
    {
        allStats[(int)stat] = value;
    }
    
    public void IncreaseStat(StatsEnum stat, float value)
    {
        allStats[(int)stat] += value;
    }

    void Init()
    {
        RestartStats();
        currentlyHealth = maxHealth;
        currentlyEnergy = 0;
        currentlyExperience = 0;
        detectability = 8.0f;
        healthBar.SetMaxHealth(maxHealth);   
        energyBar.SetMaxEnergy(maxEnergy);
        experienceBar.SetMaxExperience(maxExperience);
        healthBar.SetHealth(currentlyHealth);   
        energyBar.SetEnergy(currentlyEnergy);
        experienceBar.SetExperience(currentlyExperience);
        level = 0;
        isSpecial = false;
        isRoll = false;
    }
    
    //triggered every 1 second
    void Regenerate()
    {
        IncreaseHealth(iSCombat ? GetStat(StatsEnum.RegenerationRate) : GetStat(StatsEnum.RegenerationRateOutOfCombat));


        if (isSpecial)
        {
            if (currentlyEnergy > 0)
            {
                currentlyEnergy -= 5;
                energyBar.SetEnergy(currentlyEnergy);
            }
            else
            {
                ResetBuffs();
                isSpecial = false;
            }
            
        }
    }

    public int TotalDamage()
    {
        float summaryDamage = GetStat(StatsEnum.Damage);
        int iter;

        iter = punchesSeries>3 ? 3 : punchesSeries;
        
        for (int i = 0; i<iter;i++)
        {
            summaryDamage += GetStat(StatsEnum.SeriesDamage);
        }
        
        if (Luck(GetStat(StatsEnum.CriticalHitChance)))
        {
            summaryDamage +=  GetStat(StatsEnum.CriticalDamage);
        }

        return (int)summaryDamage;
    }
    
    public int ReflectingDamage()
    {
        return (int)GetStat(StatsEnum.ReflectingDamage);
    }
   
    private static bool Luck(float chance)
    {
        return Random.Range(0, 100) < chance;
    }

    
    void IncreaseHealth(float health)
    {
        if (currentlyHealth < maxHealth)
        {
            currentlyHealth += ((int)health);
        }
        healthBar.SetHealth(currentlyHealth);
    }


    void IncreaseEnergy(float energy)
    {
        if (currentlyEnergy < maxEnergy && !isSpecial)
        {
            currentlyEnergy += ((int)energy);
            energyBar.SetEnergy(currentlyEnergy);
        }
    }
    
    void IncreaseExperience(int exp)
    {
        if (currentlyExperience< maxExperience)
        {
            currentlyExperience += exp;
        }
        else
        {
            currentlyExperience = 0;
            IncreaseLevel(1);
        }
        experienceBar.SetExperience(currentlyExperience);
    }
    
    void IncreaseLevel(int lvl)
    {
        level += lvl;
        lvlDisplay.SetLvl(level);
        skillTree.UpLevel();
    }

    void GetBuffs()
    {
        for (int i=0; i < Enum.GetNames(typeof(StatsEnum)).Length; i++)
        {
            allStats[i] += allBuffStats[i];
        }
    }
    
    private void ResetBuffs()
    {
        for (int i=0; i < Enum.GetNames(typeof(StatsEnum)).Length; i++)
        {
            allStats[i] -= allBuffStats[i];
        }
    }
    
    void SpecialSpell()
    {
        
    }

    public float GetDetectability()
    {
        return detectability - GetStat(StatsEnum.LessDetectability);
    }

    
    void AddMoney(int earnedMoney)
    {
        money += (int)(earnedMoney + earnedMoney*GetStat(StatsEnum.PercentExtraMoney));
        moneyDisplay.SetMoney(money);
    }
    
    void DecreaseMoney(int decreaseMoney)
    {
        money -= decreaseMoney;
        moneyDisplay.SetMoney(money);
    }
    
    public void TakeDamage(float enemyDamage)
    {
        if (!Luck(GetStat(StatsEnum.DodgeChance)))
        {
            StartCoroutine(ResetIsGetHit());
            isGetHit = true;
            currentlyHealth -= (int)(enemyDamage - GetStat(StatsEnum.Resistance));
            IncreaseEnergy(GetStat(StatsEnum.EnergyAfterTakingDamage));
        }
    }

    void DeathPlayer()
    {
        if (Luck(GetStat(StatsEnum.RevivalChance)))
        {
            currentlyHealth = maxHealth;
        }
        else
        {
            SetStat(StatsEnum.MoveSpeed, 1.0f);
            rotateSpeed = 0f;
            isDeath = true;
        }
        
    }
    
    //Cooldown animation
    private IEnumerator ResetIsGetHit()
    {
        yield return new WaitForSeconds(0.42f);
        isGetHit = false;
    }
    private IEnumerator ResetIsRoll()
    {
        yield return new WaitForSeconds(GetStat(StatsEnum.RollCooldown));
        isRoll = false;
    }
    
    private IEnumerator ResetIsAttack()
    {
        yield return new WaitForSeconds(GetStat(StatsEnum.AttackCooldown));
        isAttack = false;
    }
    
    private IEnumerator OutOfCombat()
    {
        yield return new WaitForSeconds(5.0f);
        iSCombat = false;
        punchesSeries = 0;
    }


    private IEnumerator ResetIsPickUp()
    {
        yield return new WaitForSeconds(1.09f);
        isPickUp = false;
    }
    
    //Getters animation
    public bool IsRunning()
    {
        return isRunning;
    }

    public bool IsRoll()
    {
        return isRoll;
    }

    public bool IsAttack()
    {
        return isAttack;
    }

    public bool IsPickUp()
    {
        return isPickUp;
    }

    public bool IsDeath()
    {
        return isDeath;
    }

    public bool IsGetHit()
    {
        return isGetHit;
    }

    public bool IsStrongAttack()
    {
        return isStrongAttack;
    }

}
