using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The <see cref="ScoreController"/> class.
/// </summary>
public class ScoreController : MonoBehaviour
{
    public ScoreObject scoreObject;
    public bool isGroupScore;
    public int maxStrikes;

    public void Awake()
    {
        ClearDelivery();
        ClearScore();
    }

    void Update()
    {
        if(isGroupScore && scoreObject.strikes >= maxStrikes)
        {
            SceneManager.LoadScene("GameOverScene");
        }
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
    /// Adds points to th Delivery
    /// </summary>
    /// <param name="points"></param>
    public void AddDelivery(int points)
    {
        scoreObject.deliveries += points;
    }

    /// <summary>
    /// Subtracts points from the Delivery
    /// </summary>
    /// <param name="points"></param>
    public void SubDelivery(int points)
    {
        scoreObject.deliveries -= points;
    }

    /// <summary>
    /// Clears the score to Delivery
    /// </summary>
    public void ClearDelivery()
    {
        scoreObject.deliveries = 0;
    }

    /// <summary>
    /// Adds points to the Strike
    /// </summary>
    /// <param name="points"></param>
    public void AddStrike(int points)
    {
        scoreObject.strikes += points;
    }

    /// <summary>
    /// Subtracts points from the Strike
    /// </summary>
    /// <param name="points"></param>
    public void SubStrike(int points)
    {
        scoreObject.strikes -= points;
    }

    /// <summary>
    /// Clears the Strike to zero
    /// </summary>
    public void ClearStrike()
    {
        scoreObject.strikes = 0;
    }
}
