using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage enemy here once
        Destroy(gameObject);
    }
}
