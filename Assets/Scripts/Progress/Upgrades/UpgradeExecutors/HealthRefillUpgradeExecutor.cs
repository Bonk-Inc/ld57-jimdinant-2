using Bonk.StandardLibrary;
using UnityEngine;

public class HealthRefillUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private Health health;

    private const int HealthRatio = 100;

    public override void Execute(UpgradeStat stat)
    {
        health.Heal(Mathf.RoundToInt(stat.statValue * HealthRatio));
    }
}
