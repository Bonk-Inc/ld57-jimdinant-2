using UnityEngine;

public class LevelUpManager : MonoBehaviour
{

    [SerializeField]
    private LevelUpSelect levelUpSelector;

    private int lastLevelHandled = 0;
    private int currentLevel = 0;

    public void OnLevelUp(PlayerLevel.LevelUpEventArgs args) {
        currentLevel = args.Level;
    }

    void Update()
    {
        if(currentLevel <= lastLevelHandled)
            return;

        if(!Input.GetKeyDown(KeyCode.F))
            return;

        levelUpSelector.Enable(currentLevel - lastLevelHandled);
        lastLevelHandled = currentLevel;
    }

}
