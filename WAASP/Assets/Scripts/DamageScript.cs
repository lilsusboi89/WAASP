using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] int bulletDamage = 1;
    public int GetPlayerDamage()
    {
        return bulletDamage;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
