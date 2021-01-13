using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScore : MonoBehaviour
{
    Player player;
    Text healthWords;
    Slider changingHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthWords = GetComponent<Text>();
        player = FindObjectOfType<Player>();
        changingHealth = FindObjectOfType<Slider>();
        changingHealth.maxValue = player.ObtainHealthPoints();
    }

    // Update is called once per frame
    void Update()
    {
        //update the health in UI with the points
        healthWords.text = player.ObtainHealthPoints().ToString();

        //update the slider with the 2DCar player health
        changingHealth.value = player.ObtainHealthPoints();
    }
}
