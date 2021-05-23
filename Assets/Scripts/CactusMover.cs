using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMover : MonoBehaviour
{
    private float speed = -15f;
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (transform.position.x < -13f)
            Destroy(gameObject);
    }
}
