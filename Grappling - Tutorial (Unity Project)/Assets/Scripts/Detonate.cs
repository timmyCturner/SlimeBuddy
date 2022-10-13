using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonate : MonoBehaviour
{
    public GameObject Bomb;
    public float power = 10f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Bomb.activeSelf){
          //DetonateSelf();
          Invoke("DetonateSelf", 0);
        }

    }

    void DetonateSelf(){
      Vector3 explosionPosition = Bomb.transform.position;
      Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
      foreach(Collider hit in colliders){
        Rigidbody rb = hit.GetComponent<Rigidbody>();
        if (rb!=null){
          rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
        }
      }
    }
}
