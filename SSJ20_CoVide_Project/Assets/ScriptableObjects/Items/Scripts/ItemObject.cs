using System;
using UnityEngine;

/// <summary>
/// Abstract class for <see cref="ItemObject"/>.
/// </summary>
public abstract class ItemObject : ScriptableObject
{
    public Sprite sprite;
    public ItemType type;    
}
