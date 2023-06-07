using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int nowPosition = 2;

    [Header("# Boss")]
    public float tentacleHp1;
    public float tentacleHp2;
    public float tentacleHp3;
    public float bossHp;

    public float tentacleMaxHp1;
    public float tentacleMaxHp2;
    public float tentacleMaxHp3;
    public float bossMaxHp;

    private void Awake()
    {
        instance = this;
        bossHp = bossMaxHp;
        tentacleHp1 = tentacleMaxHp1;
        tentacleHp2 = tentacleMaxHp2;
        tentacleHp3 = tentacleMaxHp3;
        bullet = bulletMax;
        playerHp = playerMaxHp;
    }

    private void Start() {
        
    }

    private void Update() {
        
        Dead();
    }

    void Dead()
    {
        if (playerHp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {

    }
}
