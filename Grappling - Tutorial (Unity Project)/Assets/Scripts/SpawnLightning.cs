using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLightning : MonoBehaviour
{
    public List<LightningStrike> LightningStrikeList;
    public Transform grandparent;
    public GameObject parent;

    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
      isAttacking = false;
      DisableStrikes();
    }

    // Update is called once per frame
    void Update()
    {

      //anim.ResetTrigger("attack");
      //animArm.Play(animName);
      if (!isAttacking)
        StartCoroutine(SpawnLightningEnum(Random.Range(0, (LightningStrikeList.Count-1))));
    }
    IEnumerator SpawnLightningEnum(int i){
      //yield return new WaitForSeconds(LightningStrikeList[i].delay);

      LightningStrikeList[i].Lightning.SetActive(true);
      isAttacking = true;
      yield return new WaitForSeconds(LightningStrikeList[i].time);
      DisableStrike(i);
      var rotationVector = grandparent.rotation.eulerAngles;
      rotationVector.y = Random.Range(0, 360);
      grandparent.rotation = Quaternion.Euler(rotationVector);
      yield return new WaitForSeconds(LightningStrikeList[i].delay);
      isAttacking = false;


    }
    void DisableStrikes(){
      for(int i=0;i<LightningStrikeList.Count;i++){
        DisableStrike(i);
      }
    }
    void DisableStrike(int i){
        LightningStrikeList[i].Lightning.SetActive(false);
    }
}

[System.Serializable]

public class LightningStrike{

  public GameObject Lightning;
  public float time;
  public float delay;


}
