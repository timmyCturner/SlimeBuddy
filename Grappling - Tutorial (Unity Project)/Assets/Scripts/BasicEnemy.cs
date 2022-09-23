using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int health;

    public void TakeDamage(int damage)
    {
        //Debug.Log(damage);
        health -= damage;

        if (health <= 0){
          DestroyEnemy();
          //Invoke("DestroyEnemy", 0.2f);
        }

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
