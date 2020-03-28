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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            transform.position += Vector3.up * upSpeed;
        }
        if (Input.GetKey(left))
        {
            transform.position += Vector3.left * horizontalSpeed;
        }
        if (Input.GetKey(down))
        {
            transform.position += Vector3.down * downSpeed;
        }
        if (Input.GetKey(right))
        {
            transform.position += Vector3.right * horizontalSpeed;
        }
    }
}
