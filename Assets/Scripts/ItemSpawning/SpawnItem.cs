using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [field:SerializeField]
    public float MinDepth {get; private set;}
    
    [field:SerializeField]
    public float MaxDepth {get; private set;}

    [field:SerializeField]
    public int Weight {get; private set; }
}