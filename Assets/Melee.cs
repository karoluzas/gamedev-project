using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform slashPoint;
    public GameObject slashPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Swing();
        }
        
    }
    void Swing()
    {
        GameObject bullet = Instantiate(slashPrefab, slashPoint.position, slashPoint.rotation * Quaternion.Euler(0, 0, 90));
    }
}
