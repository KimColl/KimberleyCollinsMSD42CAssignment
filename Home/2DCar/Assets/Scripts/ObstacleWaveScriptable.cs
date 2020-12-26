using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Scriptable")]

public class ObstacleWaveScriptable : ScriptableObject
{
    //Obstacle Prefab to spawn
    [SerializeField] GameObject obstaclePrefab;

    //Path Prefab on which to move
    [SerializeField] GameObject pathPrefab;

    //Obstacle movement speed
    [SerializeField] float movementSpeed = 2f;

    //the number of obstacles per wave
    [SerializeField] int numberOfObstacles = 5;

    //time between each obstacle spawn
    [SerializeField] float timeBetweenSpawns = 1f; 

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;


    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWayPoints()
    {
        //wavepoints are a component of tranform
        var waveWaypoints = new List<Transform>();

        //access pathPrefab and for each child you have there
        //add it to the List waveWayPoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
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
