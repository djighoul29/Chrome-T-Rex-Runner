using UnityEngine;

public class CactusMover : MonoBehaviour
{
    [SerializeField] GameObject Dino;
    [SerializeField] private float speed = -15f;
    private void Update()
    {
        //speed += GameScript.instance.Speed * -1;
        //Debug.Log(speed);
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x < -13f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Dino"))
            GameScript.instance.DinoHit();
    }
}
