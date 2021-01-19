using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    //in the list waypoints i saved waypoint 0, waypoint 1, waypoint 2, waypoint 3, , waypoint 4 
    [SerializeField] List<Transform> waypoints; //waypoints is the name of the list

    [SerializeField] ObstacleWave waveConfig;

    //saves the waypoint in which we want to go
    int waypointElement = 0;

    int playerGamePoints = 0;

    [SerializeField] AudioClip playerPointsGained;

    //allows the variable to set from the Inspector between 0 and 1
    //0.70f means 70%
    [SerializeField] [Range(0, 1)] float playerPointsGainedRangeVolume = 0.70f; //[Range(0, 1)] to set the voloume between 0 and 100%

    // Start is called before the first frame update
    void Start()
    {
        //get the List waypoints from WaveConfig
        waypoints = waveConfig.GetWayPoints();

        //set the start position of obstacle to the first waypoint position
        transform.position = waypoints[waypointElement].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMoving(); 
    }

    private void ObstacleMoving() 
    {
        // 0, 1, 2, 3, 4    <=      4
        if (waypointElement <= waypoints.Count - 1)
        {
            //set the positionTarget to the waypoint where we want to go
            var positionTarget = waypoints[waypointElement].transform.position;

            //to make sure that the z -axis is always equal to 0
            positionTarget.z = 0f;

            var obstacleMove = waveConfig.GetObstacleMovementSpeed() * Time.deltaTime; 

            //move obstacle from current position to targetPosition, at obstacleMovement speed
            transform.position = Vector2.MoveTowards(transform.position, positionTarget, obstacleMove); 

            //if obstacle reaches the target position
            if (transform.position == positionTarget)
            {
                waypointElement++;
            }

        }
        //if the obstacle reaches the last waypoint
        else
        {
            Destroy(gameObject);

            playerGamePoints += 5;
            FindObjectOfType<SessionPlay>().AddingToPoints(playerGamePoints);

            AudioSource.PlayClipAtPoint(playerPointsGained, Camera.main.transform.position, playerPointsGainedRangeVolume);
            if (playerGamePoints >= 100)
            {
                Destroy(gameObject);
                //find object of type Level in the Hierarchy and run its method LoadGameOverScene(), if the object is not there it will give me an error
                FindObjectOfType<Level>().LoadWinnerScene();
            }
        }

        
    }

    //set a WaveConfig
    public void SetWaveConfig(ObstacleWave waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }

}
