using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <see cref="ScoreController"/> class.
/// </summary>
public class ScoreController : MonoBehaviour
{
    public ScoreObject scoreObject;

    /// <summary>
    /// Adds points to th score
    /// </summary>
    /// <param name="points"></param>
    public void AddScore(int points)
    {
        scoreObject.score += points;
        Debug.Log($"New delivery count: {scoreObject.score}");
    }

    /// <summary>
    /// Subtracts points from the score
    /// </summary>
    /// <param name="points"></param>
    public void SubScore(int points)
    {
        scoreObject.score -= points;
        Debug.Log($"New delivery count: {scoreObject.score}");
    }

    /// <summary>
    /// Clears the score to zero
    /// </summary>
    public void ClearScore()
    {
        scoreObject.score = 0;
        Debug.Log($"New delivery count: {scoreObject.score}");
    }

    /// <summary>
    /// Adds points to th score
    /// </summary>
    /// <param name="points"></param>
    public void AddDelivery(int points)
    {
        scoreObject.deliveries += points;
        Debug.Log($"New delivery count: {scoreObject.deliveries}");
    }

    /// <summary>
    /// Subtracts points from the score
    /// </summary>
    /// <param name="points"></param>
    public void SubDelivery(int points)
    {
        scoreObject.deliveries -= points;
        Debug.Log($"New delivery count: {scoreObject.deliveries}");
    }

    /// <summary>
    /// Clears the score to zero
    /// </summary>
    public void ClearDelivery()
    {
        scoreObject.deliveries = 0;
        Debug.Log($"New delivery count: {scoreObject.deliveries}");
    }

    /// <summary>
    /// Called on application quit
    /// </summary>
    private void OnApplicationQuit()
    {
        ClearScore();
        ClearDelivery();
    }
}
