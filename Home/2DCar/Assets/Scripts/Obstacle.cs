using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the obstacles will be destroyes
//the script will consists the health of the obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] float shot;

    [SerializeField] float minimumTimeBetweenShots = 0.1f;

    [SerializeField] float maximumTimeBetweenShots = 3f;

    [SerializeField] GameObject obstacleFirePrefab;

    [SerializeField] float objectFireBulletSpeed = 0.3f;

    [SerializeField] int valuePoints;

    [SerializeField] float obstacleHealth = 5f;

    [SerializeField] GameObject explosionParticle;

    [SerializeField] float explosionParticlesTime = 1f;

    //0,1 means 0% or 100%
    [SerializeField] [Range(0, 1)] float obstacleSoundEffect = 0.75f;

    [SerializeField] AudioClip obstacleSound;

    

    //reduces health whenever collides with a gameObject
    //which has a DamageDealer component
    public void OnTriggerEnter2D(Collider2D objects)
    {
        DamageDealer damageDealerObstacle = objects.gameObject.GetComponent<DamageDealer>();

        CollideWith(damageDealerObstacle);
    }

    //to send the DamageDealer details
    public void CollideWith(DamageDealer damageDealers)
    {
        obstacleHealth -= damageDealers.GetDamageWaveBullets();

        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(obstacleSound, Camera.main.transform.position, obstacleSoundEffect);

        WhenObstacleDie();

    }

    private void WhenObstacleDie()
    {
        //destroy the obstacle
        Destroy(gameObject);

        //instantiate explosion effects
        GameObject obstacleExplode = Instantiate(explosionParticle, transform.position, Quaternion.identity);

        //destroy after 0.5 seconds
        Destroy(obstacleExplode, explosionParticlesTime);

        AudioSource.PlayClipAtPoint(obstacleSound, Camera.main.transform.position, obstacleSoundEffect);

    }

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

    //the below lines of code till the end will take care of the obstacle, when the obstacle fires a bullet  
    private void ShootingAndCountingdown()
    {
        //every frame start reducing the generate number by the time it subtracts the time by the time unity calculates itself for every frame
        shot -= Time.deltaTime; //start counting downwards
        
        if(shot <= 0f) 
        {
            ObstacleFireBullets();

            //counting down the shot between each obstacle
            //reset shot
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
