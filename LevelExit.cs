using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f; // starts in 2 seconds
    [SerializeField] float LeveLExitSlowMoFactor = 0.2f; // character moves in slowmotion
    [SerializeField] GameObject winParticles; // some stuff to make the completion of the level more valuable
    private void Start()
    {
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Gate());
    }
        
    IEnumerator Gate()
    {
        Time.timeScale = LeveLExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f; // normal time scale
        // GetComponent<AudioSource>().Play(); // if we have an Audio to play
        winParticles.SetActive(true);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        
    }
}
