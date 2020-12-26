using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    [SerializeField] float movementSpeed = 3f;

    int waypointElement = 0; //will be updated with the next waypoint

    // Start is called before the first frame update
    void Start()
    {
        //set the start of the position of every Obstacle to the first waypoint position which is in element 0
        transform.position = waypoints[waypointElement].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        if (waypointElement <= waypoints.Count - 1)
        {
            //set the positionTarget to the waypoint where it want to go
            var positionTarget = waypoints[waypointElement].transform.position;

            positionTarget.z = 0f; //to make sure that the z axis position is always 0, else the positionTarget won't be able to be equal to the waypoint position

            //it will not move to fast or too slow
            var obstacleMove = movementSpeed * Time.deltaTime;

            //move the obstacle from the current position to the position target position, at the obstacleMove
            transform.position = Vector2.MoveTowards(transform.position, positionTarget, obstacleMove);

            //if the obstacle reaches the position target
            if (transform.position == positionTarget)
            {
                waypointElement++; //(waypointElement + 1)
            }

        }

        //if the obstacle reaches the last waypoint
        else
        {
            Destroy(gameObject);
        }
    }
}
