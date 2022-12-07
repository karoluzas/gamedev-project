using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health = 0f;
    public float flashDuration = 0.1f;
    public GameObject enemyDeathSound;
    public GameObject playerDeathSound;
    public GameObject rockBreakSound;
    private SpriteRenderer sprite;
    private InventoryController inventoryController;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        var player = GameObject.Find("Player");
        if (player)
            inventoryController = player.GetComponent<InventoryController>();
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
            //Hurt Animation/Particles?
        }
        else
        {
            if(gameObject.tag == "Enemy_Sathanas"){
                Instantiate(enemyDeathSound);
                inventoryController.AddDemonBlood(Random.Range(1, 5));
            }
            if(gameObject.tag == "Player"){
                Instantiate(playerDeathSound);
            }
            if(gameObject.tag == "Rock")
            {
                Instantiate(rockBreakSound);
                inventoryController.AddRocks(Random.Range(1, 10), Random.Range(0, 2), Random.Range(0, 4));
            }
            if (gameObject.tag == "Demon Egg")
            {
                Instantiate(rockBreakSound);
                inventoryController.AddBushes(Random.Range(1, 10), Random.Range(0, 2), Random.Range(0, 4));
            }
            if (gameObject.tag == "Demon Altar")
            {
                Instantiate(rockBreakSound);
                inventoryController.AddAltairs(Random.Range(1, 10), Random.Range(0, 2), Random.Range(0, 4));
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
