using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public float height;
    public float leftSpawnBorder;
    public float rightSpawnBorder;

    public void Spawn(float camOffset, bool isObstacle)
    {
        transform.position = new Vector3(Random.Range(leftSpawnBorder, rightSpawnBorder), camOffset + height / 2f, 0);
        if (isObstacle)
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;
            gameObject.AddComponent<BoxCollider2D>();
        }
    }
}
