using System.Collections;
using System.Collections.Generic;
using Bonk.StandardLibrary;
using UnityEngine;
using UnityEngine.Events;

public class DistanceTrigger : MonoBehaviour
{
    public UnityEvent OnTrigger;
    
    private float triggerRange;

    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, triggerRange);
        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (hitCollider.TryGetComponent(out Health health))
            {
                OnTrigger.Invoke();
            }
        }
    }

    public void SetTriggerRange(float input)
    {
        triggerRange = input;
    }
}
