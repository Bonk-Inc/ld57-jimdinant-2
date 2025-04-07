using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Upgrade
{
    [SerializeField]
    private string title = "Good Upgrade";
    [SerializeField]
    private UpgradeType type;
    [SerializeField]
    private List<UpgradeStat> upgradeValues;

    public string GetTitle
    {
        get { return title; }
    }

    public UpgradeType GetUpgradeType
    {
        get { return type; }
    }

    public List<UpgradeStat> UpgradeValues => upgradeValues;
}
