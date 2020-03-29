using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
            GameObject.Destroy(collision.gameObject);
        if (collision.transform.tag == "FinishLine")
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
