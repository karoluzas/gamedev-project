using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Vector2 mousePosition;
    public Camera sceneCamera;
    public Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
