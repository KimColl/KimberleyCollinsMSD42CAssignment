using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To move the 2D Player Car to the left and right on the x-axis
public class Player : MonoBehaviour
{
    //variables that can be edited from Unity
    [SerializeField] float moveSpeed = 0.02f;

    [SerializeField] float padding = 0.7f;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        SettingBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //to setup the boundaries according to the camera, so the car does not overlap the camera
    private void SettingBoundaries()
    {
        Camera gameCamera = Camera.main;

        //These are the minimum and maximum position of the camera
        //xMin = 0, xMax = 1, yMin = 0, yMax = 1;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    //to be able to move the Car player
    private void Move()
    {
        // deltaX will contains the difference in which the Player moves
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;

        //clamp this position newXPos between 0 and 1 on the camera view and not below or more than 0 or 1
        //clamp the position between 0 and 1 and update the new position
        //clamps the newXPos between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        this.transform.position = new Vector2(newXPos, transform.position.y);
    }
}
