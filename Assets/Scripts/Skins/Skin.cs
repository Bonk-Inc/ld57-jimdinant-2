using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Worm Skin", menuName = "Worm/Skin")]
public class Skin : ScriptableObject
{
    [SerializeField]
    private string skinName;

    [SerializeField]
    private Sprite head, body, tail;

    public string Name => skinName;

    public Sprite Head => head;
    public Sprite Body => body;
    public Sprite Tail => tail;
}
