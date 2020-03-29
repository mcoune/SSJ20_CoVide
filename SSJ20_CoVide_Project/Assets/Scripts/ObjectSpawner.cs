using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public int houseCounttillFinish = 30;
    private int houseCount = 0;
    public Sprite finishLine;
    private bool finishLineDrawn;

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

    public GameObject[] streetLights;
    private float nextStreetLightToDraw;

    public GameObject[] obstacles;
    private float obstacleTimer;
    public float minObstacleTime = 1;
    public float maxObstacleTime = 3;

    public GameObject[] pickups;
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
        nextStreetLightToDraw = -2 * size;

        while (transform.position.y - nextHouseLeftToDraw >= 0)
        {
            GameObject go = GameObject.Instantiate(housesLeft[(int)(Random.value * housesLeft.Length)]);
            go.GetComponent<MapObject>().Spawn(size + nextHouseLeftToDraw, false);
            nextHouseLeftToDraw += go.GetComponent<MapObject>().height;
        }
        while (transform.position.y - nextHouseRightToDraw >= 0)
        {
            GameObject go = GameObject.Instantiate(housesRight[(int)(Random.value * housesRight.Length)]);
            go.GetComponent<MapObject>().Spawn(size + nextHouseRightToDraw, false);
            nextHouseRightToDraw += go.GetComponent<MapObject>().height;
        }
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
            houseCount++;
            if (houseCount < houseCounttillFinish && Random.value < 1 / 3f)
                go.GetComponent<TargetController>().EnableScoreing(true);
        }
        while (transform.position.y - nextHouseRightToDraw >= 0)
        {
            go = GameObject.Instantiate(housesRight[(int)(Random.value * housesRight.Length)]);
            go.GetComponent<MapObject>().Spawn(size + nextHouseRightToDraw, false);
            nextHouseRightToDraw += go.GetComponent<MapObject>().height;
            houseCount++;
            if (houseCount < houseCounttillFinish && Random.value < 1 / 3f)
                go.GetComponent<TargetController>().EnableScoreing(true);
        }
        while (transform.position.y - nextStreetLightToDraw >= 0)
        {
            go = GameObject.Instantiate(streetLights[0]);
            go.GetComponent<MapObject>().Spawn(size + transform.position.y, true);
            go = GameObject.Instantiate(streetLights[1]);
            go.GetComponent<MapObject>().Spawn(size + transform.position.y, true);

            nextStreetLightToDraw += 10f;
        }
        if (obstacleTimer < Time.time)
        {
            go = GameObject.Instantiate(obstacles[(int)(Random.value * obstacles.Length)]);
            go.GetComponent<MapObject>().Spawn(size + transform.position.y, true);
            obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
        }
        if (pickupTimer < Time.time)
        {
            go = GameObject.Instantiate(pickups[(int)(Random.value * pickups.Length)]);
            go.transform.position = new Vector3(Mathf.Round(32 * Random.Range(-2, 2)) / 32f, Mathf.Round(32 * (transform.position.y + 16 / 2f)) / 32f, 0);
            pickupTimer = Time.time + Random.Range(minPickupTime, maxPickupTime);
        }

        if (!finishLineDrawn && houseCount >= houseCounttillFinish)
        {
            for (int i = -5; i < 5; i++)
            {
                go = CreateSingleSprite(finishLine);
                go.transform.position = new Vector3(0.5f * i + 0.25f, Mathf.Round(4 * (transform.position.y + size + 0.75f)) / 4f, -0.2f);
                if (!finishLineDrawn)
                    go.transform.tag = "FinishLine";
                go = CreateSingleSprite(finishLine);
                go.transform.position = new Vector3(0.5f * i + 0.25f, Mathf.Round(4 * (transform.position.y + size + 1.25f)) / 4f, -0.2f);
                finishLineDrawn = true;
            }
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
