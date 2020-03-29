using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public ScoreObject scoreObject1;
    public ScoreObject scoreObject2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }

    }


    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        scoreObject1.score = 0;
        scoreObject1.deliveries = 0;

        scoreObject2.score = 0;
        scoreObject2.deliveries = 0;
        Application.Quit();
    }
}
