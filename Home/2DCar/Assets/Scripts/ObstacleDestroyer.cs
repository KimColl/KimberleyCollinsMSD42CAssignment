using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    //otherObjects saves all the information, of the object that triggers ObjectDestroyerBottom
    private void OnTriggerEnter2D(Collider2D otherObjects)
    {
        //runs when the otherObject collides with the ObstacleDestroyer
        //print("Collision with " + otherObjects.name);
        Destroy(otherObjects.gameObject);
    }
}
