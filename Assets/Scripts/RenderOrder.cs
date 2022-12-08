using System;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{
    private void Update()
    {
        float objectPositionOnYAxis = gameObject.transform.position.y;
        GetComponent<Renderer>().sortingOrder = -1 * (int)Math.Round(objectPositionOnYAxis * 100);
    }
}
