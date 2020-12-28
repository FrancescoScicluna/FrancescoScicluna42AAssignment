using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the obstacle will spawn in this wave
    [SerializeField] GameObject obstaclePrefab;

    //the path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between each obstacle spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of obstacles in the Waves
    [SerializeField] int numberOfObstacles = 5;

    //The speed of the obstacle
    [SerializeField] float obstacleMoveSpeed = 2f;

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //access pathPrefab and for each child
        //add it to the List waveWayPoints
        foreach (Transform wp in pathPrefab.transform)
        {
            waveWayPoints.Add(wp);
        }
        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }
    
    public float GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
