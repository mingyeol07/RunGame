using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int ranAtt;
    int ranSpawn;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Att());
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("으악");
            StartCoroutine(Damaged());
        }
    }

    IEnumerator Damaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    
    IEnumerator Att()
    {
        yield return new WaitForSeconds(5f);

        ranAtt = Random.Range(0, 5);
        switch (ranAtt)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
