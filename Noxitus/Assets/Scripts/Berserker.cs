
public class Berserker : Hero
{

    protected override void SpecialSpell()
    {
        
    }
    
    
    //set berserker stats
    public override void SetBaseStats()
    {
        //berserker stats melee
        WeaponType melee = WeaponType.MeleeWeapon;
        
        //attack
        SetStat(StatsEnum.Damage, melee, 1.2f); // 120% base melee weapon damage
        SetStat(StatsEnum.AttackCooldown,melee, 2.0f); // 200% base melee weapon speed attack
        SetStat(StatsEnum.SeriesDamage,melee, 3.0f); // 300% base series damage melee weapon damage
        SetStat(StatsEnum.EnergyAfterDealingDamage,melee, 2.0f); // 200% base weapon energy after dealing damage
        
        SetStat(StatsEnum.CriticalDamage,melee, 0.2f); // +20% critical damage base melee weapon 
        SetStat(StatsEnum.CriticalHitChance,melee, 0.2f); // +20% critical chance base melee weapon 
        SetStat(StatsEnum.CollectPercentageHealth,melee, 0.05f); // +5% health collecting
        SetStat(StatsEnum.InstantKillChance,melee, 0.02f); // +2% chance to instant kill 
        SetStat(StatsEnum.StunningHitChance,melee, 0.3f); // +30% base melee weapon chance to stun
        
        //defence
        SetStat(StatsEnum.Resistance,melee, 0.2f); // -20% taking damage
        SetStat(StatsEnum.RegenerationRate,melee, 1.0f); // 1 hp per second
        SetStat(StatsEnum.RegenerationRateOutOfCombat,melee, 5.0f); // 5 hp per second when out of combat
        SetStat(StatsEnum.DodgeChance,melee, 0.2f); //20% chance to dodge damage
        SetStat(StatsEnum.ReflectingDamage,melee, 0.1f); // reflects 10% of damage taken
        SetStat(StatsEnum.RevivalChance,melee, 0.05f); // 5% chance to revival instead of dying
        SetStat(StatsEnum.EnergyAfterTakingDamage,melee, 2f); // +2 energy when taking damage
        
        //mobility
        SetStat(StatsEnum.LessDetectability,melee, 0.0f); // -0 detection distance 
        SetStat(StatsEnum.MoveSpeed,melee, 7f); // speed
        SetStat(StatsEnum.PercentExtraMoney,melee, 1.0f); // 100% found money
        SetStat(StatsEnum.RollCooldown,melee, 2.0f); // roll cooldown 
        
        //berserker stats melee buff fury
        //attack
        SetBuffStat(StatsEnum.Damage,melee, 5f);
        SetBuffStat(StatsEnum.AttackCooldown,melee, 2f);
        SetBuffStat(StatsEnum.CriticalDamage,melee, 0f);
        SetBuffStat(StatsEnum.CriticalHitChance,melee, 0f);
        SetBuffStat(StatsEnum.SeriesDamage,melee, 0f);
        SetBuffStat(StatsEnum.CollectPercentageHealth,melee, 0f);
        SetBuffStat(StatsEnum.InstantKillChance,melee, 0f);
        SetBuffStat(StatsEnum.StunningHitChance,melee, 0f);
        SetBuffStat(StatsEnum.EnergyAfterDealingDamage,melee, 2f);
        //defence
        SetBuffStat(StatsEnum.Resistance,melee, 0f);
        SetBuffStat(StatsEnum.RegenerationRate,melee, 1f);
        SetBuffStat(StatsEnum.RegenerationRateOutOfCombat,melee, 0f);
        SetBuffStat(StatsEnum.DodgeChance,melee, 0f);
        SetBuffStat(StatsEnum.ReflectingDamage,melee, 0f);
        SetBuffStat(StatsEnum.RevivalChance,melee, 0f);
        SetBuffStat(StatsEnum.EnergyAfterTakingDamage,melee, 0f);
        //mobility
        SetBuffStat(StatsEnum.LessDetectability,melee, 0f);
        SetBuffStat(StatsEnum.MoveSpeed,melee, 7f);
        SetBuffStat(StatsEnum.PercentExtraMoney,melee, 0f);
        SetBuffStat(StatsEnum.RollCooldown,melee, 2f);

        //berserker stats distance
        WeaponType distance = WeaponType.DistanceWeapon;
        //attack
        SetStat(StatsEnum.Damage,distance, 5f);
        SetStat(StatsEnum.AttackCooldown,distance, 2f);
        SetStat(StatsEnum.CriticalDamage,distance, 0f);
        SetStat(StatsEnum.CriticalHitChance,distance, 0f);
        SetStat(StatsEnum.SeriesDamage,distance, 0f);
        SetStat(StatsEnum.CollectPercentageHealth,distance, 0f);
        SetStat(StatsEnum.InstantKillChance,distance, 0f);
        SetStat(StatsEnum.StunningHitChance,distance, 0f);
        SetStat(StatsEnum.EnergyAfterDealingDamage,distance, 2f);
        //defence
        SetStat(StatsEnum.Resistance,distance, 0f);
        SetStat(StatsEnum.RegenerationRate,distance, 1f);
        SetStat(StatsEnum.RegenerationRateOutOfCombat,distance, 0f);
        SetStat(StatsEnum.DodgeChance,distance, 0f);
        SetStat(StatsEnum.ReflectingDamage,distance, 0f);
        SetStat(StatsEnum.RevivalChance,distance, 0f);
        SetStat(StatsEnum.EnergyAfterTakingDamage,distance, 0f);
        //mobility
        SetStat(StatsEnum.LessDetectability,distance, 0f);
        SetStat(StatsEnum.MoveSpeed,distance, 7f);
        SetStat(StatsEnum.PercentExtraMoney,distance, 0f);
        SetStat(StatsEnum.RollCooldown,distance, 2f);
        
        //berserker stats melee buff fury
        //attack
        SetBuffStat(StatsEnum.Damage,distance, 5f);
        SetBuffStat(StatsEnum.AttackCooldown,distance, 2f);
        SetBuffStat(StatsEnum.CriticalDamage,distance, 0f);
        SetBuffStat(StatsEnum.CriticalHitChance,distance, 0f);
        SetBuffStat(StatsEnum.SeriesDamage,distance, 0f);
        SetBuffStat(StatsEnum.CollectPercentageHealth,distance, 0f);
        SetBuffStat(StatsEnum.InstantKillChance,distance, 0f);
        SetBuffStat(StatsEnum.StunningHitChance,distance, 0f);
        SetBuffStat(StatsEnum.EnergyAfterDealingDamage,distance, 2f);
        //defence
        SetBuffStat(StatsEnum.Resistance,distance, 0f);
        SetBuffStat(StatsEnum.RegenerationRate,distance, 1f);
        SetBuffStat(StatsEnum.RegenerationRateOutOfCombat,distance, 0f);
        SetBuffStat(StatsEnum.DodgeChance,distance, 0f);
        SetBuffStat(StatsEnum.ReflectingDamage,distance, 0f);
        SetBuffStat(StatsEnum.RevivalChance,distance, 0f);
        SetBuffStat(StatsEnum.EnergyAfterTakingDamage,distance, 0f);
        //mobility
        SetBuffStat(StatsEnum.LessDetectability,distance, 0f);
        SetBuffStat(StatsEnum.MoveSpeed,distance, 7f);
        SetBuffStat(StatsEnum.PercentExtraMoney,distance, 0f);
        SetBuffStat(StatsEnum.RollCooldown,distance, 2f);
        
        //berserker stats cosmic
        WeaponType cosmic = WeaponType.CosmicWeapon;
        //attack
        SetStat(StatsEnum.Damage,cosmic, 5f);
        SetStat(StatsEnum.AttackCooldown,cosmic, 2f);
        SetStat(StatsEnum.CriticalDamage,cosmic, 0f);
        SetStat(StatsEnum.CriticalHitChance,cosmic, 0f);
        SetStat(StatsEnum.SeriesDamage,cosmic, 0f);
        SetStat(StatsEnum.CollectPercentageHealth,cosmic, 0f);
        SetStat(StatsEnum.InstantKillChance,cosmic, 0f);
        SetStat(StatsEnum.StunningHitChance,cosmic, 0f);
        SetStat(StatsEnum.EnergyAfterDealingDamage,cosmic, 2f);
        //defence
        SetStat(StatsEnum.Resistance,cosmic, 0f);
        SetStat(StatsEnum.RegenerationRate,cosmic, 1f);
        SetStat(StatsEnum.RegenerationRateOutOfCombat,cosmic, 0f);
        SetStat(StatsEnum.DodgeChance,cosmic, 0f);
        SetStat(StatsEnum.ReflectingDamage,cosmic, 0f);
        SetStat(StatsEnum.RevivalChance,cosmic, 0f);
        SetStat(StatsEnum.EnergyAfterTakingDamage,cosmic, 0f);
        //mobility
        SetStat(StatsEnum.LessDetectability,cosmic, 0f);
        SetStat(StatsEnum.MoveSpeed,cosmic, 7f);
        SetStat(StatsEnum.PercentExtraMoney,cosmic, 0f);
        SetStat(StatsEnum.RollCooldown,cosmic, 2f);
        
        //berserker stats melee buff fury
        //attack
        SetBuffStat(StatsEnum.Damage,cosmic, 5f);
        SetBuffStat(StatsEnum.AttackCooldown,cosmic, 2f);
        SetBuffStat(StatsEnum.CriticalDamage,cosmic, 0f);
        SetBuffStat(StatsEnum.CriticalHitChance,cosmic, 0f);
        SetBuffStat(StatsEnum.SeriesDamage,cosmic, 0f);
        SetBuffStat(StatsEnum.CollectPercentageHealth,cosmic, 0f);
        SetBuffStat(StatsEnum.InstantKillChance,cosmic, 0f);
        SetBuffStat(StatsEnum.StunningHitChance,cosmic, 0f);
        SetBuffStat(StatsEnum.EnergyAfterDealingDamage,cosmic, 2f);
        //defence
        SetBuffStat(StatsEnum.Resistance,cosmic, 0f);
        SetBuffStat(StatsEnum.RegenerationRate,cosmic, 1f);
        SetBuffStat(StatsEnum.RegenerationRateOutOfCombat,cosmic, 0f);
        SetBuffStat(StatsEnum.DodgeChance,cosmic, 0f);
        SetBuffStat(StatsEnum.ReflectingDamage,cosmic, 0f);
        SetBuffStat(StatsEnum.RevivalChance,cosmic, 0f);
        SetBuffStat(StatsEnum.EnergyAfterTakingDamage,cosmic, 0f);
        //mobility
        SetBuffStat(StatsEnum.LessDetectability,cosmic, 0f);
        SetBuffStat(StatsEnum.MoveSpeed,cosmic, 7f);
        SetBuffStat(StatsEnum.PercentExtraMoney,cosmic, 0f);
        SetBuffStat(StatsEnum.RollCooldown,cosmic, 2f);
    }
    
}
