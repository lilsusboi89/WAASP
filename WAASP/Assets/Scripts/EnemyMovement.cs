using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float chaseDistance = 2.0f;
    [SerializeField] float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 moveDirection = playerPosition - transform.position; 
        //if the player is close
        if(moveDirection.magnitude < chaseDistance)
        {
            moveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;
        }
        //if the player is too far away
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
