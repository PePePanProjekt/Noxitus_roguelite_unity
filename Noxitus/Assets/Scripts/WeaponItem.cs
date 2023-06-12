

using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponItem : InteractObject
{
    private float[] createdStat = new float[12];
    
    private InventoryScript inv;
    Weapon generatedWeapon;
    
    protected override void Init()
    {
        RandomCreate();
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
        
    }
    
    public void RandomCreate()
    {
        
    int randomWeapon = Random.Range(0, 5);

    switch (randomWeapon)
    {
        case 0:
            generatedWeapon = gameObject.AddComponent<Sword>();
            createdStat[(int)WeaponStat.BaseDamage] = Random.Range(3.0f, 7.0f);
            createdStat[(int)WeaponStat.BaseSeriesDamage] = Random.Range(0.0f, 2.0f);
            createdStat[(int)WeaponStat.BaseEnergyAfterDealingDamage] = Random.Range(1.0f, 5.0f);
            createdStat[(int)WeaponStat.BaseSpeedAttack] = Random.Range(0.2f, 2.0f);
            createdStat[(int)WeaponStat.BaseCriticalDamage] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCriticalChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseStunningChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseInstantKillChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCollectPercentageHealth] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffSpeed] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffRollCooldown] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffDetectability] = Random.Range(0.2f, 2.0f);
            generatedWeapon.SetStats(createdStat);
            break;
        case 1:
            generatedWeapon = gameObject.AddComponent<Katana>();
            createdStat[(int)WeaponStat.BaseDamage] = Random.Range(3.0f, 7.0f);
            createdStat[(int)WeaponStat.BaseSeriesDamage] = Random.Range(0.0f, 2.0f);
            createdStat[(int)WeaponStat.BaseEnergyAfterDealingDamage] = Random.Range(1.0f, 5.0f);
            createdStat[(int)WeaponStat.BaseSpeedAttack] = Random.Range(0.2f, 2.0f);
            createdStat[(int)WeaponStat.BaseCriticalDamage] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCriticalChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseStunningChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseInstantKillChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCollectPercentageHealth] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffSpeed] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffRollCooldown] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffDetectability] = Random.Range(0.2f, 2.0f);
            generatedWeapon.SetStats(createdStat);
            break;
        case 2:
            generatedWeapon = gameObject.AddComponent<Bow>();
            createdStat[(int)WeaponStat.BaseDamage] = Random.Range(3.0f, 7.0f);
            createdStat[(int)WeaponStat.BaseSeriesDamage] = Random.Range(0.0f, 2.0f);
            createdStat[(int)WeaponStat.BaseEnergyAfterDealingDamage] = Random.Range(1.0f, 5.0f);
            createdStat[(int)WeaponStat.BaseSpeedAttack] = Random.Range(0.2f, 2.0f);
            createdStat[(int)WeaponStat.BaseCriticalDamage] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCriticalChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseStunningChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseInstantKillChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCollectPercentageHealth] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffSpeed] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffRollCooldown] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffDetectability] = Random.Range(0.2f, 2.0f);
            generatedWeapon.SetStats(createdStat);
            break;
        case 3:
            generatedWeapon = gameObject.AddComponent<Crossbow>();
            createdStat[(int)WeaponStat.BaseDamage] = Random.Range(3.0f, 7.0f);
            createdStat[(int)WeaponStat.BaseSeriesDamage] = Random.Range(0.0f, 2.0f);
            createdStat[(int)WeaponStat.BaseEnergyAfterDealingDamage] = Random.Range(1.0f, 5.0f);
            createdStat[(int)WeaponStat.BaseSpeedAttack] = Random.Range(0.2f, 2.0f);
            createdStat[(int)WeaponStat.BaseCriticalDamage] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCriticalChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseStunningChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseInstantKillChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCollectPercentageHealth] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffSpeed] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffRollCooldown] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffDetectability] = Random.Range(0.2f, 2.0f);
            generatedWeapon.SetStats(createdStat);
            break;
        case 4:
            generatedWeapon = gameObject.AddComponent<Archtronic>();
            createdStat[(int)WeaponStat.BaseDamage] = Random.Range(3.0f, 7.0f);
            createdStat[(int)WeaponStat.BaseSeriesDamage] = Random.Range(0.0f, 2.0f);
            createdStat[(int)WeaponStat.BaseEnergyAfterDealingDamage] = Random.Range(1.0f, 5.0f);
            createdStat[(int)WeaponStat.BaseSpeedAttack] = Random.Range(0.2f, 2.0f);
            createdStat[(int)WeaponStat.BaseCriticalDamage] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCriticalChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseStunningChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseInstantKillChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCollectPercentageHealth] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffSpeed] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffRollCooldown] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffDetectability] = Random.Range(0.2f, 2.0f);
            generatedWeapon.SetStats(createdStat);
            break;
        case 5:
            generatedWeapon = gameObject.AddComponent<PlasmaKatana>();
            createdStat[(int)WeaponStat.BaseDamage] = Random.Range(3.0f, 7.0f);
            createdStat[(int)WeaponStat.BaseSeriesDamage] = Random.Range(0.0f, 2.0f);
            createdStat[(int)WeaponStat.BaseEnergyAfterDealingDamage] = Random.Range(1.0f, 5.0f);
            createdStat[(int)WeaponStat.BaseSpeedAttack] = Random.Range(0.2f, 2.0f);
            createdStat[(int)WeaponStat.BaseCriticalDamage] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCriticalChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseStunningChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseInstantKillChance] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.BaseCollectPercentageHealth] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffSpeed] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffRollCooldown] = Random.Range(0.2f, 0.4f);
            createdStat[(int)WeaponStat.DeBuffDetectability] = Random.Range(0.2f, 2.0f);
            generatedWeapon.SetStats(createdStat);
            break;
    }
    }
    
    public override String GetNote()
    {
        String note = "Name: " +  generatedWeapon.GetWeaponName() + "\n";

        for (int i = 0; i < 12; i++)
        {
            note += Enum.GetName(typeof(WeaponStat), i) + ": " + createdStat[i].ToString("F2")+ "\n";
        }
        return note;
    }
    
    public override void PickUpItem()
    {
        Debug.Log(generatedWeapon.GetStats());
        inv.NewWeapon(generatedWeapon);
    }

}
