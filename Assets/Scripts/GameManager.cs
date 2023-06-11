using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Object")]
    public GameObject[] tentacle;
    public GameObject[] board;
    public GameObject[] bossAtt;

    [Header("# Game Point")]
    public GameObject[] notFallPoint;
    public Transform[] movePoint;

    [Header("# Player")]
    public float playerHp;
    public float playerMaxHp = 100;
    public float bullet;
    public float bulletMax;
    public float skillCool;
    public float skillMaxCool;
    public float skillTime = 2;
    public int nowPosition = 2;

    [Header("# Boss")]
    public float tentacleHp1;
    public float tentacleHp2;
    public float tentacleHp3;
    public float bossHp;

    public float tentacleMaxHp;
    public float bossMaxHp;

    [Header("# Ui")]
    [SerializeField] Slider SkillIcon;
    [SerializeField] TextMeshProUGUI SkillText;

    private void Awake()
    {
        instance = this;
        bossHp = bossMaxHp;
        tentacleHp1 = tentacleMaxHp;
        tentacleHp2 = tentacleMaxHp;
        tentacleHp3 = tentacleMaxHp;
        bullet = bulletMax;
        playerHp = playerMaxHp;
    }

    private void Update()
    {
        Dead();
        if (bossHp <= 0)
        {

        }
        UIManager();
        StartCoroutine(Clear());
    }

    void Dead()
    {
        if (playerHp <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator Clear()
    {
        if (bossHp <= 0)
        {
            playerHp = playerMaxHp;
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(3);
        }
    }

    void UIManager()
    {
        SkillIcon.value = 2 - skillTime;
        if (skillTime != 0)
        {
            double temp =  System.Math.Ceiling(skillTime);
            SkillText.text = temp.ToString();
        }
        else
        {
            SkillText.text = string.Empty;
        }
    }
}
