using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPoints : MonoBehaviour
{
    Text carPlayerPoints;  //updates the text of carPlayerPoints in UI

    SessionPlay sessionPlay;

    void Start()
    {
        carPlayerPoints = GetComponent<Text>();
        sessionPlay = FindObjectOfType<SessionPlay>();
    }

    private void Update()
    {
        carPlayerPoints.text = sessionPlay.GetPlayerPoints().ToString();
    }
}
