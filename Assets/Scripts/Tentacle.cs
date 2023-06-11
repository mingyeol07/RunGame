using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Start()
    {
        gameManager = GameManager.instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(Damaged());
        }
    }

    IEnumerator Damaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = new Color(1, 1, 1, 1);
        if (gameObject.name == "Tentacle 1")
        {
            gameManager.tentacleHp1--;
        }
        if (gameObject.name == "Tentacle 2")
        {
            gameManager.tentacleHp2--;
        }
        if (gameObject.name == "Tentacle 3")
        {
            gameManager.tentacleHp3--;
        }

        if (gameManager.tentacleHp1 <= 0 || gameManager.tentacleHp2 <= 0 || gameManager.tentacleHp3 <= 0)
        {
            anim.SetBool("Die", true);
        }
    }
}
