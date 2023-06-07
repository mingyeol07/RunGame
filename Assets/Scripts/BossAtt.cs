using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAtt : MonoBehaviour
{
    public float curTentacleHp;
    public float tentacleHp = 100;

    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    Slider hpSlider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hpSlider = GetComponent<Slider>();
        gameManager = GetComponent<GameManager>();
        curTentacleHp = tentacleHp;
    }

    private void Update()
    {   
        Dead();
        HP();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && curTentacleHp > 0)
        {
            StartCoroutine(Damaged());
        }
    }

    IEnumerator Damaged()
    {
        
        curTentacleHp--;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void Dead()
    {
        if (curTentacleHp == 0)
        {
            curTentacleHp--;
            gameObject.SetActive(false);
        }
    }

    void HP()
    {
        // float curHealth = curTentacleHp;
        // float maxHealth = tentacleHp;
        // hpSlider.value = curHealth / maxHealth;
    }
}
