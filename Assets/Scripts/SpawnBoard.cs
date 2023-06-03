using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoard : MonoBehaviour
{
    int randomSpawn = 0;
    public float culltimeA = 1.5f;
    public float culltimeB = 2.5f;
    SpriteRenderer sprite;

    GameManager gameManager;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(RandomSpawner());
    }
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    IEnumerator RandomSpawner() //  함수 이름 바꿔라.
    {
        randomSpawn = Random.Range(0, 10);
        yield return new WaitForSeconds(1.5f);

        if (randomSpawn >= 0 && randomSpawn < 2)
        {
            Instantiate(gameManager.board[0], transform.position, Quaternion.identity);
        }
        if (randomSpawn >= 2 && randomSpawn < 5)
        {
            Instantiate(gameManager.board[1], transform.position, Quaternion.identity);
        }
        if (randomSpawn >= 5 && randomSpawn < 10)
        {
            Instantiate(gameManager.board[2], transform.position, Quaternion.identity);
        }
        StartCoroutine(RandomSpawner());
    }
}
