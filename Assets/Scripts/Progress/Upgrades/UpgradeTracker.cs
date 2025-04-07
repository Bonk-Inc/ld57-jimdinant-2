using System.Collections.Generic;
using UnityEngine;

public class UpgradeTracker : MonoBehaviour
{
    [SerializeField] private List<UpgradeTypeExecutor> upgradeExecutors;

    public void ExecuteUpgrade(UpgradeStat upgrade)
    {
        var upgradeExecutor = upgradeExecutors.Find(executor => executor.upgradeType == upgrade.type);
        
        upgradeExecutor.executor.Execute(upgrade);
    }
}
