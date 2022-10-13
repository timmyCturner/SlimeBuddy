using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    //public String type = "basic";
    public enum EnemyType
    {
        Basic,
        Bomb
    }
    public EnemyType selected = EnemyType.Basic;

    public void TakeDamage(int damage)
    {
        //Debug.Log(damage);
        health -= damage;

        if (health <= 0){


          if (selected == EnemyType.Bomb){
            int children = gameObject.transform.childCount;
           for (int i = 0; i < children; ++i){
             GameObject child = transform.GetChild(i).gameObject;
             if (child.name == "Explosion"){

               child.SetActive(true);
             }
             else{
               child.SetActive(false);
             }
           }
               //print("For loop: " + transform.GetChild(i));
            // foreach (Transform child in gameObject.allChildren() ){
            //   if (child.name == "Explosion"){
            //     child.SetActive(true);
            //   }
            //   else{
            //     child.SetActive(false);
            //   }
            // }
            //GameObject explosion = gameObject.transform.Find("Explosion").gameObject;
            //explosion.GetComponent<Detonate>.DetonateSelf();

            Invoke("DestroyEnemy", 3f);
          }
          else
            DestroyEnemy();
        }

    }

    public void DestroyEnemy()
    {

        Destroy(gameObject);
    }
}
