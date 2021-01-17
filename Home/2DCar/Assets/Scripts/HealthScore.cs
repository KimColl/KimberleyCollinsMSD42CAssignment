using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScore : MonoBehaviour
{
    Text carPlayerHealth;  //updates the text of carPlayerPoints in UI

    Player player;

    void Start()
    {
        carPlayerHealth = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        carPlayerHealth.text = player.ObtainHealthPoints().ToString();
    }
}
