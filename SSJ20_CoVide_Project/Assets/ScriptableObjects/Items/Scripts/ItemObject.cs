using System;
using UnityEngine;

/// <summary>
/// Abstract class for <see cref="ItemObject"/>.
/// </summary>
public abstract class ItemObject : ScriptableObject
{
    public int points = 1;
    public int penaltiy = 1;
    public GameObject throwablePrefab;
    public GameObject collectablePrefab;
    public ItemType type;    
}
