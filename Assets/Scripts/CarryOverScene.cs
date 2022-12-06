using System.Collections.Generic;
using UnityEngine;

public class CarryOverScene : MonoBehaviour
{
    private static List<GameObject> objects = new List<GameObject>();

    private void Awake()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerObjects.Length > 1)
        {
            Destroy(gameObject);
        }
        objects.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public static void Reset()
    {
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
    }
}
