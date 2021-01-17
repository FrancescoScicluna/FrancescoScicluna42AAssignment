using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooter : MonoBehaviour
{
    [SerializeField] float health = 1;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject obstacleLaserPrefab;
    [SerializeField] float obstacleLaserSpeed = 5f;
    [SerializeField] bool shoot;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            ObstacleFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstacleFire()
    {
        if(shoot == true) { 
            GameObject obstacleLaser = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.identity) as GameObject;
            obstacleLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);
        }
    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        if(health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        if(dmgDealer != null)
        {
            ProcessHit(dmgDealer);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
    }
}


