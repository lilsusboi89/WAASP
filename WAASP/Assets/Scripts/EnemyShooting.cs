using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float timeToFire = 1;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletLifetime = 2;
    float timer = 0;
    [SerializeField] float shootDistance = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 playerPosition = player.transform.position;
        Vector3 shootDirection = playerPosition - transform.position;
        if(shootDirection.magnitude < shootDistance && timer >= timeToFire)
        {
            timer = 0;
            shootDirection.Normalize();
            GameObject enemyBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            enemyBullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(enemyBullet, bulletLifetime);
        }
    }
}
