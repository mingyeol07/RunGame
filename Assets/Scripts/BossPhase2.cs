using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2 : MonoBehaviour
{
    public float moveBossSpeed;
    public float waitCoolTime;
    public float stayTime;
    bool isMove1 = false;
    bool isMove2 = false;
    bool isMove3 = false;

    int arr;
    int ranAtt;
    GameManager gameManager;
    SpriteRenderer spriteRenderer;
    

    public GameObject beam;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        gameManager = GameManager.instance;
        StartCoroutine(Att());
    }

    private void Update() {
        

        if (isMove1)
        {
        Vector3 targetPosition = new Vector3(transform.position.x, gameManager.movePoint[0].transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveBossSpeed * Time.deltaTime);
        }
        if (isMove2)
        {
        Vector3 targetPosition = new Vector3(transform.position.x, gameManager.movePoint[1].transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveBossSpeed * Time.deltaTime);
        }
        if (isMove3)
        {
        Vector3 targetPosition = new Vector3(transform.position.x, gameManager.movePoint[2].transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveBossSpeed * Time.deltaTime);
        }
    }

    void OnBeam()
    {
        Instantiate(beam, transform.position, Quaternion.identity);
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

    IEnumerator Att()
    {
        yield return new WaitForSeconds(waitCoolTime);

        ranAtt = Random.Range(1, 5);
        switch (ranAtt)
        {
            case 0:
                StartCoroutine(BeamAtt1());
                break;
            case 1:
                StartCoroutine(BeamAtt2());
                break;
            case 2:
                StartCoroutine(BeamAtt3());
                break;
            case 3:
                StartCoroutine(BeamAtt4());
                break;
            case 4:
                StartCoroutine(BeamAtt5());
                break;
        }
    }

    

    IEnumerator BeamAtt1()
    {
        isMove1 = true;
        yield return new WaitForSeconds(stayTime);
        isMove1 = false;
        OnBeam();

        StartCoroutine(Att());
    }

    IEnumerator BeamAtt2()
    {
        isMove2 = true;
        yield return new WaitForSeconds(stayTime);
        isMove2 = false;
        OnBeam();
        isMove3 = true;
        yield return new WaitForSeconds(stayTime);
        isMove3 = false;
        OnBeam();
        isMove1 = true;
        yield return new WaitForSeconds(stayTime);
        isMove1 = false;
        OnBeam();

        StartCoroutine(Att());
    }

    IEnumerator BeamAtt3()
    {
        isMove2 = true;
        yield return new WaitForSeconds(stayTime);
        isMove2 = false;
        OnBeam();
        isMove1 = true;
        yield return new WaitForSeconds(stayTime);
        isMove1 = false;
        OnBeam();
        isMove3 = true;
        yield return new WaitForSeconds(stayTime);
        isMove3 = false;
        OnBeam();

        StartCoroutine(Att());
    }

    IEnumerator BeamAtt4()
    {
        isMove3 = true;
        yield return new WaitForSeconds(stayTime);
        isMove3 = false;
        OnBeam();
        isMove2 = true;
        yield return new WaitForSeconds(stayTime);
        isMove2 = false;
        OnBeam();
        isMove1 = true;
        yield return new WaitForSeconds(stayTime);
        isMove1 = false;
        OnBeam();

        StartCoroutine(Att());
    }

    IEnumerator BeamAtt5()
    {
        isMove1 = true;
        yield return new WaitForSeconds(stayTime);
        isMove1 = false;
        OnBeam();
        isMove2 = true;
        yield return new WaitForSeconds(stayTime);
        isMove2 = false;
        OnBeam();
        isMove3 = true;
        yield return new WaitForSeconds(stayTime);
        isMove3 = false;
        OnBeam();

        StartCoroutine(Att());
    }
}
