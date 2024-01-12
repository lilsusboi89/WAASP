using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] bool allowKeyControls = true;
    [Tooltip("True if the game is top down, false if it is a platformer")]
    [SerializeField] bool isTopDown = true;
    Collider2D playerCollider;
    [SerializeField] float jumpForce = 20.0f;
    [SerializeField] Canvas mobileCanvas;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>(); 
        if(allowKeyControls )
        {
            mobileCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2 (0, 0);
        if (allowKeyControls)
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;
        }
        if (isTopDown)
        {
            rb2d.velocity = new Vector3(move.x * moveSpeed, move.y * moveSpeed, 0);
        }
        else
        {
            rb2d.velocity = new Vector3(move.x * moveSpeed, rb2d.velocity.y, 0);
        }

    }
    public void Jump()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !isTopDown)
        {
            rb2d.AddForce(new Vector2(0, 20*jumpForce));
        }
    }



}
