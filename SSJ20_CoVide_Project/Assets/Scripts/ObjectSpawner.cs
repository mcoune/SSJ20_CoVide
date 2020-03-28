using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    public GameObject[] obstacles;
    public GameObject[] road;
    public GameObject[] houses;

    private float obstacleTimer;
    public float minObstacleTime = 1;
    public float maxObstacleTime = 10;


    // Start is called before the first frame update
    void Start()
    {
        obstacleTimer = Random.Range(minObstacleTime, maxObstacleTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleTimer < 0)
        {

            obstacleTimer = Random.Range(minObstacleTime, maxObstacleTime);
        }
    }
}
