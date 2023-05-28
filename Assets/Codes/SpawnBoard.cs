using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoard : MonoBehaviour
{
    
    private void Awake() {
        StartCoroutine(Think());
    }

    IEnumerator Think() {
        yield return new WaitForSeconds(0.0f);

        int ranSpawn = Random.Range(0,3);
        switch (ranSpawn) {
            case 0:
                StartCoroutine(PatternA());
                break;
            case 1:
                StartCoroutine(PatternC());
                break;
            case 2:
                StartCoroutine(PatternC());
                break;
        }
    }

    IEnumerator PatternA() {
        
        Instantiate(GameManager.instance.board[2], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3.5f);
        Instantiate(GameManager.instance.board[2], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        Instantiate(GameManager.instance.board[0], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);

        StartCoroutine(Think());
    }

    IEnumerator PatternC() {
        
        Instantiate(GameManager.instance.board[2], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        Instantiate(GameManager.instance.board[0], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        Instantiate(GameManager.instance.board[2], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3.5f);
        
        StartCoroutine(Think());
    }
}
