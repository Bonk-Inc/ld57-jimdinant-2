using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Stat", menuName = "Worm/Upgrade Stat")]
public class UpgradeStat : ScriptableObject
{
    public string UpgradeTitle = "Upgrade";
    public string UpgradeValueDescription = "Upgrade stat by {0}";
    
    public UpgradeType type;
    public UpgradeStat requiresStat = null;
    
    public int minLevel = 0;
    public int cost = 1;
    public float statValue;
    
    public bool infinite = false;

    [SerializeField, Header("Meta data")] private string note;

    public override String ToString()
    {
        return UpgradeTitle + ", infinite: " + infinite + ", statvalue: " + statValue + ", minLevel: " + minLevel + ", cost: " + cost;
    }
}
