using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject mammonPrefab;
    [SerializeField]
    private GameObject sathanasPrefab;
    [SerializeField]
    private GameObject asmodeusPrefab;
    [SerializeField]
    private GameObject belphegorPrefab;
    
    [SerializeField]
    private float mammonInterval = 3.5f;
    [SerializeField]
    private float sathanasInterval = 4f;
    [SerializeField]
    private float asmodeusInterval = 20f;
    [SerializeField]
    private float belphegorInterval = 12f;
    [SerializeField]
    private float x1, x2;
    [SerializeField]
    private float y1, y2;
    
    
    void Start()
    {
        StartCoroutine(SpawnEnemy(mammonInterval,mammonPrefab));
        StartCoroutine(SpawnEnemy(sathanasInterval, sathanasPrefab));
        StartCoroutine(SpawnEnemy(asmodeusInterval, asmodeusPrefab));
        StartCoroutine(SpawnEnemy(belphegorInterval, belphegorPrefab));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        //GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 1.5f), Random.Range(-2f, 0.4f), 0), Quaternion.identity);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), 0), Quaternion.identity);
        
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
}