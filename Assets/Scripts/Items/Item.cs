using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum ItemType
{
    KEY,
    COIN,
    BULLETS,
    HEALS
}


[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public bool stackble = true;
    public int MaxStack;

    public string name;
    public GameObject prefab;
    public int value;
    public ItemType ItemType;
}
