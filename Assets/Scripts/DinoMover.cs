using UnityEngine;

public class DinoMover : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1f;
    private Rigidbody2D Rb;
    private bool canJump = true;
    private float posY = -3.21f;
    public float PosY { get { return posY; } }
    public bool CanJump { get { return canJump; } set { canJump = value; } }
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canJump && transform.position.y <= posY && 
            (Input.GetKeyDown(KeyCode.Space) || 
            Input.GetKeyDown(KeyCode.UpArrow) || 
            Input.GetKeyDown(KeyCode.W)))
        {
            Rb.velocity = Vector2.up * jumpForce;
        }
    }
}
