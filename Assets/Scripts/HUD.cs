using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { PlayerHp, Bullet, BossHp, TentacleHp1, TentacleHp2, TentacleHp3 }
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
                mySlider.value = gameManager.tentacleHp1 / gameManager.tentacleMaxHp1;
                break;
            case InfoType.TentacleHp2:
                mySlider.value = gameManager.tentacleHp2 / gameManager.tentacleMaxHp2;
                break;
            case InfoType.TentacleHp3:
                mySlider.value = gameManager.tentacleHp3 / gameManager.tentacleMaxHp3;
                break;
        }
    }
}
