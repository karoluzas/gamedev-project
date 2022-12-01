using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawner : MonoBehaviour
{
    public GameObject materialPrefab;
    public float materialRespawnTime = 1f;
    [SerializeField]
    private float x1, x2;
    [SerializeField]
    private float y1, y2;
    
    void Start()
    {
        StartCoroutine(SpawnMaterial(materialRespawnTime, materialPrefab));
    }

    private IEnumerator SpawnMaterial(float interval, GameObject material){
        //GameObject newEnemy = Instantiate(material, new Vector3(Random.Range(-5f, 1.5f), Random.Range(-2f, 0.4f), 0), Quaternion.identity);
        GameObject newMaterial = Instantiate(material, new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), 0), Quaternion.identity);
        yield return new WaitForSeconds(interval);
        StartCoroutine(SpawnMaterial(interval, material));
    }
}
