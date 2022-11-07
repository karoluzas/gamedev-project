using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SathanasAI : MonoBehaviour
{

    public Transform target;
    public GameObject bulletPrefab;

    public float acceleration = 1f;
    public float maxSpeed = 1f;
    
    public float nextWaypointDistance = 3f;
    public float detectionRange = 1f;
    
    public float bulletForce = 4f;
    public float rateOfFire = 1f;

    float timeLeft = 0f;
    bool canFire;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

     
    Seeker seeker;
    Rigidbody2D rb;
    GameObject aim;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        aim = this.transform.Find("Aim").gameObject;

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && !InShootingRange())
            seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        if (InShootingRange())
        {
            if (timeLeft < 0f)
            {
                canFire = true;
                timeLeft = rateOfFire;
            }
            else
            {
                timeLeft -= Time.deltaTime;
            }

            if (canFire)
            {
                Fire();
                canFire = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(path == null)
            return;
        
        if(currentWaypoint >= path.vectorPath.Count || InShootingRange())
        {
            reachedEndOfPath = true;
            return;
        }
        else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * acceleration * Time.deltaTime;

        rb.AddForce(force);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            ++currentWaypoint;
        }
    }

    bool InShootingRange()
    {
        if (Vector2.Distance(rb.position, target.position) <= detectionRange)
        {
            return true;
        }
        else return false;
    }
    
    void Fire()
    {
        Vector2 direction = ((Vector2)target.position - rb.position).normalized;

        aim.transform.localPosition = new Vector3(0.2f * direction.x, 0.2f * direction.y);

        var angle = Vector2.SignedAngle(Vector2.right, direction);
        var targetRotation = new Vector3(0, 0, angle);
        var lookTo = Quaternion.Euler(targetRotation);

        GameObject bullet = Instantiate(bulletPrefab, aim.transform.position, lookTo * Quaternion.Euler(0, 0, 90));

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }
}
