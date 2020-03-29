using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        ActivateMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                DeactivateMenu();
            }
            else
            {
                ActivateMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            DeactivateMenu();
        }
    }



    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        isPaused = true;

    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
