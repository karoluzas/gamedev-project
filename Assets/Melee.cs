using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform slashPoint;
    public GameObject slashPrefab;
    
    float slashCooldown = 0.6f; //Upgradable value
    float timeLeft;
    bool canSlash = true;

    void Update()
    {
        if(timeLeft > 0)
        {
            canSlash = false;
            timeLeft -= Time.deltaTime;
        }
        else
        {
            canSlash = true;
        }
        if(Input.GetButtonDown("Fire2") && canSlash)
        {
            Swing();
            timeLeft = slashCooldown;
        }
        
    }
    void Swing()
    {
        GameObject bullet = Instantiate(slashPrefab, slashPoint.position, slashPoint.rotation * Quaternion.Euler(0, 0, 90));
    }
}
