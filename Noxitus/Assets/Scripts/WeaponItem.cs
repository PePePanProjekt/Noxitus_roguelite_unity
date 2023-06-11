

using System;
using Random = UnityEngine.Random;

public class WeaponItem : InteractObject
{
    private float[] createdStat = new float[12];
    private WeaponList nameType;


    protected override void Init()
    {
        RandomCreate();
    }
    
    public void RandomCreate()
    {
        
    int randomWeapon = Random.Range(0, 11);

    switch (randomWeapon)
    {
        case 0:
            nameType = WeaponList.Sword;
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
            break;
        case 1:
            nameType = WeaponList.Katana;
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
            break;
        case 2:
            nameType = WeaponList.Bow;
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
            break;
        case 3:
            nameType = WeaponList.Crossbow;
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
            break;
        case 4:
            nameType = WeaponList.Archtronic;
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
            break;
        case 5:
            nameType = WeaponList.PlasmaKatana;
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
            break;
    }
    
 
    }
    
    public override String GetNote()
    {
        String note = "Name: " + nameType + "\n";

        for (int i = 0; i < 12; i++)
        {
            note += Enum.GetName(typeof(WeaponStat), i) + ": " + createdStat[i].ToString("F2")+ "\n";
        }
        
        return note;
    }
    
   

}
