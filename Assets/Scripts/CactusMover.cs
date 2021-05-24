using UnityEngine;

public class CactusMover : MonoBehaviour
{
    [SerializeField] private float speed = -15f;
    private void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (transform.position.x < -13f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Dino"))
            GameScript.instance.DinoHit();
    }
}
