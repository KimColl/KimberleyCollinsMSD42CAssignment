using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //in this list waypoints i sved waypoint 0, waypoint 1, waypoint 2 
    [SerializeField] List<Transform> waypoints; //waypoints is the name of the list

    [SerializeField] WaveConfig waveConfig;

    //saves the waypoint in which we want to go
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //get the List waypoints from WaveConfig
        waypoints = waveConfig.GetWayPoints();

        //set the start position of Enemy to the first waypoint position
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        // 0, 1, 2         <=      2
        if (waypointIndex <= waypoints.Count - 1)
        {
            //set the targetPosition to the waypoint where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            //to make sure that the z -axis = 0
            targetPosition.z = 0f;

            var enemyMovemnet = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            //move Enemy from current position to targetPosition, at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovemnet);

            //if Enemy reaches the target position
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }
        //if the enemy reaches the last waypoint
        else
        {
            Destroy(gameObject);
        }
    }

    //set a WaveConfig
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }

}
