using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a list of waves from which to spawn enemies
public class ObstacleSpawner : MonoBehaviour
{
    //ceate a list of waves of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    int waveStart = 0;

    // Start is called before the first frame update
    void Start()
    {
        var latestWave = waveConfigList[waveStart];

        //spawns all obstacles in latestWave
        StartCoroutine(SpawningAllTheWaves());
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
        for (int obstacleCount = 1; obstacleCount <= waveConfig.GetNumberOfEnemies(); obstacleCount++)
        {
            var obstacle = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);

            obstacle.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
        
    }

    private IEnumerator SpawningAllTheWaves()
    {
        foreach(WaveConfig nowWave in waveConfigList)
        {
            //wait until the obstacles are spawned
            yield return StartCoroutine(SpawnAllObstaclesInWave(nowWave));
        }
    }
}
