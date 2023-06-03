using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject bullet;

    public int jumpPower = 1;
    public int maxJumpPoint = 1;
    public int jumpPoint = 2;
    public int hp;

    public int maxAmmo = 10;
    public int currentAmmo = 10;

    public float moveCool = 2;

    public bool isMoved;
    public bool isFalled;
    public bool isDamaged;

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
        Slider();
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
        if (Input.GetKeyDown(KeyCode.X) && currentAmmo > 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            currentAmmo--;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReLoad());
        }
    }
    private void Slider()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Slide");
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpPoint > 0)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpPoint--;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Footer")
        {
            jumpPoint = maxJumpPoint;
        }
        if (collision.gameObject.tag == "Fall" && !isDamaged)
        {
            StartCoroutine(Damaged());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss" && !isDamaged)
        {
            StartCoroutine(Damaged());
        }
    }

    IEnumerator Damaged()
    {
        transform.position = gameManager.movePoint[gameManager.nowPosition - 1].position;
        hp--;

        isDamaged = true;
        for (int i = 0; i < 3; i++)
        {
            gameManager.NotFallPoint[i].SetActive(true);
        }
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        yield return new WaitForSeconds(2f);

        isDamaged = false;
        for (int j = 0; j < 3; j++)
        {
            gameManager.NotFallPoint[j].SetActive(false);
        }
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    IEnumerator MoveCool()
    {
        isMoved = false;
        yield return new WaitForSeconds(moveCool);
        isMoved = true;
    }

    IEnumerator ReLoad()
    {
        yield return new WaitForSeconds(2f);
        currentAmmo = maxAmmo;
    }
}
