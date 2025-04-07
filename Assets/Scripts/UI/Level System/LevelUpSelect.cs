using System.Collections.Generic;
using System.Linq;
using Bonk.StandardLibrary.Collections;
using UnityEngine;

public class LevelUpSelect : MonoBehaviour
{
    [SerializeField] private PlayerLevel playerLevel;
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private UpgradeTracker upgradeTracker;
    
    [SerializeField]
    private List<SkillOptionUI> skillOptionUIs;

    private int levelUpsLeft;

    void Awake()
    {
        foreach (var skillOptionUI in skillOptionUIs)
        {
            skillOptionUI.OnSelected += SelectSkill;
        }
    }

    public void Enable(int levelsUps) {
        if (levelsUps <= 0)
            return;
        
        gameObject.SetActive(true);
        levelUpsLeft = levelsUps;
        Time.timeScale = 0;
        ShowSkills();
    }

    private void ShowSkills()
    {
        var upgrades = upgradeManager.GetPossibleUpgrades(playerLevel.CurrentLevel);
        var upgradesToShow = new List<UpgradeStat>();

        foreach (var skillOptionUI in skillOptionUIs)
        {
            var upgrade = upgrades.GetRandom();
            upgradesToShow.Add(upgrade);
            upgrades.Remove(upgrade);
            
            skillOptionUI.SetContent(upgrade);
        }
    }

    public void SelectSkill(UpgradeStat upgrade) {
        upgradeTracker.ExecuteUpgrade(upgrade);
        
        levelUpsLeft -= 1;
        if (levelUpsLeft <= 0)
        {
            Disable();
            return;
        }
        
        ShowSkills();
    }

    public void Disable(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
        levelUpsLeft = 0;
    }
}
