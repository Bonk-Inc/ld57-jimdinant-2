using System.Collections;
using System.Collections.Generic;
using Bonk.StandardLibrary;
using UnityEngine;
using UnityEngine.UI;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private float triggerRange, triggerDelay, explosionRange, explosionDamage;
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Sprite triggeredMine;
    [SerializeField]
    private SpriteRenderer mineImage;

    void Start()
    {
        DistanceTrigger dt = GetComponent<DistanceTrigger>();
        dt.SetTriggerRange(triggerRange);
        dt.OnTrigger.AddListener(StartTimer);
    }

    private void StartTimer()
    {
        mineImage.sprite = triggeredMine;
        timer.StartTimer(triggerDelay);
    }

    public void Explode()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRange);
        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (distance < explosionRange && hitCollider.TryGetComponent(out Health health))
            {
                health.Damage(Mathf.RoundToInt(explosionDamage * (1 - distance / explosionRange)));
            }
        }
        Destroy(gameObject);
    }
}
