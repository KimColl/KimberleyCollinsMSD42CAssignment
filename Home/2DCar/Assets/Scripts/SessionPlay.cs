using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to make sure that only one game is running
public class SessionPlay : MonoBehaviour
{
    int points = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        //if there is more than 1 SessionPlay,
        //destroy the last one that was created
        int numOfSessionPlay = FindObjectsOfType<SessionPlay>().Length;

        if(numOfSessionPlay > 1) //get the type of the BackgroundPlayMusic script
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
    public int GetPoints()
    {
       return points;
    }

    //add pts to points
    public void AddingToPoints(int pts)
    {
        points += pts;
    }

    //destroys the current SessionPlay
    public void RearrangeTheGame()
    {
        Destroy(gameObject); //to destroy the SessionPlay
    }
}
