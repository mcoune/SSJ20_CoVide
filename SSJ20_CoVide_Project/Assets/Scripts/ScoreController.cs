using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <see cref="ScoreController"/> class.
/// </summary>
public class ScoreController : MonoBehaviour
{
    public ScoreObject scoreObject;

    public void Awake()
    {
        ClearDelivery();
        ClearScore();
    }
    /// <summary>
    /// Adds points to th score
    /// </summary>
    /// <param name="points"></param>
    public void AddScore(int points)
    {
        scoreObject.score += points;
    }

    /// <summary>
    /// Subtracts points from the score
    /// </summary>
    /// <param name="points"></param>
    public void SubScore(int points)
    {
        scoreObject.score -= points;
    }

    /// <summary>
    /// Clears the score to zero
    /// </summary>
    public void ClearScore()
    {
        scoreObject.score = 0;
    }

    /// <summary>
    /// Adds points to th score
    /// </summary>
    /// <param name="points"></param>
    public void AddDelivery(int points)
    {
        scoreObject.deliveries += points;
    }

    /// <summary>
    /// Subtracts points from the score
    /// </summary>
    /// <param name="points"></param>
    public void SubDelivery(int points)
    {
        scoreObject.deliveries -= points;
    }

    /// <summary>
    /// Clears the score to zero
    /// </summary>
    public void ClearDelivery()
    {
        scoreObject.deliveries = 0;
    }
}
