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

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public Collider2D them;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 speed = new Vector2();
        bool touchingThem = coll.IsTouching(them);
        if (Input.GetKey(up) && (!touchingThem || (them.transform.position - transform.position).y < coll.size.y - 0.01f))
        {
            speed += Vector2.up * upSpeed;
        }
        if (Input.GetKey(left) && (!touchingThem || -(them.transform.position - transform.position).x < coll.size.x - 0.01f))
        {
            speed += Vector2.left * horizontalSpeed;
        }
        if (Input.GetKey(down) && (!touchingThem || -(them.transform.position - transform.position).y < coll.size.y - 0.01f))
        {
            speed += Vector2.down * downSpeed;
        }
        if (Input.GetKey(right) && (!touchingThem || (them.transform.position - transform.position).x < coll.size.x - 0.01f))
        {
            speed += Vector2.right * horizontalSpeed;
        }
        rb.velocity = speed;
    }
}
