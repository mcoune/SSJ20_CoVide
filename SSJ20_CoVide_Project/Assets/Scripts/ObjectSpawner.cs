using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Sprite[] grassRandom;
    public Sprite sidewalk;
    public Sprite streetMiddle;
    public Sprite[] streetRandom;
    public Sprite[] streetAlternating;

    private int streetAlternatingCounter = 0;
    private float lastStreetDrawn;


    public GameObject[] obstacles;
    public GameObject[] houses;

    private float obstacleTimer;
    public float minObstacleTime = 1;
    public float maxObstacleTime = 3;

    float size;

    // Start is called before the first frame update
    void Start()
    {
        obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
        size = GetComponent<Camera>().orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleTimer < Time.time)
        {
            GameObject obst = GameObject.Instantiate(obstacles[(int)(Random.value * obstacles.Length)]);
            obst.GetComponent<MapObject>().Spawn(size + transform.position.y, true);
            obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
        }
        while (transform.position.y - lastStreetDrawn >= 0.5f)
        {
            CreateStreetRow(lastStreetDrawn+size+0.75f);
            lastStreetDrawn += 0.5f;
        }
    }

    void CreateStreetRow(float posY)
    {
        GameObject go;
        for (int i = -3; i < 3; i++)
        {
            go = CreateSingleSprite(streetRandom[(int)(Random.value * streetRandom.Length)], 0);
            go.transform.position = new Vector3(0.5f * i + 0.25f, posY, 0);
        }
    }

    GameObject CreateSingleSprite(Sprite sprite, int orderInLayer)
    {
        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.sortingLayerName = "Background";
        sr.sortingOrder = orderInLayer;
        Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
        return go;
    }
}
