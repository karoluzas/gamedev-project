using UnityEngine;

public class SlashCollisions : MonoBehaviour
{
    float slashLifetime; 

    void Start()
    {
        slashLifetime = 0.2f;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Damage if(other.gameOjbect.tag == "enemy") here over the time (slashLifetime) it stays on screen
    }
    
    void Update()
    {
        if(slashLifetime > 0)
        {
            slashLifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
