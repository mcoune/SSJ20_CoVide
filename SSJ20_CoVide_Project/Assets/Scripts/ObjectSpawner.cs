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
        obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleTimer < Time.time)
        {
            GameObject obst = GameObject.Instantiate(obstacles[0]);
            obst.transform.position = transform.position + new Vector3(Random.Range(-3, 3), 5.5f, 10);
            obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
        }
    }
}
