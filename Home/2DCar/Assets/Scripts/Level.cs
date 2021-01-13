using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//will take care to go from one scene to another
public class Level : MonoBehaviour
{
    [SerializeField] float slowDown = 1.5f;

    //when the obstacles dies, then wait 1.5 seconds and then load the scene
    IEnumerator WaitingUntilLoading()
    {
        yield return new WaitForSeconds(slowDown); //wait 1.5 seconds
        SceneManager.LoadScene("GameOverScene"); //and then load the GameOverScene
    }

    public void LoadMenuScene()
    {
        //SceneManager reads the scenes which are in unity
        //loads the first scene in the project which is the Menu scene
        SceneManager.LoadScene(0); //it will load the first scene which is the MenuScene because it has an index 0 in the Build Settings
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
        StartCoroutine(WaitingUntilLoading());
    }

    public void LoadWinnerScene()
    {
        //loads the scene with name WinnerScene
        SceneManager.LoadScene("WinnerScene");
        //to reset the SessionPlay from the start
        SessionPlay s = FindObjectOfType<SessionPlay>();
        if (s != null)
        {
            s.RearrangeTheGame();
        }
    }

    //this method will only works when the game is running as an exe file
    public void LeaveTheGameScene()
    {
        //Quit the Game
        print("Quit The Game");
        Application.Quit();
    }
}
