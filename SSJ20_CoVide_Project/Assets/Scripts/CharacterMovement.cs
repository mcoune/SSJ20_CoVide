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
    private Collider2D them;

    public float camSpeed=1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 speed = Vector2.up*camSpeed;
        if (Input.GetKey(up) && (them == null || (them.transform.position - transform.position).y < coll.size.y - 0.01f))
        {
            speed += Vector2.up * upSpeed;
        }
        if (Input.GetKey(left) && (them == null || -(them.transform.position - transform.position).x < coll.size.x - 0.01f))
        {
            speed += Vector2.left * horizontalSpeed;
        }
        if (Input.GetKey(down) && (them == null || -(them.transform.position - transform.position).y < coll.size.y - 0.01f))
        {
            speed += Vector2.down * downSpeed;
        }
        if (Input.GetKey(right) && (them == null || (them.transform.position - transform.position).x < coll.size.x - 0.01f))
        {
            speed += Vector2.right * horizontalSpeed;
        }
        print(speed);
        rb.velocity = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            them = collision.collider;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            them = null;
    }
}
