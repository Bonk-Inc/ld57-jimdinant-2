using Bonk.StandardLibrary;
using UnityEngine;

public class HealthUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private Health health;

    private const int HealthRatio = 1000;

    public override void Execute(UpgradeStat stat)
    {
        health.SetMaxHealth(Mathf.RoundToInt(health.MaxHealth + (stat.statValue * HealthRatio)));
        health.Heal(Mathf.RoundToInt(stat.statValue * HealthRatio));
    }
}
