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
        int numOfSessionPlay = FindObjectsOfType<SessionPlay>().Length;

        if(numOfSessionPlay > 1)
        {
            Destroy(gameObject); //destroy the last game object
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetPoints()
    {
       return points;
    }

    //add p to points
    public void AddingToPoints(int pts)
    {
        points += pts;
    }

    public void RearrangeTheGame()
    {
        Destroy(gameObject); //to destroy the SessionPlay
    }
}
