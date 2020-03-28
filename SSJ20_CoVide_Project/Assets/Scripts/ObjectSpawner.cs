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
            GameObject obst = GameObject.Instantiate(obstacles[(int)(Random.value*obstacles.Length)]);
            obst.GetComponent<MapObject>().Spawn(size + transform.position.y, true);
            obstacleTimer = Time.time + Random.Range(minObstacleTime, maxObstacleTime);
        }
    }
}
