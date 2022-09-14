using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [Header("References")]
    // Start is called before the first frame update
    public List<GameObject> Weapons;
    private GameObject CurrentWeapon;
    private GameObject PrevWeapon;
    private int WeaponNumber;

    public bool CanAttack;
    public float AttackCoolDown =1.0f;

    void Start()
    {
      //Weapons = new List<GameObject>();
      WeaponNumber = 0;
      CurrentWeapon = Weapons[0];
      CanAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
      //Get Input From The Mouse Wheel
      // if mouse wheel gives a positive value add 1 to WeaponNumber
      // if it gives a negative value decrease WeaponNumber with 1
        if (Input.GetMouseButtonDown(0)){

            SwordAttack();

        }

        if(Input.GetAxis("Mouse ScrollWheel")!=0){
          PrevWeapon = Weapons[WeaponNumber];
          if(Input.GetAxis("Mouse ScrollWheel") > 0){
              WeaponNumber = (WeaponNumber + 1);
              if(WeaponNumber>=Weapons.Count){
                WeaponNumber = 0;
              }
              CurrentWeapon = Weapons[WeaponNumber];
              CurrentWeapon.SetActive(true);
              PrevWeapon.SetActive(false);

          }
          if(Input.GetAxis("Mouse ScrollWheel") < 0){
              WeaponNumber = (WeaponNumber - 1);
              if(WeaponNumber<0){
                WeaponNumber = Weapons.Count-1;
              }
              CurrentWeapon = Weapons[WeaponNumber];
              CurrentWeapon.SetActive(true);
              PrevWeapon.SetActive(false);
          }
        }

    }

    public void SwordAttack(){
      CanAttack = false;
      Animator anim = CurrentWeapon.GetComponent<Animator>();
      anim.SetTrigger("Attack");
      //StartCoroutine(ResetAttackCooldown());
    }
}
