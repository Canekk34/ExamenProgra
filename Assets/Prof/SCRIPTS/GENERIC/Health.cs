using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int actualHealth;
    public int maxHealth;

    public void TakeDamage(int damage)
    {
        actualHealth -= damage;

        if(actualHealth <= 0)
        {
            Death();
        }

    }

    public void Death()
    {
        Destroy(gameObject);
    }


}

