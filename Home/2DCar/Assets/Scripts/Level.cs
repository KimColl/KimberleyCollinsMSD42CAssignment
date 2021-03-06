﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//will take care to go from one scene to another
public class Level : MonoBehaviour
{
    [SerializeField] float slowDown = 1.5f;

    [SerializeField] float slowTheGame = 1.5f;

    //when the obstacles dies, then wait 1.5 seconds and then load the scene
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(slowDown); //wait 1.5 seconds
        SceneManager.LoadScene("GameOverScene"); //and then load the GameOverScene
    }

    IEnumerator WaitingUntilWinLoading()
    {
        yield return new WaitForSeconds(slowTheGame); //wait 1.5 seconds
        SceneManager.LoadScene("WinnerScene"); //and then load the GameOverScene
    }

    public void LoadCarGameScene()
    {
        //loads the scene with name Game
        SceneManager.LoadScene("GameScene");
        //to reset the SessionPlay from the start
        SessionPlay sp = FindObjectOfType<SessionPlay>();
        if(sp != null)
        {
            sp.RearrangeTheGame();
        }
    }

    public void LoadGameOverScene()
    {
        //loads the scene with name GameOver
        //SceneManager.LoadScene("GameOverScene");
        StartCoroutine(WaitTime());
    }

    public void LoadWinnerScene()
    {
        StartCoroutine(WaitingUntilWinLoading());
    }

    public void LoadMenuScene()
    {
        //SceneManager reads the scenes which are in unity
        //loads the first scene in the project which is the Menu scene
        SceneManager.LoadScene(0); //it will load the first scene which is the MenuScene because it has an index 0 in the Build Settings
    }

    //this method will only works when the game is running as an exe file
    public void LeaveTheGameScene()
    {
        print("Quit The Game");
        //Quit the Game
        Application.Quit();
    }
}
