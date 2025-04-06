using UnityEngine;

public abstract class EnemyState : State
{
    protected GameObject player;
    
    public GameObject Player
    {
        get => player;
        set => player = value;
    }
}
