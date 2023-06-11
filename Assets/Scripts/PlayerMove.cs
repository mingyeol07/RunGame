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
    bool skill = true;
    bool isShoot;
    float skillTime = 0;

    GameManager gameManager;
    Rigidbody2D rigid;
    CapsuleCollider2D coll;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    void Update()
    {
        gameManager.skillTime = skillTime;
        Jump();
        Fire();
        StartCoroutine(Move());
        if (Input.GetKey(KeyCode.E))
        {
            Invoke("Fire", 0.1f);
        }
        if (!skill)
        {
            skillTime -= Time.deltaTime;
            if (skillTime <= 0)
            {
                skillTime = 0;
                skill = true;
            }
        }
    }
    IEnumerator Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isMoved == true)
        {
            if (gameManager.nowPosition != 1)
            {
                StartCoroutine(MoveCool(0f));
                anim.SetBool("MoveStart", true);
                yield return new WaitForSeconds(0.3f);
                gameManager.nowPosition--;
                transform.position = gameManager.movePoint[gameManager.nowPosition - 1].position;
                anim.SetBool("MoveStart", false);
                anim.SetBool("MoveFinish", true);
                yield return new WaitForSeconds(0.3f);
                anim.SetBool("MoveFinish", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isMoved == true)
        {
            if (gameManager.nowPosition != 3)
            {
                StartCoroutine(MoveCool(0f));
                anim.SetBool("MoveStart", true);
                yield return new WaitForSeconds(0.3f);
                gameManager.nowPosition++;
                transform.position = gameManager.movePoint[gameManager.nowPosition - 1].position;
                anim.SetBool("MoveStart", false);
                anim.SetBool("MoveFinish", true);
                yield return new WaitForSeconds(0.3f);
                anim.SetBool("MoveFinish", false);
            }
        }
    }

    IEnumerator MoveAnim()
    {
        anim.SetBool("MoveStart", true);
        yield return new WaitForSeconds(0.5f);
        
    }

    
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameManager.bullet > 0 && isReLoad == false && isJumping == false)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            gameManager.bullet--;
            if (gameManager.bullet <= 0)
            {
                StartCoroutine(ReLoad());
            }
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
                anim.SetBool("isJump", true);
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
            anim.SetBool("isJump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss" && !isDamaged)
        {
            gameManager.playerHp -= 15f;
            StartCoroutine(Damaged());
        }
        if (collision.gameObject.tag == "Beam" && !isDamaged)
        {
            gameManager.playerHp -= 50f;
            StartCoroutine(Damaged());
        }
    }

    IEnumerator Damaged()
    {
        transform.position = gameManager.movePoint[gameManager.nowPosition - 1].position;
        CameraShake.ShakeCamera(0.5f, 0.2f);

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

    IEnumerator MoveCool(float cool)
    {
        isMoved = false;
        skillTime = Stat.Instance.SkillTime;
        skill = false;
        yield return new WaitForSeconds(gameManager.skillMaxCool);
        isMoved = true;
    }

    IEnumerator ReLoad()
    {
        isReLoad = true;
        for (gameManager.bullet = 0; gameManager.bullet <= gameManager.bulletMax; gameManager.bullet++)
        {
            yield return new WaitForSeconds(0.06f);
        }
        isReLoad = false;
        gameManager.bullet = gameManager.bulletMax;
    }

    
}
