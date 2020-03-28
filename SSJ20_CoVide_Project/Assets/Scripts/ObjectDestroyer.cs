using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player")
            GameObject.Destroy(collision.gameObject);
    }
}
