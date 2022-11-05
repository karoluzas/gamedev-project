using UnityEngine;

public class MeleeController : MonoBehaviour
{
    public Transform slashPoint;
    public GameObject slashPrefab;
    float timeLeft;
    bool canSlash = true;

    public float slashCooldown = 0.6f;
    public float slashSize = 1f;
    public float damageOnHit = 5f;
    public float slashSpeed = 1f;

    void Update()
    {
        if(timeLeft > 0)
        {
            canSlash = false;
            timeLeft -= Time.deltaTime;
        }
        else
        {
            canSlash = true;
        }
        if(Input.GetButtonDown("Fire2") && canSlash)
        {
            Swing();
            timeLeft = slashCooldown;
        }
        
    }

    void Swing()
    {
        GameObject slash = Instantiate(slashPrefab, slashPoint.position, slashPoint.rotation * Quaternion.Euler(0, 0, 90));
        SetSlashDamageOnHit(slash);
        SetSlashSize(slash);
        SetSlashSpeed(slash);
    }

    private void SetSlashSpeed(GameObject slash)
    {
        var animator = slash.GetComponentInChildren<Animator>();
        animator.SetFloat("slashSpeed", slashSpeed);
        var slashCollisions = slash.GetComponent<SlashCollisions>();
        slashCollisions.SlashLifetime /= slashSpeed;
    }

    private void SetSlashDamageOnHit(GameObject slash)
    {
        var slashCollisions = slash.GetComponent<SlashCollisions>();
        slashCollisions.DamageOnHit = damageOnHit;
    }

    private void SetSlashSize(GameObject slash)
    {
        Vector3 currentScale = slash.transform.localScale;
        currentScale.x *= slashSize;
        currentScale.y *= slashSize;
        currentScale.z *= slashSize;
        slash.transform.localScale = currentScale;
    }
}
