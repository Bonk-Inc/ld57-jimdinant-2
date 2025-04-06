using UnityEngine;

public class Pickup : MonoBehaviour
{
    [field:SerializeField]
    public PickupType Type {get; private set;}

    [field:SerializeField]
    public int Amount { get; private set; }

    public void Used() {
        Destroy(gameObject);
    }

    public enum PickupType {
        Health,
        Xp
    }
}
