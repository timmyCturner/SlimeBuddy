using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // make sure only to stick to the first target you hit
          //Debug.Log("Stick");
          if (targetHit)
              return;
          else
              targetHit = true;

          // check if you hit an enemy
          if(collision.gameObject.GetComponent<BasicEnemy>() != null)
          {
              BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();

              enemy.TakeDamage(damage);

              Debug.Log("Hit");
              // destroy projectile
              //Destroy(gameObject);
              //rb.isKinematic = true;
          }

          // make sure projectile sticks to surface
          rb.isKinematic = false;

          // make sure projectile moves with target
          transform.SetParent(collision.transform);

        }

}
