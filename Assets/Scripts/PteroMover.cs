using UnityEngine;

public class PteroMover : MonoBehaviour
{
    [SerializeField] private float speed = -15f;

    private void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, Random.Range(0.2f, 0.5f));
        if (transform.position.x < -13f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Dino"))
            GameScript.instance.DinoHit();
    }
}
