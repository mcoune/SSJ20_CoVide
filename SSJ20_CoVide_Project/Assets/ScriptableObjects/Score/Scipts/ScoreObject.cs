using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <see cref="ScoreObject"/> class.
/// </summary>
[CreateAssetMenu(fileName = "New Score", menuName = "Score")]
public class ScoreObject : ScriptableObject
{
    public int score;
}
