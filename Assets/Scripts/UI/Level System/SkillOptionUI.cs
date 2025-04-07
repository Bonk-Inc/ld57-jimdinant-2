using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillOptionUI : MonoBehaviour
{

    [SerializeField]
    private Image iconUI;

    [SerializeField]
    private TextMeshProUGUI titleText, descriptionText;

    public event Action<UpgradeStat> OnSelected;
    
    private UpgradeStat upgrade;

    public void SetContent(UpgradeStat upgradeStat) {
        titleText.SetText(upgradeStat.UpgradeTitle);
        descriptionText.SetText(String.Format(upgradeStat.UpgradeValueDescription, upgradeStat.statValue));
        
        upgrade = upgradeStat;
    }

    public void Select()
    {
        OnSelected?.Invoke(upgrade);
    }
}
