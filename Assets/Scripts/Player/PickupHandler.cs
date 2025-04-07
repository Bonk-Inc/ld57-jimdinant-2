using System;
using Bonk.StandardLibrary;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    private const string PICKUP_TAG = "Pickup";
    private const int HealthRatio = 1000;

    [SerializeField]
    private PlayerLevel levelSystem;

    [SerializeField]
    private Health healthSystem;

    [SerializeField] private float healthRegenRatio = 1;

    public void SetHealthRegen(float ratio)
    {
        healthRegenRatio = ratio;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag(PICKUP_TAG))
            return;
        
        if(!collision.TryGetComponent<Pickup>(out var pickup))
            throw new Exception("Entered pickup without pickup component >:(");

        HandlePickup(pickup);
        pickup.Used();
    }

    private void HandlePickup(Pickup pickup){
        switch (pickup.Type)
        {
            case Pickup.PickupType.Health:
                healthSystem.Heal(Mathf.RoundToInt(pickup.Amount * healthRegenRatio * HealthRatio));
                break;
            
            case Pickup.PickupType.Xp:
                levelSystem.AddXp(pickup.Amount);
                break;
            
            default:
                Debug.LogWarning($"Unknown pickup type {pickup.Type}");
                break;
        }
    }
}
