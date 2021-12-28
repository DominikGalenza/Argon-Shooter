using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 1f;

    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", loadLevelDelay);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
