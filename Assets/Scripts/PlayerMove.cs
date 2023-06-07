using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject bullet;
    public GameObject changeHp;

    public int jumpPoint;
    public int maxJumpPoint = 1;

    public float jumpPower = 5;
    public float moveCool = 2;

    public bool isMoved;
    public bool isFalled;
    public bool isDamaged;
    private bool isJumping = false;
    private bool isReLoad = false;

    GameManager gameManager;
    Rigidbody2D rigid;
    CapsuleCollider2D coll;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    void Update()
    {
        Jump();
        Fire();
        Move();
    }
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isMoved == true)
        {
            if (gameManager.nowPosition != 1)
            {
                gameManager.nowPosition--;
                transform.position = gameManager.movePoint[gameManager.nowPosition - 1].position;
                StartCoroutine(MoveCool());
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isMoved == true)
        {
            if (gameManager.nowPosition != 3)
            {
                gameManager.nowPosition++;
                transform.position = gameManager.movePoint[gameManager.nowPosition - 1].position;
                StartCoroutine(MoveCool());
            }
        }


    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameManager.bullet > 0 && isReLoad == false && isJumping == false)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            gameManager.bullet--;
        }
        if (Input.GetKeyDown(KeyCode.R) && isReLoad == false)
        {
            StartCoroutine(ReLoad());
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpPoint > 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                jumpPoint--;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fall" && !isDamaged)
        {
            gameManager.playerHp -= 5f;
            StartCoroutine(Damaged());
        }
        if (collision.gameObject.CompareTag("Footer"))
        {
            jumpPoint = maxJumpPoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss" && !isDamaged)
        {
            gameManager.playerHp -= 15f;
            StartCoroutine(Damaged());
        }
    }

    IEnumerator Damaged()
    {
        transform.position = gameManager.movePoint[gameManager.nowPosition - 1].position;

        isDamaged = true;
        for (int i = 0; i < 3; i++)
        {
            gameManager.notFallPoint[i].SetActive(true);
        }
        
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        changeHp.SetActive(true);
        yield return new WaitForSeconds(2f);

        isDamaged = false;
        for (int j = 0; j < 3; j++)
        {
            gameManager.notFallPoint[j].SetActive(false);
        }
        spriteRenderer.color = new Color(1, 1, 1, 1);
        changeHp.SetActive(false);
    }

    IEnumerator MoveCool()
    {
        isMoved = false;
        yield return new WaitForSeconds(moveCool);
        isMoved = true;
    }

    IEnumerator ReLoad()
    {
        Debug.Log("재장전 중..");
        isReLoad = true;
        yield return new WaitForSeconds(2f);
        isReLoad = false;
        Debug.Log("재장전 완료");
        gameManager.bullet = gameManager.bulletMax;
    }
}
