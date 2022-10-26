using UnityEngine;

public class BulletCollisions : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO - Damage enemy here once
        if(collision.gameObject.tag == "Player"){
            return;
        }

        Destroy(gameObject);
    }
}
