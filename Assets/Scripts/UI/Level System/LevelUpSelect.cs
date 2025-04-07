using System.Collections.Generic;
using System.Linq;
using Bonk.StandardLibrary.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LevelUpSelect : MonoBehaviour
{
    [SerializeField] private PlayerLevel playerLevel;
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private UpgradeTracker upgradeTracker;
    
    [SerializeField]
    private List<SkillOptionUI> skillOptionUIs;

    [SerializeField, Header("Controller Requirements")] private GameObject firstSelected;
    
    private Canvas canvas;
    private int levelUpsLeft;
    private bool open = false;
    
    public UnityEvent OnSkillSelected;

    void Awake()
    {
        foreach (var skillOptionUI in skillOptionUIs)
        {
            skillOptionUI.OnSelected += SelectSkill;
        }

        canvas = gameObject.GetComponent<Canvas>();
    }

    public void Enable(int levelsUps) {
        if (levelsUps <= 0)
            return;
        
        canvas.enabled = true;
        open = true;
        EventSystem.current.SetSelectedGameObject(firstSelected);
        
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
            if (upgrades.Count == 0)
            {
                skillOptionUI.SetEmpty();
                continue;
            }
            var upgrade = upgrades.GetRandom();
            upgradesToShow.Add(upgrade);
            upgrades.Remove(upgrade);
            
            skillOptionUI.SetContent(upgrade);
        }
    }

    public void SelectSkill(UpgradeStat upgrade) {
        if (!open) return;
        
        upgradeTracker.ExecuteUpgrade(upgrade);
        upgradeManager.UpgradeSelected(upgrade);
        
        levelUpsLeft -= 1;
        if (levelUpsLeft <= 0)
        {
            Disable();
            return;
        }
        
        ShowSkills();
    }

    public void Disable(){
        open = false;
        canvas.enabled = false;
        Time.timeScale = 1;
        levelUpsLeft = 0;
        
        OnSkillSelected.Invoke();
    }
}
