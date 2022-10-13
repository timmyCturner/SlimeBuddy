using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingWeaponScript : MonoBehaviour
{
    [Header("Animation")]
    private Animation animArm;
    public GameObject arm;
    public string animName;

    [Header("Control")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public LayerMask whatIsEnemies;

    private Rigidbody rb;
    private bool isAttacking;

    //Damage
    
    [Header("Control")]
    public int damage;
    private bool targetHit;
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;
    public bool explodeOnTouch = true;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
      animArm = arm.GetComponent<Animation>();
      rb = GetComponent<Rigidbody>();
      targetHit = false;
      isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(throwKey)&&!isAttacking){
          animArm.Play(animName);
          isAttacking = true;
          //Debug.Log(isAttacking);
          Invoke("IsAttacking", 1.2f);
          //Debug.Log("armDeleage");
      }
    }
    private void Explode()
    {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call Take Damage

            //Just an example!
            enemies[i].GetComponent<BasicEnemy>().TakeDamage(explosionDamage);

            //Add explosion force (if enemy has a rigidbody)
            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        //Add a little delay, just to make sure everything works fine

    }
    private void IsAttacking()
    {
        //Debug.Log("Attack");
        //ResetTrigger();
        isAttacking = false;
    }
    void OnTriggerStay(Collider collision) {
      // Debug.Log("Hit1");
       //Debug.Log(isAttacking);
      if (collision.gameObject.tag != "Player" && isAttacking)
      {

        // check if you hit an enemy
        if(collision.gameObject.GetComponent<BasicEnemy>() != null)
        {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();

            enemy.TakeDamage(damage);
            Explode();

        }

      }


    }



}
