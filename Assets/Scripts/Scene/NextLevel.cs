using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int _buildSceneIndex;


    private void LoadNextLevel()
    {
        SceneManager.LoadScene(_buildSceneIndex, LoadSceneMode.Single);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitingBeforeLoadingNextLevel());
        }
    }
    
    private IEnumerator WaitingBeforeLoadingNextLevel()
    {
        yield return new WaitForSeconds(2);
        LoadNextLevel();
    }
}
