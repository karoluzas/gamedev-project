using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health = 0f;
    public float flashDuration = 0.1f;
    public GameObject enemyDeathSound;
    public GameObject playerDeathSound;
    public GameObject playerHurtSound;
    public GameObject rockBreakSound;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void DecreaseHealth(float amount)
    {
        if (health > 0)
        {
            health -= amount;
            if (gameObject.tag == "Player" || gameObject.tag == "Enemy_Sathanas")
            {
                StartCoroutine(FlashRed());
            }
            if(gameObject.tag == "Player")
            {
                Instantiate(playerHurtSound);
            }
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
            if(gameObject.tag == "Rock" || gameObject.tag == "Demon Egg" || gameObject.tag == "Demon Altar" ){
                Instantiate(rockBreakSound);
            }
            Destroy(gameObject, 0.1f);
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        sprite.color = Color.white;
    }
}
