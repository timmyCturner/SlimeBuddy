using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCollision : MonoBehaviour
{
    private Rigidbody rb;
    public Transform transform;

    private bool targetHit;
    public int damage = 1;

    private bool active;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform = transform<Rigidbody>();
        targetHit = false;
    }

    void OnTriggerStay(Collider collision) {
      if(active){
        if (collision.gameObject.tag == "Player")
        {

          //Debug.Log("fire");

          if(collision.gameObject.GetComponent<PlayerStatus>() != null)
          {
              //Debug.Log("nil");
              PlayerStatus enemy = collision.gameObject.GetComponent<PlayerStatus>();
              //enemies[i].GetComponent<PlayerStatus>().TakeDamage(explosionDamage);
              enemy.TakeDamage(damage);

          }

        }
        active = false;
        Invoke("Delay", 0.2f);
      }

    }
    private void Delay()
    {
      active = true;
    }

}
