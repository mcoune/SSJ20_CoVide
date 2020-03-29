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
        transform.position = new Vector3(Mathf.Round(32 * Random.Range(leftSpawnBorder, rightSpawnBorder)) / 32f, Mathf.Round(32 * (camOffset + height / 2f)) / 32f, 0);

        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        BoxCollider2D bc = gameObject.AddComponent<BoxCollider2D>();
        bc.isTrigger = !isObstacle;
    }
}
