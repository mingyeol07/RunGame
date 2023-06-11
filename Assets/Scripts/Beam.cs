using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float fadeDuration = 2f;  // 사라짐 지속 시간

    private float currentAlpha;
    private float fadeSpeed;

    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        currentAlpha = 1f;
        fadeSpeed = 1f / fadeDuration;
    }

    private void Update()
    {
        // 알파값 서서히 감소
        currentAlpha -= fadeSpeed * Time.deltaTime;

        // 알파값을 적용하여 오브젝트 투명도 조절
        Color objectColor = objectRenderer.material.color;
        objectColor.a = currentAlpha;
        objectRenderer.material.color = objectColor;

        // 오브젝트가 완전히 사라지면 오브젝트 비활성화
        if (currentAlpha <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
