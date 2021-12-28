using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 1f;
    [SerializeField] ParticleSystem explosionVFX;

    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", loadLevelDelay);
        explosionVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
