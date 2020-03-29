using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <see cref="ResourcesContainerObject"/> class.
/// </summary>
[CreateAssetMenu(fileName = "ResourceContainer", menuName = "Resources/Container")]
public class ResourcesContainerObject : ScriptableObject
{
    public List<ItemObject> resourceContainer;
}