using UnityEngine;

public class RangedController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    float fireCooldown = 0.3f; //Upgradable value
    float timeLeft = 0;
    bool canFire = true;

    public float bulletForce = 10f;

    void Update()
    {  
        if(timeLeft > 0)
        {
            canFire = false;
            timeLeft -= Time.deltaTime;
        }
        else
        {
            canFire = true;
        }
        if(Input.GetButtonDown("Fire1") && canFire)
        {
            Shoot();
            timeLeft = fireCooldown;
        }
        
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}