using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKnife: MonoBehaviour
{
    private Rigidbody rb;
    public Transform transform;

    private bool targetHit;
    public int damage;
    public bool canRotate;
    public float maxLifetime;
    private float tiltAroundZ;
    private float tiltAroundY;
    private float tiltAroundX;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform = transform<Rigidbody>();
        targetHit = false;
    }
    private void Update()
    {
      if (canRotate){
        tiltAroundY +=1;
        tiltAroundX +=1;
        tiltAroundZ +=1;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundX);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
      }

      //Count down lifetime
      maxLifetime -= Time.deltaTime;
      if (maxLifetime <= 0) Delay();
    }
    void OnTriggerEnter(Collider collision) {
      if (collision.gameObject.tag != "Player")
      {
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
            transform.SetParent(collision.transform);
        }

        // make sure projectile sticks to surface
        //rb.isKinematic = true;

        // make sure projectile moves with target
        transform.SetParent(collision.transform);
        //Debug.Log(collision.gameObject.tag);
      }
      else{
        //Debug.Log(collision.gameObject.tag);
      }
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

}
