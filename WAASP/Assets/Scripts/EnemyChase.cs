using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float chaseSpeed = 2.0f;
	private bool home = true;
	private Vector3 homePos;

	private Vector2 moveDirection;

	public float maxMoveDistance = 10.0f;
	public float chaseTriggerDistance = 1.0f;

	void Start () {
		homePos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		float distanceToPlayer = 0.0f;
		Vector3 playerPosition = target.transform.position;
		moveDirection = new Vector2 (playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
		distanceToPlayer = moveDirection.magnitude;


        if (distanceToPlayer < chaseTriggerDistance)
        {
            moveDirection.Normalize();
            home = false;
            GetComponent<Rigidbody2D>().velocity = moveDirection * chaseSpeed;
        }
	}
}
