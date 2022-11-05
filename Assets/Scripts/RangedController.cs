using UnityEngine;

public class RangedController : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject bulletPrefab;
    float timeLeft = 0;
    bool canFire = true;

    public float fireCooldown = 0.3f;
    public float bulletForce = 10f;
    public float damageOnHit = 5f;
    public float bulletRange = 1f;

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
        SetBulletRange(bullet);
        SetBulletDamageOnHit(bullet);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void SetBulletRange(GameObject bullet)
    {
        var bulletColissions = bullet.GetComponent<BulletCollisions>();
        bulletColissions.BulletRange = bulletRange;
    }

    private void SetBulletDamageOnHit(GameObject bullet)
    {
        var bulletColissions = bullet.GetComponent<BulletCollisions>();
        bulletColissions.DamageOnHit = damageOnHit;
    }
}