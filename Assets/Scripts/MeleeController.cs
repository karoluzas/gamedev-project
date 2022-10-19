using UnityEngine;

public class MeleeController : MonoBehaviour
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
        GameObject slash = Instantiate(slashPrefab, slashPoint.position, slashPoint.rotation * Quaternion.Euler(0, 0, 90));
    }
}
