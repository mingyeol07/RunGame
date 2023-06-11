using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    private static Stat m_Instance;
    public static Stat Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<Stat>();
            }
            return m_Instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(m_Instance != null && m_Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public int HP = 5;
    public float SkillTime = 2.0f;
    public int BulletSize = 25;
    public float BulletTime = 2.0f;
    public int BulletDamege = 1;
}
