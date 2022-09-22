using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject bomber;
    public Transform orientation;


    private float bomberInterval = 30f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(bomberInterval, bomber));
    }

    IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
      yield return new WaitForSeconds(interval);
      GameObject newEnemy = Instantiate(enemy, new Vector3(orientation.position.x,10,orientation.position.z), Quaternion.identity);
      Debug.Log("Spawn");
      StartCoroutine(spawnEnemy(interval,enemy));
    }


}
