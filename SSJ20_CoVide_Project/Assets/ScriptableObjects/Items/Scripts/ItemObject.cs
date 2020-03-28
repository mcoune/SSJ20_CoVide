using System;
using UnityEngine;

/// <summary>
/// Abstract class for <see cref="ItemObject"/>.
/// </summary>
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
}
