using UnityEngine;
using UnityEngine.Events;

public abstract class Achievement : MonoBehaviour
{
    protected bool achieved = false;
    public bool Achieved => achieved;
    
    public abstract bool CheckCondition();
    public abstract void OnConditionMet();

}
