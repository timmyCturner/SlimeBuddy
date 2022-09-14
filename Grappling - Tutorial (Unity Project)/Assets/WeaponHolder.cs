using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public GameObject Saber;
    public bool CanAttack;
    public float AttackCoolDown =1.0f;
    // Start is called before the first frame update
    void Start(){
      CanAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){

            SwordAttack();
          
        }
    }

    public void SwordAttack(){
      CanAttack = false;
      Animator anim = Saber.GetComponent<Animator>();
      anim.SetTrigger("Attack");
      //StartCoroutine(ResetAttackCooldown());
    }

    // IEnumerator ResetAttackCooldown(){
    //
    //   // yeild return new WaitForSeconds(20);
    //   // CanAttack = true;
    //
    // }
}
