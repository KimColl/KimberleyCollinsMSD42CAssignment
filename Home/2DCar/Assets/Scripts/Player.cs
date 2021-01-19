using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To move the 2D Player Car to the left and right on the x-axis
public class Player : MonoBehaviour
{
    //variables that can be edited from Unity
    [SerializeField] float moveSpeed = 1.0f;

    [SerializeField] float padding = 0.7f;

    [SerializeField] AudioClip playerHealthReduction;

    //allows the variable to set from the Inspector between 0 and 1
    //0.70f means 70%
    [SerializeField] [Range(0, 1)] float playerHealthReductionRangeVolume = 0.70f; //[Range(0, 1)] to set the voloume between 0 and 100%

    [SerializeField] int playerHealthPoints = 50;

    float xMin, xMax, yMin, yMax;

    [SerializeField] GameObject explosionParticle;

    [SerializeField] float explosionParticlesTime = 1f;

    int playerGamePoints;

    // Start is called before the first frame update
    void Start()
    {
        SettingBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //calling Move() method from update
    } 

    public int ObtainHealthPoints()
    {
        return playerHealthPoints;
    }

    //reduces health when the carPlayer collides with a game/object which has a DamageDealer class component
    public void OnTriggerEnter2D(Collider2D objects)
    {
        DamageDealer dealDamage = objects.gameObject.GetComponent<DamageDealer>();

        //if objects does not contain dealDamage, end the method
        if(dealDamage == null)
        {
            return;
        }

        HitPlayer(dealDamage);
    }

    //when HitPlayer() is called, send the DamageDealer details
    //when the player gets hit by the obstacles, destroy the player
    private void HitPlayer(DamageDealer dealDamage)
    {
        playerHealthPoints -= dealDamage.GetDamageWaveBullets();

        dealDamage.Hit();        

        AudioSource.PlayClipAtPoint(playerHealthReduction, Camera.main.transform.position, playerHealthReductionRangeVolume);

        When2D_CarPlayerDie();

        AudioSource.PlayClipAtPoint(playerHealthReduction, Camera.main.transform.position, playerHealthReductionRangeVolume);

    }

    //when the player has 0 or less health and less than 100 points, destroy then player with an explosion
    private void When2D_CarPlayerDie()
    {
        if ((playerHealthPoints <= 0) && (playerGamePoints < 100))
        {
            Destroy(gameObject);
            GameObject playerExplode = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(playerExplode, explosionParticlesTime);
            AudioSource.PlayClipAtPoint(playerHealthReduction, Camera.main.transform.position, playerHealthReductionRangeVolume);
            //find object of type Level in the Hierarchy and run its method LoadGameOverScene(), if the object is not there it will give me an error
            FindObjectOfType<Level>().LoadGameOverScene();
        }           
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
        //deltaX means difference x
        //deltaX will contains the difference in which the Player moves
        //Time.deltaTime it will slow the computer down
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //transform position of my player
        //newXPos = current x-position + difference in x
        var newXPos = transform.position.x + deltaX;

        //clamp this position newXPos between 0 and 1 on the camera view and not below or more than 0 or 1
        //clamp the position between 0 and 1 and update the new position
        //clamps the newXPos between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //move the car Player to the newXPos
        //update the position of the 2D Car Player
        this.transform.position = new Vector2(newXPos, transform.position.y);

    }
}
