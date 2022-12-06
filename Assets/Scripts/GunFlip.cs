using UnityEngine;

public class GunFlip : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.eulerAngles.z < 89 || transform.eulerAngles.z > 269)
        {
            sprite.flipY = false;
        }
        else
        {
            sprite.flipY = true;
        }
    }
}
