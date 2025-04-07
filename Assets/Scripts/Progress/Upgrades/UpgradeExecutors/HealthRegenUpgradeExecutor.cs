using UnityEngine;

public class HealthRegenUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private PickupHandler pickupHandler;

    public override void Execute(UpgradeStat stat)
    {
        pickupHandler.SetHealthRegen(1 + (stat.statValue / 100));
    }
}
