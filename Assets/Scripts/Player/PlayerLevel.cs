using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{

    [field:SerializeField]
    public int CurrentLevel { get; private set; }

    [SerializeField]
    private int firstLevelXp = 10;

    private int currentXp = 0;
    private int requiredXp;

    public UnityEvent<XpChangeEventArgs> OnXpChanged; 
    public UnityEvent<LevelUpEventArgs> OnLevelUp; 

    private void Awake() {
        requiredXp = GetRequiedXpForLevel(CurrentLevel + 1);
    }

    public void AddXp(int amount) {
        var oldXp = currentXp;
        currentXp += amount;
        CheckLevelup();
        OnXpChanged?.Invoke(new () {
            OldXp = oldXp,
            CurrentXp = currentXp,
            XpChange = amount,
            CurrentTarget = requiredXp,
            Level = CurrentLevel
        });
    }

    private bool CheckLevelup(int levelUpCount = 0){
        if(currentXp < requiredXp)
            return false;

        CurrentLevel ++;
        currentXp -= requiredXp;
        requiredXp = GetRequiedXpForLevel(CurrentLevel);
        levelUpCount ++;
        if(!CheckLevelup(levelUpCount + 1)){
            OnLevelUp?.Invoke(new () {
                Level = CurrentLevel,
                LevelUps = levelUpCount
            });
        }
        return true;
    }

    private int GetRequiedXpForLevel(int level) =>
        firstLevelXp * (int)Math.Pow(2, level - 1);


    public class LevelUpEventArgs
    {
        public int Level {get; set;}
        public int LevelUps {get; set;}
    }

    public class XpChangeEventArgs
    {
        public int OldXp { get; set; }
        public int CurrentXp { get; set; }
        public int XpChange { get; set;}

        public int CurrentTarget {get; set;}

        public int Level {get; set;}
    }

    [ContextMenu("Add level")]
    private void AddLevel() => AddXp(requiredXp);

    [ContextMenu("Add half level")]
    private void AddHalfLevel() => AddXp(requiredXp / 2);

    [ContextMenu("Add quarter level")]
    public void AddQuarterLevel() => AddXp(requiredXp / 4);

}
