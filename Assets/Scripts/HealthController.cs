using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health = 0f;

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
            Destroy(gameObject);
        }
    }
}
