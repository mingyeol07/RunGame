using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase3 : MonoBehaviour
{
    public GameObject[] Tentacle;
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        gameManager = GameManager.instance;

        Tentacle[0].SetActive(true);
        Tentacle[1].SetActive(true);
        Tentacle[2].SetActive(true);
        gameManager.tentacleHp1 = gameManager.tentacleMaxHp;
        gameManager.tentacleHp2 = gameManager.tentacleMaxHp;
        gameManager.tentacleHp3 = gameManager.tentacleMaxHp;
    }

    private void Update() {
        Vector3 targetPosition = new Vector3(transform.position.x, gameManager.movePoint[1].transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 1.5f * Time.deltaTime);
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
        gameManager.bossHp--;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
