using System.Collections.Generic;
using UnityEngine;

public class LevelUpSelect : MonoBehaviour
{

    [SerializeField]
    private List<SkillOptionUI> skillOptionUIs;

    private int levelUpsLeft;

    void Awake()
    {
        for (int i = 0; i < skillOptionUIs.Count; i++)
        {
            skillOptionUIs[i].OnSelected += () => {
                SelectSkill(i);
            };
        }
    }

    public void Enable(int levelsUps) {
        print(levelsUps);
        if(levelsUps <= 0)
            return;
        gameObject.SetActive(true);
        levelUpsLeft = levelsUps;
        Time.timeScale = 0;
        ShowSkills();
    }

    private void ShowSkills(){
        var skillCountToShow = skillOptionUIs.Count;
        // TODO Select Different Options
        // TODO show different options
        // TOTO store these options indexed so the select skill knows which one is selected
    }

    public void SelectSkill(int index) {
        // TODO get selected skill with index, send it to whatever deals with it 
        ShowSkills();
        levelUpsLeft -= 1;
        if(levelUpsLeft <= 0)
            Disable();
    }

    public void Disable(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
        levelUpsLeft = 0;
    }
}
