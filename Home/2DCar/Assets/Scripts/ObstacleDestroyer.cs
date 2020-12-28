using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    //otherObject saves all the information, of the object that triggers ObjectShredderBottom
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //runs when the otherObject collides with the ObstacleDestroyer
        print("Collision with " + otherObject.name);
    }
}
