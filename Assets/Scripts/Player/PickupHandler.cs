using System;
using Bonk.StandardLibrary;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{

    private const string PICKUP_TAG = "Pickup";

    [SerializeField]
    private PlayerLevel levelSystem;

    [SerializeField]
    private Health healthSystem;

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
                healthSystem.Heal(pickup.Amount);
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
