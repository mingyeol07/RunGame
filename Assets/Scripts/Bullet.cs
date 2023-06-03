using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 5;
    public float speed = 1f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
