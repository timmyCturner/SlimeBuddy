using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject vfx;
    public Transform startPoint;
    public Transform endPoint;

    public Transform grandparent;
    public float delay;
    public float time;
    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;



    }

    void Update()
    {

      //anim.ResetTrigger("attack");
      //animArm.Play(animName);
      if (!isAttacking)
        StartCoroutine(SpawnMeteorEnum());
    }

    IEnumerator SpawnMeteorEnum(){
      //yield return new WaitForSeconds(LightningStrikeList[i].delay);

      var startPos = startPoint.position;
      GameObject objVFX = Instantiate(vfx,startPos, Quaternion.identity) as GameObject;
      var endPos = endPoint.position;
      RotateTo(objVFX, endPos);
      isAttacking = true;
      yield return new WaitForSeconds(time);
      //DisableStrike(i);
      var rotationVector = grandparent.rotation.eulerAngles;
      rotationVector.y = Random.Range(0, 360);
      grandparent.rotation = Quaternion.Euler(rotationVector);
      yield return new WaitForSeconds(delay);
      isAttacking = false;
    }

    void RotateTo(GameObject obj, Vector3 destination){
      var direction = destination - obj.transform.position;
      var rotation = Quaternion.LookRotation(direction);
      obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

}
