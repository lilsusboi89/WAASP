using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] AudioClip attackSound;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] bool mouseShoot = true;
    [SerializeField] bool joystickShoot = false;
    public FixedJoystick joystick1;
    [SerializeField] float timeToFire = 0.7f;
    [SerializeField] float DestructionTimer = 0.29f;
    [SerializeField] TMPro.TextMeshProUGUI ammoText;
    private int ammoAmmount;
    float timer = 0;
    float x = 1;
    float y = 0;
    void Start()
    {
        ammoAmmount = 10;


    }

    void Update()
    {
        

        timer += Time.deltaTime;
        ammoText.SetText(ammoAmmount);


        if (mouseShoot)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 shootDirection = mousePosition - transform.position;
            shootDirection.z = 0;
            shootDirection.Normalize();
            x = shootDirection.x;
            y = shootDirection.y;
        }
        else
        {
            Vector3 shootDirection = joystick1.Direction;
            shootDirection.z = 0;
            shootDirection.Normalize();
            x = shootDirection.x;
            y = shootDirection.y;
            /*
            float tempX = Input.GetAxisRaw("Horizontal");
            float tempY = Input.GetAxisRaw("Vertical");
            if (tempX != 0 || tempY != 0)
            {
                x = tempX;
                y = tempY;
            }*/
        }

        if (joystick1.Direction.magnitude > 0 && timer >= timeToFire && ammoAmmount > 0)
        {
            if(Time.deltaTime == 0)
            {
                return;
            }

            else 
            {
                GameObject Bullet = Instantiate(prefab, transform.position, Quaternion.identity);
                Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * bulletSpeed;
                Destroy(Bullet, DestructionTimer);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(attackSound);
                ammoAmmount -= 1;
                Debug.Log("Pew!");
                timer = 0;
            }
        } 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
