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
    private float nextStreetToDraw;

    public GameObject[] housesLeft;
    private float nextHouseLeftToDraw;

    public GameObject[] housesRight;
    private float nextHouseRightToDraw;

    public GameObject[] obstacles;
    private float obstacleTimer;
    public float minObstacleTime = 1;
    public float maxObstacleTime = 3;

    public GameObject[] pickup;
    private float pickupTimer;
    public float minPickupTime = 1;
    public float maxPickupTime = 3;

    float size;

    // Start is called before the first frame update
    void Start()
    {
        obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
        size = GetComponent<Camera>().orthographicSize;
        nextStreetToDraw = -2 * size;
        nextHouseLeftToDraw = -2 * size;
        nextHouseRightToDraw = -2 * size;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go;
        while (transform.position.y - nextStreetToDraw >= 0)
        {
            CreateStreetRow(nextStreetToDraw + size + 0.25f);
            nextStreetToDraw += 0.5f;
        }
        while (transform.position.y - nextHouseLeftToDraw >= 0)
        {
            go = GameObject.Instantiate(housesLeft[(int)(Random.value * housesLeft.Length)]);
            go.GetComponent<MapObject>().Spawn(size + nextHouseLeftToDraw, false);
            nextHouseLeftToDraw += go.GetComponent<MapObject>().height;
        }
        while (transform.position.y - nextHouseRightToDraw >= 0)
        {
            go = GameObject.Instantiate(housesRight[(int)(Random.value * housesRight.Length)]);
            go.GetComponent<MapObject>().Spawn(size + nextHouseRightToDraw, false);
            nextHouseRightToDraw += go.GetComponent<MapObject>().height;
        }
        if (obstacleTimer < Time.time)
        {
            go = GameObject.Instantiate(obstacles[(int)(Random.value * obstacles.Length)]);
            go.GetComponent<MapObject>().Spawn(size + transform.position.y, true);
            obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
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
        for (int i = 0; i < 5; i++)
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
