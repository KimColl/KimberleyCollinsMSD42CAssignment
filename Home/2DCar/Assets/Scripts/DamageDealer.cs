using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will store all the information about the damage that we want to create 
//this is going to be called when to deal damage
public class DamageDealer : MonoBehaviour
{
    //all damage dealers playerLaser, enemyLaser and the enemyLaser will deal the same amount of damage
    [SerializeField] int damage = 100;

    //return the amount of damage
    public int GetDamage()
    {
        return damage; //encapsulating our fields
    }

    //this hit will be called when we want to destroy an object
    //destroys the gameObject
    public void Hit()
    {
        Destroy(gameObject);
    }

}
