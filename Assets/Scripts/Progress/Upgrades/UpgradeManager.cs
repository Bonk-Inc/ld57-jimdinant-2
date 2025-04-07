using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private List<UpgradeStat> upgrades;
    
    private static UpgradeManager instance;
    public static UpgradeManager Instance
    {
        get { return instance; }
    }
    
    private List<UpgradeStatData> upgradesData = new();
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        foreach (var upgrade in upgrades)
        {
            upgradesData.Add(new UpgradeStatData { UpgradeInfo = upgrade, Unlocked = false });
        }
    }
    
    public List<UpgradeStatData> GetUpgrades
    {
        get { return upgradesData; }
    }
    
    public List<UpgradeStat> GetPossibleUpgrades (int level)
    {
        var possibleUpgrades = new List<UpgradeStat>();
        foreach (UpgradeStatData upgrade in upgradesData)
        {
            var upgradeInfo = upgrade.UpgradeInfo;
            print(upgradeInfo);
            if (IsUnlocked(upgrade.UpgradeInfo) && !upgrade.UpgradeInfo.infinite) continue;
            
            if (upgradeInfo.minLevel > level) continue;
            
            if (upgradeInfo.requiresStat is not null && IsUnlocked(upgradeInfo)) continue; 
            
            possibleUpgrades.Add(upgrade.UpgradeInfo);
        }
        
        return possibleUpgrades;
    }
    
    public bool IsUnlocked (UpgradeStat stat)
    {
        var upgrade = FindUpgradeByName(stat);
        
        if (upgrade == null) return false;
        return upgrade.Unlocked;
    }

    public void UpgradeSelected(UpgradeStat stat)
    {
        var upgrade = FindUpgradeByName(stat);
        upgrade.Unlocked = true;
    }
    
    public UpgradeStatData FindUpgradeByName (UpgradeStat stat)
    {
        return upgradesData.Find(upgradeStat => upgradeStat.UpgradeInfo.name == stat.name);
    }
    
    /*
     * <summary>
     * Calculate the percentage of upgrades unlocked.
     * </summary>
     * <returns>Returns a value between 0 and 1.</returns>
     */
    public float GetPercentageUnlocked()
    {
        float totalUpgrades = upgrades.Count;
        float unlockedUpgrades = 0;

        foreach (UpgradeStatData upgrade in upgradesData)
        {
            if (upgrade.Unlocked) unlockedUpgrades++;
        }

        if (unlockedUpgrades == 0) return 0;
        
        return unlockedUpgrades / totalUpgrades;
    }
}
