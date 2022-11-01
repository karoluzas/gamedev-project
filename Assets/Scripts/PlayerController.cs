using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    bool facingRight = true;
    public Transform aimTransform;
    private Vector3 mousePosition;
    public Camera sceneCamera;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        // Gun aiming rotation
        if (!MenuController.IsGamePaused)
        {
            mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);
    }

    void FixedUpdate(){
        // Player movement
        float movementHorizontal = Input.GetAxisRaw("Horizontal");
        float movementVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(movementHorizontal, movementVertical).normalized;
        rb.velocity = movement * moveSpeed;

        if(movementHorizontal > 0 && !facingRight){
            Flip();
        }
        if(movementHorizontal < 0 && facingRight){
            Flip();
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        aimTransform.localScale = currentScale;
        facingRight = !facingRight;
    }

}
