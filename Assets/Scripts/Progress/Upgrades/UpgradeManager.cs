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

    public UnityEvent<UpgradeStat> OnUpgrade;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    public List<UpgradeStat> GetUpgrades
    {
        get { return upgrades; }
    }
    
    public List<UpgradeStat> GetPossibleUpgrades (int level)
    {
        var possibleUpgrades = new List<UpgradeStat>();
        foreach (UpgradeStat upgrade in upgrades)
        {
            if (IsUnlocked(upgrade) && !upgrade.infinite) continue;
            
            if (upgrade.minLevel > level) continue;
            
            if (upgrade.requiresStat != null && IsUnlocked(upgrade.requiresStat)) continue; 
            
            possibleUpgrades.Add(upgrade);
        }
        
        return possibleUpgrades;
    }
    
    public bool IsUnlocked (UpgradeStat stat)
    {
        var upgrade = upgrades.Find(upgradeStat => upgradeStat.name == stat.name);
        
        if (upgrade == null) return false;
        return upgrade.unlocked;
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

        foreach (UpgradeStat upgrade in upgrades)
        {
            if (upgrade.unlocked) unlockedUpgrades++;
        }

        if (unlockedUpgrades == 0) return 0;
        
        return unlockedUpgrades / totalUpgrades;
    }
}
