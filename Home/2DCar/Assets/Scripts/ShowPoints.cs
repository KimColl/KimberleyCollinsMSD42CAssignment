using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPoints : MonoBehaviour
{
    SessionPlay sessionPlay;
    Text carPlayerPoints;  //updates the text of carPlayerPoints in UI

    void Start()
    {
        carPlayerPoints = GetComponent<Text>();
        sessionPlay = FindObjectOfType<SessionPlay>();
    }

    private void Update()
    {
        //update the Score in UI with the score
        carPlayerPoints.text = sessionPlay.GetPlayerPoints().ToString();
    }
}
