using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class WaveConfig : ScriptableObject //it is sort of like creating an asset from a script
{
    //the enmey that will spawn in this wave
    [SerializeField] GameObject enemyPrefab;

    //the path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    //the speed of the enemy
    [SerializeField] float enemyMoveSpeed = 2f;

    //the number of enemiesin the wave
    [SerializeField] int numberOfEnemies = 5;

    //time between each enemy spawn
    [SerializeField] float timeBetweenSpawns = 0.5f; //half a second

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    
    //encapsulation
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
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

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
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
