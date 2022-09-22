using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGameObject: MonoBehaviour
{
    void OnTriggerEnter(Collider collision) {
      if (collision.gameObject.tag == "Enemy")
      {
          //If the GameObject has the same tag as specified, output this message in the console
          Debug.Log("Enemy Hit");
      }
      else{
        Debug.Log(collision.gameObject.tag);
      }
    }
    //Detect collisions between the GameObjects with Colliders attached

}
