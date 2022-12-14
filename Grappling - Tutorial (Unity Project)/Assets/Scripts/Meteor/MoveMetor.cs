using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMetor : MonoBehaviour
{
    public float speed;
    public GameObject impactPrefab;
    public List<GameObject> trails;
    private Rigidbody rb;

    public int destroyT;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(speed != 0 && rb != null){
          rb.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision){
      speed = 0;

      ContactPoint contact = collision.contacts[0];
      Quaternion rot  = Quaternion.FromToRotation(Vector3.up,contact.normal);
      Vector3 pos = contact.point;
      if (impactPrefab != null){
        var impactVFX = Instantiate(impactPrefab, pos, rot) as GameObject;
        Destroy(impactVFX,destroyT);
      }
      if(trails.Count >0){
        for (int i=0;i<trails.Count;i++){
          trails[i].transform.parent = null;
          var ps = trails[i].GetComponent<ParticleSystem>();
          if(ps != null){
            ps.Stop();
            Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
          }
        }
      }

      Destroy(gameObject);
    }
}
