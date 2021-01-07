using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float shot;

    [SerializeField] float minimumTimeBetweenShots = 0.1f;

    [SerializeField] float maximumTimeBetweenShots = 3f;

    [SerializeField] GameObject obstacleFirePrefab;

    [SerializeField] float objectFireBulletSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        //Random.Range will generate a random number between 0.1 and 3 
        shot = Random.Range(minimumTimeBetweenShots, maximumTimeBetweenShots); 
    }

    // Update is called once per frame
    void Update()
    {
        ShootingAndCountingdown();
    }

    private void ShootingAndCountingdown()
    {
        //every frame start reducing the generate number by the time it subtracts the time by the time unity calculates itself for every frame
        shot -= Time.deltaTime; //start counting downwards
        
        if(shot <= 0f) 
        {
            ObstacleFireBullets();

            //counting down the shot between each obstacle
            shot = Random.Range(minimumTimeBetweenShots, maximumTimeBetweenShots);
        }
    }

    private void ObstacleFireBullets()
    {
        //spawn an obstacleLasersBullets at obstacle position 
        GameObject obstacleLasersBullets = Instantiate(obstacleFirePrefab, transform.position, Quaternion.identity) as GameObject;

        // -objectFireBulletSpeed because the bullet will move downwards
        obstacleLasersBullets.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -objectFireBulletSpeed);
    }
}
