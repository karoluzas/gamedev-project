using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Transform aimTransform;
    public Camera sceneCamera;

    private Vector2 movement;
    private bool facingRight = true;
    private Vector3 mousePosition;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // Gun aiming rotation
        if (!MenuController.IsGamePaused)
        {
            mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);
    }

    private void FixedUpdate(){
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

    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        aimTransform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
