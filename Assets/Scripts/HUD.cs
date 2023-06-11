using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Skill, PlayerHp, Bullet, BossHp, TentacleHp1, TentacleHp2, TentacleHp3, SkillCool }
    public InfoType type;

    GameManager gameManager;
    Slider mySlider;
    
    private void Awake() {
        mySlider = GetComponent<Slider>();
    }

    private void Start() {
        gameManager = GameManager.instance;
    }

    private void Update() {
        switch (type)
        {
            case InfoType.Skill:
                mySlider.value = gameManager.skillCool / gameManager.skillMaxCool;
                break;
            case InfoType.PlayerHp:
                mySlider.value = gameManager.playerHp / gameManager.playerMaxHp;
                break;
            case InfoType.Bullet:
                mySlider.value = gameManager.bullet / gameManager.bulletMax;
                break;
            case InfoType.BossHp:
                mySlider.value = gameManager.bossHp / gameManager.bossMaxHp;
                break;
            case InfoType.TentacleHp1:
                mySlider.value = gameManager.tentacleHp1 / gameManager.tentacleMaxHp;
                break;
            case InfoType.TentacleHp2:
                mySlider.value = gameManager.tentacleHp2 / gameManager.tentacleMaxHp;
                break;
            case InfoType.TentacleHp3:
                mySlider.value = gameManager.tentacleHp3 / gameManager.tentacleMaxHp;
                break;
            case InfoType.SkillCool:
                mySlider.value = gameManager.skillCool / gameManager.skillMaxCool;
                break;
        }
    }
}
