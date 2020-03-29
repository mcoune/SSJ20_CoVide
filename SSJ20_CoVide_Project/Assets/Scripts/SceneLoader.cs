using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public ScoreObject scoreObject1;
    public ScoreObject scoreObject2;


    public void LoadScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
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
