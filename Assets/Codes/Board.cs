using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public float speed = 1f;
    BoxCollider2D box;

    private void Awake() {
        box = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Destroy(gameObject, 15.0f);

        // box.enabled = false;
    }

    

    

}
