using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the obstacles will be destroyes
//the script will consists the health of the obstacle
public class ObstacleNoBullets : MonoBehaviour
{
    [SerializeField] float shot;

    [SerializeField] float minimumTimeBetweenShots = 0.1f;

    [SerializeField] float maximumTimeBetweenShots = 3f;

    [SerializeField] int valuePoints = 5;

    [SerializeField] float obstacleHealth = 5f;

    [SerializeField] GameObject explosionParticle;

    [SerializeField] float explosionParticlesTime = 0.5f;

    //reduces health whenever collides with a gameObject
    //which has a DamageDealer component
    private void OnTriggerEnter2D(Collider2D objects)
    {
        DamageDealer damageDealerObstacle = objects.gameObject.GetComponent<DamageDealer>();
        //if there is no damageDealerObstacle in objects, end the method
        if (damageDealerObstacle == null)
        {
            return;
        }

    }

    //to send the DamageDealer details
    private void collideWith(DamageDealer damageDealerObstacle)
    {
        obstacleHealth -= damageDealerObstacle.GetDamageWaveBullets();
        damageDealerObstacle.Hit();
        if (obstacleHealth <= 0)
        {
            destroyObstcale();
        }
    }

    private void destroyObstcale()
    {
        //destroy the obstacle
        Destroy(gameObject);

        //instantiate explosion effects
        GameObject explosionObstacle = Instantiate(explosionParticle, transform.position, Quaternion.identity);

        //destroy after 0.5 seconds
        Destroy(explosionObstacle, explosionParticlesTime);

        //add pts to SessionPlay points
        FindObjectOfType<SessionPlay>().AddingToPoints(valuePoints);
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
           
    }
}

