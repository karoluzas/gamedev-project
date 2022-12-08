using System.Collections.Generic;
using UnityEngine;

public class CarryOverScene : MonoBehaviour
{
    private static List<GameObject> objects = new List<GameObject>();

    private void Awake()
    {
        RemoveAdditionalPlayer();
        objects.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void RemoveAdditionalPlayer()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerObjects.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public static void Reset()
    {
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
    }
}
