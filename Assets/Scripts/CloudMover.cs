using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private float speed = -5f;
    private void Update()
    {
        if (transform.position.x < -13f)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, 2.2f);
    }
}
