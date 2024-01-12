using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healthPackValue = 5;
    [SerializeField] int health = 100;
    [SerializeField] int citizenAssistValue = 10;
    [SerializeField] int merchantAssistValue = 50;
    [SerializeField] int T2Enemy = 5;
    [SerializeField] int T3Enemy = 10;
    [SerializeField] int Crowdmg = 25;
    [SerializeField] int Seeddmg = 3;
    float timer = 0;
    int minHealth = 0;
    int maxHealth = 100;
    [SerializeField] TextMeshProUGUI myText;

    void Update()
    {
        timer = Time.deltaTime;
        if (health <= minHealth)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("DeathScreen");
        }
        else
        {
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile")
        {
            health -= Seeddmg;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "EnemyT2")
        {
            health -= T2Enemy;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "EnemyT3")
        {
            health -= T3Enemy;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "ChuChu")
        {
            health -= 99;
        }

        if(collision.gameObject.tag == "Pepper")
        {
            health -= 999999999;
            myText.text = "HP" + health;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            health--;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "EnemyT2")
        {
            health -= T2Enemy;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "EnemyT3")
        {
            health -= T3Enemy;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "Crow")
        {
            health -= Crowdmg;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "Trap")
        {
            health--;
            myText.text = "HP" + health;
        }

        if(collision.gameObject.tag == "Healthpack")
        {
            Destroy(collision.gameObject);
            health += healthPackValue;
            myText.text = "HP" + health;
            if (health > maxHealth)
            {
                health = maxHealth;
                myText.text = "HP" + health;
            }
        }

        if(collision.gameObject.tag == "Citizen")
        {
                health += citizenAssistValue;
                myText.text = "HP" + health;
                if (health > maxHealth)
                {
                    health = maxHealth;
                    myText.text = "HP" + health;
                }
        }

        if(collision.gameObject.tag == "Merchant")
        {
                health += merchantAssistValue;
                myText.text = "HP" + health;
                if (health > maxHealth)
                {
                    health = maxHealth;
                    myText.text = "HP" + health;
                }
        }

        if(collision.gameObject.tag == "Pepper")
        {
            Destroy(collision.gameObject);
            health += 100;
            myText.text = "HP" + health;
            
            if (health > maxHealth)
            {
                health = maxHealth;
                myText.text = "HP" + health;
            }
        }
    }
}