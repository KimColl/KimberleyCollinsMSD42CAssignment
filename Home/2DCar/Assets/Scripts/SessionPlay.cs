using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to make sure that only one game is running
public class SessionPlay : MonoBehaviour
{
    int playerPoints = 0;

    void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        //if there is more than 1 SessionPlay,
        //destroy the last one that was created
        if(FindObjectsOfType<SessionPlay>().Length > 1)
        {
            Destroy(gameObject); //destroy the last game object
        }
        else
        {
            //protect the SessionPlay with DontDestroyOnLoad when changing the scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    //return the points
    public int GetPlayerPoints()
    {
       return playerPoints;
    }

    //add pts to points
    public void AddingToPoints(int pts)
    {
        playerPoints += pts;
    }

    //destroys the current SessionPlay
    public void RearrangeTheGame()
    {
        Destroy(gameObject); //to destroy the SessionPlay
    }
}
