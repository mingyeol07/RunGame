using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material Sky;
    public float SkySpeed;
    public Material Ground;
    public float GroundSpeed;

    private void Update() {
        SkyScroll();
        GroundScroll();
    }

    void SkyScroll() {
        // x값 생성
        float y = Sky.mainTextureOffset.y + SkySpeed * Time.deltaTime;
        // 속도값 생성
        Vector2 Vec = new Vector2(0, y);
        // Sky란 메테리얼의 오프셋을 Vec값으로 조정
        Sky.mainTextureOffset = Vec;
         
    }
    
    void GroundScroll() {
        float x = Ground.mainTextureOffset.x + GroundSpeed * Time.deltaTime;
        Vector2 Vec = new Vector2(x, 0);
        Ground.mainTextureOffset = Vec;
         
    }
}
