using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [Header("References")]
    // Start is called before the first frame update
    public List<GameObject> Weapons;
    public GameObject Arm;
    private GameObject CurrentWeapon;
    private GameObject PrevWeapon;
    private int WeaponNumber;

    private bool growArm;

    public bool CanAttack;
    public float AttackCoolDown =1.0f;

    private Animation anim;


    void Start()
    {
      //Weapons = new List<GameObject>();
      WeaponNumber = 0;
      CurrentWeapon = Weapons[0];
      CanAttack = false;
      growArm = true;

    }

    // Update is called once per frame
    void Update()
    {

        //Get Input From The Mouse Wheel
        // if mouse wheel gives a positive value add 1 to WeaponNumber
        // if it gives a negative value decrease WeaponNumber with 1
          // if (Input.GetMouseButtonDown(0)){
          //
          //     SwordAttack();
          //
          // }

          if(Input.GetAxis("Mouse ScrollWheel")!=0){
            if (growArm){
              growArm = false;
              anim = Arm.GetComponent<Animation>();
              //Debug.Log(anim);
              Arm.SetActive(true);
              anim.Play("growArm");
            }
            else{
              PrevWeapon = Weapons[WeaponNumber];
              if(Input.GetAxis("Mouse ScrollWheel") > 0){
                  WeaponNumber = (WeaponNumber + 1);
                  if(WeaponNumber>=Weapons.Count){
                    WeaponNumber = 0;
                  }
                  ScrollHelperSetWeapon();

              }
              if(Input.GetAxis("Mouse ScrollWheel") < 0){
                  WeaponNumber = (WeaponNumber - 1);
                  if(WeaponNumber<0){
                    WeaponNumber = Weapons.Count-1;
                  }
                  ScrollHelperSetWeapon();
              }
            }
        }
    }
    public void ScrollHelperSetWeapon(){
      CurrentWeapon = Weapons[WeaponNumber];
      CurrentWeapon.SetActive(true);
      PrevWeapon.SetActive(false);
      anim = CurrentWeapon.GetComponent<Animation>();
      anim.Play("Grow");
    }

    public void SwordAttack(){
      //CanAttack = false;
      anim = Arm.GetComponent<Animation>();
      anim.Play("SwingDown");
      // Animator anim = CurrentWeapon.GetComponent<Animator>();
      //anim.SetTrigger("Attack");
      //StartCoroutine(ResetAttackCooldown());
    }
}
