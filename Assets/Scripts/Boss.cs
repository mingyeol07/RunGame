using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int ranAtt;

    public float bossHp = 100;
    public float tentacleNextTime;
    public float tentacleBackTime;
    public float tentacleCoolTime;
    public float tentacleSpeedLeft;
    public float tentacleSpeedRight;
    public float tentacleMoveLeft;
    public float tentacleMoveRight;
    public float tentacleStay;

    bool onTentacleMoveLeft1 = false;
    bool onTentacleMoveLeft2 = false;
    bool onTentacleMoveLeft3 = false;
    bool onTentacleMoveRight1 = false;
    bool onTentacleMoveRight2 = false;
    bool onTentacleMoveRight3 = false;

    public GameObject[] Tentacle;

    GameManager gameManager;
    CapsuleCollider2D csCollider;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        csCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        csCollider.enabled = false;
        StartCoroutine(Att());
    }

    private void Update()
    {
        tentacleMove();
        Phase();
    }

    void Phase()
    {
        if (Tentacle[0].activeSelf == false && Tentacle[1].activeSelf == false && Tentacle[2].activeSelf == false)
        {
            csCollider.enabled = true;
        }
        if (bossHp <= 200)
        {
            
        }
        
    }

    void tentacleMove()
    {
        if (onTentacleMoveLeft1)
            Tentacle[0].transform.Translate(Vector2.left * tentacleSpeedLeft * Time.deltaTime);
        if (onTentacleMoveLeft2)
            Tentacle[1].transform.Translate(Vector2.left * tentacleSpeedLeft * Time.deltaTime);
        if (onTentacleMoveLeft3)
            Tentacle[2].transform.Translate(Vector2.left * tentacleSpeedLeft * Time.deltaTime);

        if (onTentacleMoveRight1)
            Tentacle[0].transform.Translate(Vector2.right * tentacleSpeedRight * Time.deltaTime);
        if (onTentacleMoveRight2)
            Tentacle[1].transform.Translate(Vector2.right * tentacleSpeedRight * Time.deltaTime);
        if (onTentacleMoveRight3)
            Tentacle[2].transform.Translate(Vector2.right * tentacleSpeedRight * Time.deltaTime);
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
        bossHp -= 1f;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    IEnumerator Att()
    {
        yield return new WaitForSeconds(tentacleCoolTime);

        ranAtt = Random.Range(0, 5);
        switch (ranAtt)
        {
            case 0:
                StartCoroutine(TentacleAtt1());
                break;
            case 1:
                StartCoroutine(TentacleAtt2());
                break;
            case 2:
                StartCoroutine(TentacleAtt3());
                break;
            case 3:
                StartCoroutine(TentacleAtt4());
                break;
            case 4:
                StartCoroutine(TentacleAtt5());
                break;
        }
        
    }

    IEnumerator Tentacle1()
    {
        onTentacleMoveRight1 = true;
        yield return new WaitForSeconds(tentacleBackTime);
        onTentacleMoveRight1 = false;

        onTentacleMoveLeft1 = true;
        yield return new WaitForSeconds(tentacleMoveLeft);
        onTentacleMoveLeft1 = false;
        yield return new WaitForSeconds(tentacleStay);
        onTentacleMoveRight1 = true;
        yield return new WaitForSeconds(tentacleMoveRight);
        onTentacleMoveRight1 = false;
    }

    IEnumerator Tentacle2()
    {
        onTentacleMoveRight2 = true;
        yield return new WaitForSeconds(tentacleBackTime);
        onTentacleMoveRight2 = false;

        onTentacleMoveLeft2 = true;
        yield return new WaitForSeconds(tentacleMoveLeft);
        onTentacleMoveLeft2 = false;
        yield return new WaitForSeconds(tentacleStay);
        onTentacleMoveRight2 = true;
        yield return new WaitForSeconds(tentacleMoveRight);
        onTentacleMoveRight2 = false;
    }

    IEnumerator Tentacle3()
    {
        onTentacleMoveRight3 = true;
        yield return new WaitForSeconds(tentacleBackTime);
        onTentacleMoveRight3 = false;

        onTentacleMoveLeft3 = true;
        yield return new WaitForSeconds(tentacleMoveLeft);
        onTentacleMoveLeft3 = false;
        yield return new WaitForSeconds(tentacleStay);
        onTentacleMoveRight3 = true;
        yield return new WaitForSeconds(tentacleMoveRight);
        onTentacleMoveRight3 = false;
    }


    IEnumerator TentacleAtt1()
    {
        StartCoroutine(Tentacle1());
        StartCoroutine(Tentacle3());
        yield return new WaitForSeconds(tentacleNextTime);
        StartCoroutine(Tentacle2());

        StartCoroutine(Att());
    }

    IEnumerator TentacleAtt2()
    {
        
        StartCoroutine(Tentacle3());
        yield return new WaitForSeconds(tentacleNextTime);
        StartCoroutine(Tentacle2());
        yield return new WaitForSeconds(tentacleNextTime);
        StartCoroutine(Tentacle1());

        StartCoroutine(Att());
    }

    IEnumerator TentacleAtt3()
    {
        
        StartCoroutine(Tentacle1());
        yield return new WaitForSeconds(tentacleNextTime);
        StartCoroutine(Tentacle2());
        yield return new WaitForSeconds(tentacleNextTime);
        StartCoroutine(Tentacle3());

        StartCoroutine(Att());
    }

    IEnumerator TentacleAtt4()
    {
        
        StartCoroutine(Tentacle1());
        yield return new WaitForSeconds(1f);
        StartCoroutine(Tentacle2());
        yield return new WaitForSeconds(tentacleNextTime);
        StartCoroutine(Tentacle3());

        StartCoroutine(Att());
    }

    IEnumerator TentacleAtt5()
    {
        
        StartCoroutine(Tentacle3());
        yield return new WaitForSeconds(1f);
        StartCoroutine(Tentacle2());
        yield return new WaitForSeconds(tentacleNextTime);
        StartCoroutine(Tentacle1());

        StartCoroutine(Att());
    }
}
