using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSlash : MonoBehaviour
{
  [Header("Animation")]
  private Animation animArm;
  public GameObject arm;
  public string animName;

  [Header("Control")]
  public KeyCode swingKey = KeyCode.Mouse0;
  public LayerMask whatIsEnemies;
  public List<Slash> slashes;

  private Rigidbody rb;
  private bool isAttacking;
  private bool targetHit;

  //Damage
  //Damage is broken continuously hits targets
  [Header("Control")]
  public int damage;
    // Start is called before the first frame update
    void Start()
    {
      DisableSlashes();
      isAttacking = false;
      animArm = arm.GetComponent<Animation>();
      rb = GetComponent<Rigidbody>();
      targetHit = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(swingKey)&&!isAttacking){
        isAttacking = true;
        //anim.ResetTrigger("attack");
        animArm.Play(animName);
        StartCoroutine(SlashAttack());
      }
    }
    IEnumerator SlashAttack(){
      for(int i=0;i<slashes.Count;i++){
        yield return new WaitForSeconds(slashes[i].delay);
        slashes[i].slashObj.SetActive(true);
      }
      yield return new WaitForSeconds(1);
      DisableSlashes();
      isAttacking = false;

    }
    void DisableSlashes(){
      for(int i=0;i<slashes.Count;i++){
        slashes[i].slashObj.SetActive(false);
      }
    }
    void OnTriggerStay(Collider collision) {
       //Debug.Log("HitSword");

      if (collision.gameObject.tag != "Player" && isAttacking)
      {
        // check if you hit an enemy
        if(collision.gameObject.GetComponent<BasicEnemy>() != null)
        {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();
            enemy.TakeDamage(damage);
        }
      }
    }
}


[System.Serializable]

public class Slash{
  public GameObject slashObj;
  public float delay;
}
