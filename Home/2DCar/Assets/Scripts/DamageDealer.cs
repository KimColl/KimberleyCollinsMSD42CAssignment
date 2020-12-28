using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will store all the information about the damage that we want to create 
//this is going to be called when to deal damage
public class DamageDealer : MonoBehaviour
{
    //all damage dealers will deal different damages via Unity
    [SerializeField] int damageWaveBullets = 1;

    //return the amount of damage
    public int GetDamageWaveBullets()
    {
        return damageWaveBullets; //encapsulating our fields
    }

    //this hit method will be called when we want to destroy an object
    //destroys the gameObject
    public void Hit()
    {
        Destroy(gameObject);
    }

}
