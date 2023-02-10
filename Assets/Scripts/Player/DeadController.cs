using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class DeadController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverIndicator;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Animator>().Play("MyHeroDead",-1,0.0f);
            gameOverIndicator.SetActive(true);
            Player.Instance.State.IsActive = false;
            StartCoroutine(WaitingBeforeReloadingTheScene());
        }
    }
    private IEnumerator WaitingBeforeReloadingTheScene()
    {
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}