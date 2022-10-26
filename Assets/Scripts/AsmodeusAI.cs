using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AsmodeusAI : MonoBehaviour
{

    public Transform target;
    public GameObject bulletPrefab;

    public float acceleration = 1f;
    public float maxSpeed = 1f;

    public float detectionRange = 1.25f;
    public float nextWaypointDistance = 3f;
    
    public float bulletForce = 4f;
    public float rateOfFire = 1f;

    float angle = 0f;

    [SerializeField]
    private float angleBetweenBullets = 10f;

    float timeLeft = 0f;
    bool canFire;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;


    Seeker seeker;
    Rigidbody2D rb;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && Vector2.Distance(rb.position, target.position) > detectionRange)
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
            
            if(canFire)
            {
                Fire();
                canFire = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count || Vector2.Distance(rb.position, target.position) < detectionRange)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * acceleration * Time.deltaTime;

        rb.AddForce(force);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
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
        for(int i = 0; i <= 1; ++i)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.localPosition, transform.localRotation);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            //bulletRb.velocity = bulDir * bulletForce;
            bulletRb.AddForce(bulDir * bulletForce, ForceMode2D.Impulse);
        }

        angle += angleBetweenBullets;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
