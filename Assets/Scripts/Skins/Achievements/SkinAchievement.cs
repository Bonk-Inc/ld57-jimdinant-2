using UnityEngine;
using UnityEngine.Events;

public abstract class SkinAchievement : Achievement
{
    public UnityEvent<Skin> onAchievementGet;
    
    [SerializeField]
    protected Skin skin;
    
    public override void OnConditionMet()
    {
        achieved = true;
        
        SkinManager.Instance.SetSkin(skin.name);
        SkinManager.Instance.Unlock(skin.name);
        
        onAchievementGet?.Invoke(skin);
    }
}
