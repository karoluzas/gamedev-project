using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    //public Transform target;
    private GameObject player;
    public float acceleration = 1f;
    public float maxSpeed = 1f;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");

        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, player.transform.position, OnPathComplete);

    }

    private void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, player.transform.position, OnPathComplete);       
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if(path == null)
            return;
        
        if(currentWaypoint >= path.vectorPath.Count)
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
}
