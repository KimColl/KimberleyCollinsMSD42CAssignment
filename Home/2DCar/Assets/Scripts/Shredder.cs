using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    //this is an inbuilt method
    //when the laser hits the trigger it gets destroyed
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //print("Collision with " + otherObject.name);
        Destroy(otherObject.gameObject);
    }
}