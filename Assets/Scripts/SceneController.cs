using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private float timer = 60f;
    [SerializeField]
    private int damageTimer = 5;
    private GameObject player;
    private HealthController healthController;
    private bool takingDamage = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (player)
        {
            healthController = player.GetComponent<HealthController>();
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            if(!takingDamage)
            {
                StartCoroutine(TakeDamage(damageTimer));
            }
        }
    }

    private IEnumerator TakeDamage(int duration)
    {
        healthController.DecreaseHealth(1);
        takingDamage = true;
        yield return new WaitForSeconds(duration);
        takingDamage = false;
    }
}
