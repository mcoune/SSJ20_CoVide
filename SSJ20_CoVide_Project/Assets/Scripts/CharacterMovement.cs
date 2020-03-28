using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public KeyCode up;
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;

    public float upSpeed = 1f;
    public float downSpeed = 1f;
    public float horizontalSpeed = 1f;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.simulated = true;
        Vector2 speed = new Vector2();
        if (Input.GetKey(up))
        {
            speed += Vector2.up * upSpeed;
        }
        if (Input.GetKey(left))
        {
            speed += Vector2.left * horizontalSpeed;
        }
        if (Input.GetKey(down))
        {
            speed += Vector2.down * downSpeed;
        }
        if (Input.GetKey(right))
        {
            speed += Vector2.right * horizontalSpeed;
        }
        rb.velocity = speed;
        rb.simulated = false;
    }
}
