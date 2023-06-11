using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public string SceneToLoad;


    public void GameStart()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
