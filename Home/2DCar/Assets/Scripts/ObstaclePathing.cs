using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    //in this list waypoints i saved waypoint 0, waypoint 1, waypoint 2, waypoint 3, , waypoint 4 
    [SerializeField] List<Transform> waypoints; //waypoints is the name of the list

    [SerializeField] WaveConfig waveConfig;

    //saves the waypoint in which we want to go
    int waypointElement = 0;

    // Start is called before the first frame update
    void Start()
    {
        //get the List waypoints from WaveConfig
        waypoints = waveConfig.GetWayPoints();

        //set the start position of Enemy to the first waypoint position
        transform.position = waypoints[waypointElement].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoving();
    }

    private void EnemyMoving()
    {
        // 0, 1, 2, 3, 4    <=      4
        if (waypointElement <= waypoints.Count - 1)
        {
            //set the positionTarget to the waypoint where we want to go
            var positionTarget = waypoints[waypointElement].transform.position;

            //to make sure that the z -axis = 0
            positionTarget.z = 0f;

            var enemyMove = waveConfig.GetObstacleMovementSpeed() * Time.deltaTime;

            //move Enemy from current position to targetPosition, at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, positionTarget, enemyMove);

            //if Enemy reaches the target position
            if (transform.position == positionTarget)
            {
                waypointElement++;
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
