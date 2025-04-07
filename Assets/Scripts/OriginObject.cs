using UnityEngine;
using UnityEngine.Events;

public class OriginObject : MonoBehaviour
{
    public UnityEvent OriginReset;
    
    public void ResetOrigin(Vector2 origin)
    {
        transform.position = origin;
        OriginReset?.Invoke();
    }
        
        
}
