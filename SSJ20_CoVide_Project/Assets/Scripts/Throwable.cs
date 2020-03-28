using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public GameObject owner { get; set; }
    public ItemObject item;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    other.CompareTag("");
    //    var player = other.GetComponentInParent<Player>();
    //    var targetArea = other.GetComponentInParent<TargetArea>();
    //    if (player || targetArea)
    //    {
    //        return;
    //    }

    //    Debug.Log("Destroy");
    //    Destroy(gameObject);
    //}
}
