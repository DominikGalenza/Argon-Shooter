using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 50;
    [SerializeField] int hitPoints = 100;
    [SerializeField] int damagePerHit = 25;

    ScoreBoard scoreBoard;
    GameObject parent;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void OnParticleCollision(GameObject other) 
    {
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints -= damagePerHit;
        GameObject hitvfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitvfx.transform.parent = parent.transform;
        if(hitPoints <= 0)
        {
            GameObject explosionvfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            explosionvfx.transform.parent = parent.transform;
            Destroy(gameObject);
        }
    }
}
