using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWorm : SkinAchievement
{
    [SerializeField]
    private int spaceY;

    private void Update()
    {
        if (achieved) return;
        
        CheckCondition();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(transform.position.x - 10000, spaceY, 0), new Vector3(transform.position.x + 10000, spaceY, 0));
    }

    public override bool CheckCondition()
    {
        if (transform.position.y >= spaceY && SkinManager.Instance.Current.name != skin.name)
        {
            OnConditionMet();
            return true;
        }

        return false;
    }
}
