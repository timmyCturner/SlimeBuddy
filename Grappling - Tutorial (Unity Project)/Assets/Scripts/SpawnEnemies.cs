using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject bomber;
    public GameObject skull;
    public GameObject blob;
    public Transform orientation;


    public float bomberInterval = 30f;
    public float skullInterval = 15f;
    public float blobInterval = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(bomberInterval, bomber));
        StartCoroutine(spawnEnemy(skullInterval, skull));
        StartCoroutine(spawnEnemy(blobInterval, blob));
    }

    IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
      yield return new WaitForSeconds(interval);
      GameObject newEnemy = Instantiate(enemy, new Vector3(orientation.position.x,10,orientation.position.z), Quaternion.identity);
      Debug.Log("Spawn");
      StartCoroutine(spawnEnemy(interval,enemy));
    }


}
