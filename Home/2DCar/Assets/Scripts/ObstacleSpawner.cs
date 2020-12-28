using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a list of waves from which to spawn enemies
public class ObstacleSpawner : MonoBehaviour
{
    //ceate a list of waves of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    [SerializeField] bool loop = false;

    int waveStart = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //if loop is unticked that means that it is false and it will loop once
        //if loop is ticked, that means that it is true and it will loop many times
        do
        {
            //starts the coroutine (SpawningAllTheWaves) and it will wait until that coroutine finishes
            yield return StartCoroutine(SpawningAllTheWaves());
        }
        while (loop == true); //when this coroutine (SpawningAllTheWaves) finishes, it cheks if it is still looping and it will start all over again
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //coroutine to spawn all obstacles in a wave
    //to specify which obstacles from which wave they are going to spawn
    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveConfig)
    {
        //loop to spawn multiple obstacles in a wave
        for (int obstacleCount = 1; obstacleCount <= waveConfig.GetNumberOfObstacles(); obstacleCount++)
        {
            var obstacle = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);

            obstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
        
    }

    //loop all waves
    private IEnumerator SpawningAllTheWaves()
    {
        foreach(WaveConfig nowWave in waveConfigList)
        {
            //wait until the obstacles are spawned before going to the next wave
            yield return StartCoroutine(SpawnAllObstaclesInWave(nowWave));
        }
    }
}
