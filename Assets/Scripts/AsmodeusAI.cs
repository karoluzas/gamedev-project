using UnityEngine;
using Pathfinding;

public class AsmodeusAI : MonoBehaviour
{
    //public Transform target;
    private GameObject player;
    public GameObject bulletPrefab;

    public float acceleration = 1f;
    public float maxSpeed = 1f;

    public float detectionRange = 1.25f;
    public float nextWaypointDistance = 3f;
    
    public float bulletForce = 4f;
    public float rateOfFire = 1f;

    private float angle = 0f;

    [SerializeField]
    private float angleBetweenBullets = 10f;

    private float timeLeft = 0f;
    private bool canFire;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;


    private Seeker seeker;
    private Rigidbody2D rb;
    private GameObject aim;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        aim = this.transform.Find("Aim").gameObject;

        player = GameObject.FindWithTag("Player");
        
        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, player.transform.position, OnPathComplete);
    }

    private void UpdatePath()
    {
        if (seeker.IsDone() && Vector2.Distance(rb.position, player.transform.position) > detectionRange)
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
    private void FixedUpdate()
    {

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count || Vector2.Distance(rb.position, player.transform.position) < detectionRange)
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

    private bool InShootingRange()
    {
        if (Vector2.Distance(rb.position, player.transform.position) <= detectionRange)
        {
            return true;
        }
        else return false;
    }

    private void Fire()
    {
        for(int i = 0; i <= 2; ++i)
        {
            float bulDirX = aim.transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = aim.transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, aim.transform.position, aim.transform.rotation);

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
