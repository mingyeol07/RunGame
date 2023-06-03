using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] board;
    public GameObject[] NotFallPoint;
    public int nowPosition = 2;
    private void Awake()
    {
        instance = this;
    }

    public Transform[] movePoint;


}
