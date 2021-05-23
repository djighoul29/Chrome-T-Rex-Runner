using UnityEngine;

public class DinoMover : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1f;
    private Rigidbody2D Rb;
    private float posY = -3.21f;
    public float PosY { get { return posY; } }
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (transform.position.y <= posY && 
            (Input.GetKeyDown(KeyCode.Space) || 
            Input.GetKeyDown(KeyCode.UpArrow) || 
            Input.GetKeyDown(KeyCode.W)))
        {
            Rb.velocity = Vector2.up * jumpForce;
        }
    }
}
