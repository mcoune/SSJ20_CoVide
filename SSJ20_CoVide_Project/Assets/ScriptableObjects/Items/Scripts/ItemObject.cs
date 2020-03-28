using System;
using UnityEngine;

/// <summary>
/// Abstract class for <see cref="ItemObject"/>.
/// </summary>
public abstract class ItemObject : ScriptableObject
{
    public GameObject throwablePrefab;
    public GameObject collectablePrefab;
    public ItemType type;    
}
