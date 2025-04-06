using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    [SerializeField]
    public EnemyState[] states;

    private void Awake()
    {
        GameObject player = (FindObjectOfType(typeof(WormMovement)) as WormMovement).gameObject;

        foreach (var state in states)
        {
            state.Player = player;
        }
    }
}
