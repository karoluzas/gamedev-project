using UnityEngine;
using Pathfinding;

public class BelphegorAI : MonoBehaviour
{
    public Transform target;

    public float acceleration = 1f;
    public float maxSpeed = 1f;
    public float nextWaypointDistance = 3f;

    public float detectionRange = 0.8f;

    public float waitTime = 0.5f;
    public float chargeSpeed = 3f;

    private float timeLeft;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private bool canCharge = false;

    private Seeker seeker;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        timeLeft = waitTime;

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    private void UpdatePath()
    {
        if (seeker.IsDone() && !InRange())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    //inrange, 0.8s, charge, 
    private void Update()
    {
        if(InRange())
        {
            if(timeLeft < 0f)
            {
                canCharge = true;
                timeLeft = waitTime;
            }
            else
            {
                timeLeft -= Time.deltaTime;
            }

            if(canCharge)
            {
                Charge();
                canCharge = false;
            }

        }
        else
        {
            timeLeft = waitTime;
        }
    }

    private void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count || InRange())
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

    private bool InRange()
    {
        if (Vector2.Distance(rb.position, target.position) <= detectionRange)
        {
            return true;
        }
        else return false;



    }

    private void Charge()
    {
        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        Vector2 chargeForce = direction * chargeSpeed;

        rb.AddForce(chargeForce, ForceMode2D.Impulse);

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed * chargeSpeed);
    }
}
