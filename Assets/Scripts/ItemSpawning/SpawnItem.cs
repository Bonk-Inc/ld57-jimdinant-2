using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [field:SerializeField]
    public float MinDepth {get; private set;}
    
    [field:SerializeField]
    public float MaxDepth {get; private set;}

    [field:SerializeField]
    public int Weight {get; private set; }

    [SerializeField]
    private float maxDistanceToPlayer = 100;
    [SerializeField]
    private bool despawnOutOfRange = true;
    private Transform player;

    public void SetPlayer(Transform transform) {
        player = transform;
    }

    void Update()
    {
        if(!despawnOutOfRange)
            return;

        if (player is null)
        {
            Destroy(gameObject);
            return;
        }
        
        var distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer > maxDistanceToPlayer)
            Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        if(!despawnOutOfRange)
            return;
        Gizmos.DrawWireSphere(transform.position, maxDistanceToPlayer);
    }
}