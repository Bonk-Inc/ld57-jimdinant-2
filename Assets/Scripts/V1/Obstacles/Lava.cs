using Bonk.StandardLibrary;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float damageRadius = 15, damageRate = 3;
    
    [SerializeField] private int impactDamage = 5000;
    
    private void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);
        foreach (var hitCollider in hitColliders)
        {
            float distance = Vector3.Distance(hitCollider.transform.position, transform.position);
            if (distance < damageRadius && hitCollider.TryGetComponent(out Health health))
            {
                // DamageFeedback.Instance.FireDamage();
                health.Damage(Mathf.CeilToInt(damageRate * Time.deltaTime * (1 - distance / damageRadius)));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.Damage(impactDamage);
        }
    }
}
