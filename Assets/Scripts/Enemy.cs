using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerKill = 50;
    [SerializeField] int hitPoints = 100;
    [SerializeField] int damagePerHit = 25;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void OnParticleCollision(GameObject other) 
    {
        hitPoints -= damagePerHit;
        GameObject hitvfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitvfx.transform.parent = parentGameObject.transform;
        if(hitPoints <= 0)
        {
            scoreBoard.IncreaseScore(scorePerKill);
            GameObject explosionvfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            explosionvfx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
        }
    }
}
