
using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float baseDamage, baseSeriesDamage,baseEnergyAfterDealingDamage,  baseSpeedAttack, baseCriticalDamage, baseCriticalChance, baseStunningChance, baseInstantKillChance,  baseCollectPercentageHealth;
    private float deBuffSpeed, deBuffRollCooldown, deBuffDetectability;
    private float[] baseStat, baseBuffStat;

    public void SetWeapon(float[][] bStat, float[][] bBStat, float[] createdStat)
    {
        baseStat = bStat[GetWeaponType()];
        baseBuffStat = bBStat[GetWeaponType()];

        baseDamage = createdStat[(int)WeaponStat.BaseDamage];
        baseSeriesDamage =createdStat[(int)WeaponStat.BaseSeriesDamage];
        baseCriticalDamage = createdStat[(int)WeaponStat.BaseCriticalDamage];
        baseCriticalChance = createdStat[(int)WeaponStat.BaseCriticalChance];
        baseSpeedAttack = createdStat[(int)WeaponStat.BaseSpeedAttack];
        baseStunningChance = createdStat[(int)WeaponStat.BaseStunningChance];
        baseInstantKillChance = createdStat[(int)WeaponStat.BaseInstantKillChance];
        baseEnergyAfterDealingDamage = createdStat[(int)WeaponStat.BaseEnergyAfterDealingDamage];
        baseCollectPercentageHealth = createdStat[(int)WeaponStat.BaseCollectPercentageHealth];

        deBuffSpeed = createdStat[(int)WeaponStat.DeBuffSpeed]; 
        deBuffRollCooldown = createdStat[(int)WeaponStat.DeBuffRollCooldown];
        deBuffDetectability = createdStat[(int)WeaponStat.DeBuffDetectability];
    }
    
  

    public float GetBaseDamage()
     {
         return baseDamage;
     }
     
     public float GetBaseSpeedAttack()
     {
         return baseSpeedAttack;
     }
     
     public float GetBaseSeriesDamage()
     {
         return baseSeriesDamage;
     }
     
     public float GetBaseEnergyAfterDealingDamage()
     {
         return baseEnergyAfterDealingDamage;
     }
     
     public virtual WeaponList GetWeaponName()
     {
         return WeaponList.Sword;
     }
     
     public String GetStats()
     {
         String note = "Name: " + GetWeaponName() + "/n";
        
             note += "Damage: " +baseDamage+"Series Damage: "+ baseSeriesDamage+"Energy: "+baseEnergyAfterDealingDamage
                     +"speed Attack: "+ baseSpeedAttack+"critical damage: "+ baseCriticalDamage+"critical chance: "+ baseCriticalChance
                     +"stunning chance: "+ baseStunningChance+"instant kill chance: "+ baseInstantKillChance+"collecting health: "+  baseCollectPercentageHealth
                     +"de buff speed: "+ deBuffSpeed+"de buff dash: "+ deBuffRollCooldown+"de buff detectability: "+ deBuffDetectability;
             return note;
     }

     public void AddWeaponStats()
     {
         baseStat[(int)StatsEnum.CriticalDamage] += baseCriticalDamage;
         baseStat[(int)StatsEnum.CriticalHitChance] += baseCriticalChance;
         baseStat[(int)StatsEnum.StunningHitChance] += baseStunningChance;
         baseStat[(int)StatsEnum.InstantKillChance] += baseInstantKillChance;
         baseStat[(int)StatsEnum.CollectPercentageHealth] += baseCollectPercentageHealth;
         baseStat[(int)StatsEnum.LessDetectability] += deBuffDetectability;
         baseStat[(int)StatsEnum.RollCooldown] += deBuffRollCooldown;
         baseStat[(int)StatsEnum.MoveSpeed] += deBuffSpeed;
         
         baseBuffStat[(int)StatsEnum.CriticalDamage] += baseCriticalDamage;
         baseBuffStat[(int)StatsEnum.CriticalHitChance] += baseCriticalChance;
         baseBuffStat[(int)StatsEnum.StunningHitChance] += baseStunningChance;
         baseBuffStat[(int)StatsEnum.InstantKillChance] += baseInstantKillChance;
         baseBuffStat[(int)StatsEnum.CollectPercentageHealth] += baseCollectPercentageHealth;
         baseBuffStat[(int)StatsEnum.LessDetectability] += deBuffDetectability;
         baseBuffStat[(int)StatsEnum.RollCooldown] += deBuffRollCooldown;
         baseBuffStat[(int)StatsEnum.MoveSpeed] += deBuffSpeed;
     }
     
     public void DeletedWeaponStats()
     {
         baseStat[(int)StatsEnum.CriticalDamage] -= baseCriticalDamage;
         baseStat[(int)StatsEnum.CriticalDamage] -= baseCriticalChance;
         baseStat[(int)StatsEnum.CriticalDamage] -= baseStunningChance;
         baseStat[(int)StatsEnum.CriticalDamage] -= baseInstantKillChance;
         baseStat[(int)StatsEnum.CriticalDamage] -= baseCollectPercentageHealth;
         baseStat[(int)StatsEnum.CriticalDamage] -= deBuffDetectability;
         baseStat[(int)StatsEnum.CriticalDamage] -= deBuffRollCooldown;
         baseStat[(int)StatsEnum.CriticalDamage] -= deBuffSpeed;
         
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= baseCriticalDamage;
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= baseCriticalChance;
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= baseStunningChance;
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= baseInstantKillChance;
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= baseCollectPercentageHealth;
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= deBuffDetectability;
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= deBuffRollCooldown;
         baseBuffStat[(int)StatsEnum.CriticalDamage] -= deBuffSpeed;
     }
     
     public virtual int GetWeaponType()
     {
         return (int)WeaponType.MeleeWeapon;
     }
    
}

public class MeleeWeapon : Weapon
{
    public override int GetWeaponType()
    {
        return (int)WeaponType.MeleeWeapon;
    }
    
 
}

public class DistanceWeapon : Weapon
{
    public override int GetWeaponType()
    {
        return (int)WeaponType.DistanceWeapon;
    }
    
 
}

public class CosmicWeapon : Weapon
{
    public override int GetWeaponType()
    {
        return (int)WeaponType.CosmicWeapon;
    }
    
  
}

public class Katana : MeleeWeapon
{
    public override WeaponList GetWeaponName()
    {
        return WeaponList.Katana;
    }
    
   
}

public class Sword : MeleeWeapon
{
    public override WeaponList GetWeaponName()
    {
        return WeaponList.Sword;
    }
    
   
}

public class Bow : DistanceWeapon
{
    public override WeaponList GetWeaponName()
    {
        return WeaponList.Bow;
    }
    
   
}

public class PlasmaKatana : MeleeWeapon
{
    public override WeaponList GetWeaponName()
    {
        return WeaponList.PlasmaKatana;
    }
    
 
}

public class Archtronic : DistanceWeapon
{
    public override WeaponList GetWeaponName()
    {
        return WeaponList.Archtronic;
    }
    
   
}

public class Crossbow : DistanceWeapon
{
    public override WeaponList GetWeaponName()
    {
        return WeaponList.Crossbow;
    }
    
}