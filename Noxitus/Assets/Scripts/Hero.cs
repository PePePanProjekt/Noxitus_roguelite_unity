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
    private float maxHealth = 100f;
    private const int MaxEnergy = 100;
    private const int MaxExperience = 100;
    
    private int  punchesSeries;
    private float rotateSpeed = 10f, detectability;
    
    private static readonly int StatsEnumNumber = Enum.GetNames(typeof(StatsEnum)).Length;

    private readonly float[][] allStats = {
        new float[StatsEnumNumber],
        new float[StatsEnumNumber],
        new float[StatsEnumNumber]
    };
    
    private readonly float[][] allBuffStats = {
        new float[StatsEnumNumber],
        new float[StatsEnumNumber],
        new float[StatsEnumNumber]
    };
    
    private int firstWeapon, secondWeapon;
    private Weapon[] storageWeapon = new Weapon[6];
    private float currentlyHealth;
    private int currentlyEnergy, money, level, currentlyExperience;

    // Animation variables
    private bool isRunning, isRoll, isAttack, isPickUp, isDeath, isGetHit, isStrongAttack, isShoot;
    private bool isFury, isCombat;
    
    //UI
    private HealthBarScript healthBar;
    private EnergyBarScript energyBar;
    private ExperienceBarScript experienceBar;
    private MoneyScript moneyDisplay;
    private LevelScript lvlDisplay;
    private SkillTreeScript skillTree;
    private ShowInteract showInteract;
    private MousePosition mousePosInMap;
    private WeaponController weaponController;
    private InventoryScript inventory;
    
    
    
    private System.Random random = new System.Random();
    void Awake()
    {
        mousePosInMap = gameObject.AddComponent<MousePosition>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarScript>(); 
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBarScript>();
        experienceBar = GameObject.FindGameObjectWithTag("ExperienceBar").GetComponent<ExperienceBarScript>();
        moneyDisplay = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScript>();
        lvlDisplay = GameObject.FindGameObjectWithTag("Lvl").GetComponent<LevelScript>();
        skillTree = GameObject.FindGameObjectWithTag("SkillTree").GetComponent<SkillTreeScript>();
        showInteract = GameObject.FindGameObjectWithTag("Notification").GetComponent<ShowInteract>();
        weaponController = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
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

        inputVector = inputVector.normalized;

        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * (GetStat(StatsEnum.MoveSpeed) * Time.deltaTime);

        isRunning = moveDir != Vector3.zero;

        if (Input.GetKeyUp(KeyCode.Space) && !isRoll)
        {
            StartCoroutine(ResetIsRoll());
            isRoll = true;
        }

        if (isRoll)
        {
            transform.position += moveDir * (GetStat(StatsEnum.MoveSpeed) * Time.deltaTime);
        }
        
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime * rotateSpeed);
        
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isAttack)
        {
            StartCoroutine(ResetIsAttack());
            StartCoroutine(OutOfCombat());
            isAttack = true;
            isCombat = true;
            IncreaseEnergy(GetStat(StatsEnum.EnergyAfterDealingDamage));
            IncreaseExperience(20);
            punchesSeries++;
            
            if (Vector3.Distance(transform.position, mousePosInMap.GetMousePos()) < 5.0f)
            {
                transform.LookAt(mousePosInMap.GetMousePos());
                
                transform.position = mousePosInMap.GetMousePos();
            }
            else
            {
                transform.LookAt(mousePosInMap.GetMousePos());
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    mousePosInMap.GetMousePos(),
                    5.0f
                );
            }
        }
        
        if (Input.GetKey(KeyCode.Mouse0) && !isAttack)
        {
            StartCoroutine(ResetIsAttack());
            StartCoroutine(OutOfCombat());
            isAttack = true;
            isCombat = true;
            IncreaseEnergy(GetStat(StatsEnum.EnergyAfterDealingDamage));
            IncreaseExperience(20);
            punchesSeries++;
            
            if (Vector3.Distance(transform.position, mousePosInMap.GetMousePos()) < 5.0f)
            {
                transform.LookAt(mousePosInMap.GetMousePos());
                
                transform.position = mousePosInMap.GetMousePos();
            }
            else
            {
                transform.LookAt(mousePosInMap.GetMousePos());
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    mousePosInMap.GetMousePos(),
                    5.0f
                );
            }
        }
        
        if (Input.GetKey(KeyCode.E) && !isPickUp)
        {
            showInteract.InteractButton();
            AddMoney(5);
            StartCoroutine(ResetIsPickUp());
            isPickUp = true;
        }
        
        if(Input.GetKeyDown(KeyCode.I))
        {
            skillTree.ShowMenu();
        }
        
        if(Input.GetKeyDown(KeyCode.O))
        {
            inventory.ShowInventory();
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            
        }
        
        if(Input.GetKeyDown(KeyCode.F) && currentlyEnergy == MaxEnergy)
        {
            isFury = true;
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

        weaponController.WeaponDisplay(storageWeapon[firstWeapon].GetWeaponName(), isRunning);
    }
    
    //init
    void Init()
    {
        SetBaseStats();
        currentlyHealth = maxHealth;
        currentlyEnergy = 0;
        currentlyExperience = 0;
        detectability = 8.0f;
        healthBar.SetMaxHealth((int)maxHealth);   
        energyBar.SetMaxEnergy(MaxEnergy);
        experienceBar.SetMaxExperience(MaxExperience);
        healthBar.SetHealth((int)currentlyHealth);   
        energyBar.SetEnergy(currentlyEnergy);
        experienceBar.SetExperience(currentlyExperience);
        level = 0;
        isFury = false;
        isRoll = false;
        
        
        float[] createdStat = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        firstWeapon = 0;
        Weapon newFirst = gameObject.AddComponent<Sword>();
        newFirst.SetStats(createdStat);
        newFirst.SetWeapon(GetAllStats(), GetAllBuffStats());
        
        StartWeapon(newFirst);

        float[] gfggg = { 1, 2, 3, 4, 5, 5, 5, 5, 5, 5, 5, 5 };
        firstWeapon = 0;
        Weapon rrrr = gameObject.AddComponent<Crossbow>();
        newFirst.SetStats(gfggg);
        rrrr.SetWeapon(GetAllStats(), GetAllBuffStats());

        EquipNewWeapon(rrrr, 3);
    }
    
    //triggered every 1 second
    void Regenerate()
    {
        IncreaseHealth(isCombat ? GetStat(StatsEnum.RegenerationRate) : GetStat(StatsEnum.RegenerationRateOutOfCombat));

        if (isFury)
        {
            if (currentlyEnergy > 0)
            {
                currentlyEnergy -= 5;
                energyBar.SetEnergy(currentlyEnergy);
            }
            else
            {
                ResetBuffs();
                isFury = false;
            }
        }
    }

    //combat system
    public float TotalDamage()
    {
        float summaryDamage = GetWeapon().GetBaseDamage()*GetStat(StatsEnum.Damage);
        int iter;

        iter = punchesSeries>3 ? 3 : punchesSeries;
        
        for (int i = 0; i<iter;i++)
        {
            summaryDamage += GetWeapon().GetBaseSeriesDamage()*GetStat(StatsEnum.SeriesDamage);
        }
        
        if (Luck(GetStat(StatsEnum.CriticalHitChance)))
        {
            summaryDamage +=  GetWeapon().GetBaseDamage()*GetStat(StatsEnum.CriticalDamage);
        }

        return summaryDamage;
    }
    
    public void TakeDamage(float enemyDamage)
    {
        if (!Luck(GetStat(StatsEnum.DodgeChance)))
        {
            isCombat = true;
            StartCoroutine(OutOfCombat());
            StartCoroutine(ResetIsGetHit());
            isGetHit = true;
            currentlyHealth -= enemyDamage - enemyDamage*GetStat(StatsEnum.Resistance);
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
            allStats[storageWeapon[firstWeapon].GetWeaponType()][(int)StatsEnum.MoveSpeed] = 0.0f;
            
            rotateSpeed = 0f;
            isDeath = true;
        }
    }

    public void ChangeWeapon(int newSelected)
    {
        if (storageWeapon[newSelected] is not null)
        {
            firstWeapon = newSelected;
        }
    }
    
    public void EquipNewWeapon(Weapon newSelected, int pos)
    {
        if (pos == firstWeapon)
        {
            storageWeapon[pos].DeletedWeaponStats();
            storageWeapon[pos] = newSelected;
            storageWeapon[pos].AddWeaponStats();
        }
        else
        {
            storageWeapon[pos] = newSelected;
        }
    }
    
    public Weapon GetWeapon()
    {
        return storageWeapon[firstWeapon];
    }
    
    public Weapon[] GetAllWeapon()
    {
        return storageWeapon;
    }
    
    // getter and setter stats
    public float GetStat(StatsEnum selectedStat)
    {
        return allStats[storageWeapon[firstWeapon].GetWeaponType()][(int)selectedStat];
    }
    
    public float[][] GetAllStats()
    {
        return allStats;
    }
    
    public float[][] GetAllBuffStats()
    {
        return allBuffStats;
    }
    
    public void SetStat(StatsEnum stat, WeaponType selectedType, float value)
    {
        allStats[(int)selectedType][(int)stat] = value;
    }

    public void IncreaseStat(StatsEnum stat, WeaponType selectedType, float value)
    {
        allStats[(int)selectedType][(int)stat] += value;
    }
    
    // fury buffs
    public float GetBuffStat(StatsEnum selectedStat)
    {
        return allBuffStats[storageWeapon[firstWeapon].GetWeaponType()][(int)selectedStat];
    }
    
    public void SetBuffStat(StatsEnum stat, WeaponType selectedType, float value)
    {
        allBuffStats[(int)selectedType][(int)stat] = value;
    }
    public void IncreaseBuffStat(StatsEnum stat, WeaponType selectedType, float value)
    {
        allBuffStats[(int)selectedType][(int)stat] += value;
    }
    void GetBuffs()
    {
        for (int i=0; i < Enum.GetNames(typeof(StatsEnum)).Length; i++)
        {
            allStats[storageWeapon[firstWeapon].GetWeaponType()][i] += allBuffStats[storageWeapon[firstWeapon].GetWeaponType()][i];
        }
    }
    
    void ResetBuffs()
    {
        for (int i=0; i < Enum.GetNames(typeof(StatsEnum)).Length; i++)
        {
            allStats[storageWeapon[firstWeapon].GetWeaponType()][i] -= allBuffStats[storageWeapon[firstWeapon].GetWeaponType()][i];
        }
    }
    
    //methods to override
    public virtual void SetBaseStats()
    {
        
    }
    
    protected void StartWeapon(Weapon startWeapon)
    {
        storageWeapon[firstWeapon] = startWeapon;
    }

    
    protected virtual void SpecialSpell()
    {
        
    }
    
    //health
    void IncreaseHealth(float health)
    {
        if (currentlyHealth < maxHealth)
        {
            currentlyHealth += ((int)health);
        }
        healthBar.SetHealth((int)currentlyHealth);
    }
    
    //energy
    void IncreaseEnergy(float energy)
    {
        if (currentlyEnergy < MaxEnergy && !isFury)
        {
            currentlyEnergy += ((int)energy);
            energyBar.SetEnergy(currentlyEnergy);
        }
    }
    
    //level
    void IncreaseExperience(int exp)
    {
        if (currentlyExperience< MaxExperience)
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
    
    //money
    void AddMoney(int earnedMoney)
    {
        money += (int)(earnedMoney + (earnedMoney*GetStat(StatsEnum.PercentExtraMoney)));
        moneyDisplay.SetMoney(money);
    }
    
    void SpendMoney(int decreaseMoney)
    {
        money -= decreaseMoney;
        moneyDisplay.SetMoney(money);
    }
    
    //getters
    public float ReflectingDamage(float takingDamage)
    {
        return GetStat(StatsEnum.ReflectingDamage) * takingDamage;
    }
    
    public float GetDetectability()
    {
        return detectability - GetStat(StatsEnum.LessDetectability);
    }
    
    //getters and luck
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

    private static bool Luck(float chance)
    {
        return Random.Range(0, 100) < chance;
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
        isCombat = false;
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
