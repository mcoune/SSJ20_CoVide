using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public ScoreObject scoreObject1;
    public ScoreObject scoreObject2;
    [SerializeField] private int  sceneToOpen ;

    void Update()
    {
        if (transform.name == "WinScreen" )
        {
            transform.GetChild(0).Find("Player1Score").GetComponent<Text>().text = scoreObject1.score + "";
            transform.GetChild(0).Find("Player2Score").GetComponent<Text>().text = scoreObject2.score + "";
            transform.GetChild(0).Find("TotalScore").GetComponent<Text>().text = (scoreObject1.score + scoreObject2.score) + "";
        }

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
        SceneManager.LoadScene(sceneToOpen);
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
