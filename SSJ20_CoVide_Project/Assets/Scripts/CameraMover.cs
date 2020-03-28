using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public float speed = 2.3f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject[] players=GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
            p.GetComponent<CharacterMovement>().camSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed;
    }
}
