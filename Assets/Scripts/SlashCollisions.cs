using UnityEngine;

public class SlashCollisions : MonoBehaviour
{
    private float damageOnHit = 5f;
    private float slashLifetime = 0.15f;

    public float DamageOnHit
    {
        set { damageOnHit = value; }
    }

    public float SlashLifetime
    {
        get { return slashLifetime; }
        set { slashLifetime = value; }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy_Sathanas")
        {
            //Destroy(gameObject);
            GameObject enemy = collider.gameObject;
            if (enemy)
            {
                var healthController = enemy.GetComponent<HealthController>();
                healthController.DecreaseHealth(damageOnHit);
            }
        }
        if(collider.tag == "Rock"){
            Destroy(collider.gameObject);
            //TODO - add inventory system so materials can be gathered
        }
    }

    private void Update()
    {
        if (slashLifetime > 0)
        {
            slashLifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
