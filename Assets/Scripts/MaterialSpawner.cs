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
        GameObject newMaterial = Instantiate(material, new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), 0), Quaternion.identity);
        yield return new WaitForSeconds(interval);
        StartCoroutine(SpawnMaterial(interval, material));
    }
}
