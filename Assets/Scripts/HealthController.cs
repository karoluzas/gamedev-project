using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health = 0f;
    public GameObject enemyDeathSound;
    public GameObject playerDeathSound;
    public GameObject rockBreakSound;

    public void DecreaseHealth(float amount)
    {
        if (health > 0)
        {
            health -= amount;
            Debug.Log("Health: " + health);
            //Hurt Animation/Particles?
        }
        else
        {
            if(gameObject.tag == "Enemy_Sathanas"){
                Instantiate(enemyDeathSound);
            }
            if(gameObject.tag == "Player"){
                Instantiate(playerDeathSound);
            }
            if(gameObject.tag == "Rock"){
                Instantiate(rockBreakSound);
            }
            Destroy(gameObject);
        }
    }
}
