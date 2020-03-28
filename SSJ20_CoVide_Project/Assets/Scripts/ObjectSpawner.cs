using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Sprite[] grassRandom;
    public Sprite sidewalk;
    public Sprite streetMiddle;
    public Sprite[] streetRandom;
    public Sprite streetSide;

    private int streetSideCounter = 0;
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
        lastStreetDrawn = -2 * size - 0.5f;
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
            CreateStreetRow(lastStreetDrawn + size + 0.75f);
            lastStreetDrawn += 0.5f;
        }
    }

    void CreateStreetRow(float posY)
    {
        GameObject go = CreateSingleSprite(streetMiddle);
        go.transform.position = new Vector3(0, posY, -0.1f);
        for (int i = -4; i < 4; i++)
        {
            go = CreateSingleSprite(streetRandom[(int)(Random.value * streetRandom.Length)]);
            go.transform.position = new Vector3(0.5f * i + 0.25f, posY, 0);
        }
        streetSideCounter--;
        if (streetSideCounter < 0)
        {
            go = CreateSingleSprite(streetSide);
            go.transform.position = new Vector3(-1.75f, posY, -0.1f);
            go = CreateSingleSprite(streetSide);
            go.transform.position = new Vector3(1.75f, posY, -0.1f);

            streetSideCounter = 1;
        }
        go = CreateSingleSprite(sidewalk);
        go.transform.position = new Vector3(-2.25f, posY, 0);
        go = CreateSingleSprite(sidewalk);
        go.transform.position = new Vector3(2.25f, posY, 0);
        for(int i = 0; i < 5;i++)
        {
            go = CreateSingleSprite(grassRandom[(int)(Random.value * grassRandom.Length)]);
            go.transform.position = new Vector3(0.5f * i + 2.75f, posY, 0);
            go = CreateSingleSprite(grassRandom[(int)(Random.value * grassRandom.Length)]);
            go.transform.position = new Vector3(-0.5f * i - 2.75f, posY, 0);
        }
    }

    GameObject CreateSingleSprite(Sprite sprite)
    {
        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.sortingLayerName = "Background";
        Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
        return go;
    }
}
