using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")] 

public class ObstacleWave : ScriptableObject //it is sort of like creating an asset from a script
{
    //the obstacle that will spawn in this wave
    [SerializeField] GameObject obstaclePrefab;

    //the path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    //the speed of the obstacle
    [SerializeField] float obstacleMovementSpeed = 2f;

    //the number of obstacles in the wave
    [SerializeField] int numberOfObstacles = 5;

    //time between each obstacle spawn
    [SerializeField] float timeBetweenSpawns = 1.5f; 

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    
    //encapsulation
    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWayPoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //access pathPrefab and for each child you have there
        //add it to the List waveWayPoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

    public float GetObstacleMovementSpeed()
    {
        return obstacleMovementSpeed;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
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
