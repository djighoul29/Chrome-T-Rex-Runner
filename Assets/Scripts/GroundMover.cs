using UnityEngine;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private int speed = 15;
    [SerializeField] private float leftPoint = -23;
    [SerializeField] private float rightPoint = 24.614f;

    private void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (transform.position.x < leftPoint)
            transform.position = new Vector2(rightPoint, transform.position.y);
    }
}
