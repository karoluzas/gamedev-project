using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject materialPrefab;
    public float materialRespawnTime = 1f;

    
    void Start()
    {
        StartCoroutine(SpawnEnemy(materialRespawnTime, materialPrefab));
       
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 1.5f), Random.Range(-2f, 0.4f), 0), Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
}
