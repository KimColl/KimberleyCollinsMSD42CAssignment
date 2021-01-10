using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPlayMusic : MonoBehaviour
{
    //the first method that unity runs, before the start method
    private void Awake()
    {
        SetUpTheBackgroundMusic();
    }

    //create the first background music player and destroy it immediately
    private void SetUpTheBackgroundMusic()
    {
        //two background music player
        //if you find more than one object of type BackgroundPlayMusic
        //that is why .Length > 1 because of FindObjects
        //FindObjectsOfType returns an array of objects
        //GetType(): gets the type of Object that is attached to the script BackgroundPlayMusic 
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            //if there is more than BackgroundPlayMusic, 
            Destroy(gameObject); //destroy the last one created
        }
        else
        {
            //it will protect the game obects which is the BackgroundPlayMusic and it won't be destroyed when changing from one scene to anther
            //a protection will be added to every scene
            //do not destroy the BackgroundPlayMusic when changing the scenes
            //do not destroy the old BackgroundPlayMusic when changing the scenes, keep it there
            //if it is the first scene it will only contains one object which is .Length = 1 
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
