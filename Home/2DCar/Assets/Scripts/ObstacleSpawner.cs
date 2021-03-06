﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a list of waves from which to spawn obstacles
public class ObstacleSpawner : MonoBehaviour
{
    //ceate a list of waves of waveConfigList
    [SerializeField] List<ObstacleWave> waveConfigList;

    [SerializeField] bool loop = false;

    int waveStart = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //if loop is unticked that means that it is false and it will loop once
        //if loop is ticked, that means that it is true and it will loop many times
        do
        {
            //starts the coroutine (spawningallthewaves) and it will wait until that coroutine finishes
            //yield return startcoroutine(spawningallthewaves());
            foreach (ObstacleWave nowwave in waveConfigList)
            {
                //wait until the obstacles are spawned before going to the next wave
                yield return StartCoroutine(SpawnAllObstaclesInWave(nowwave));
            }
        }
        while (loop == true); //when this coroutine (spawningallthewaves) finishes, it cheks if it is still looping and it will start all over again


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //coroutine to spawn all obstacles in a wave
    //to specify which obstacles from which wave they are going to spawn
    private IEnumerator SpawnAllObstaclesInWave(ObstacleWave waveConfig) 
    {
        //loop to spawn multiple obstacles in a wave
        for (int obstacleCount = 1; obstacleCount <= waveConfig.GetNumberOfObstacles(); obstacleCount++)
        {
            var obstacle = Instantiate(waveConfig.GetObstaclePrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);

            obstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
        
    }

    //loop all waves
    private IEnumerator SpawningAllTheWaves()
    {
        foreach(ObstacleWave nowWave in waveConfigList)
        {
            //wait until the obstacles are spawned before going to the next wave
            yield return StartCoroutine(SpawnAllObstaclesInWave(nowWave));
        }
    }
}
