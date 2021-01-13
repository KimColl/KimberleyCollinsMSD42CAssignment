using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPoints : MonoBehaviour
{
    //updates the text in UI
    Text showPointsText; //to get the component by myself

    SessionPlay sessionPlay;

    // Start is called before the first frame update
    void Start()
    {
        showPointsText = GetComponent<Text>();
        sessionPlay = FindObjectOfType<SessionPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        //ToString(); is used so that the number of the points can be converted to string
        showPointsText.text = sessionPlay.GetPoints().ToString();
    }
}
