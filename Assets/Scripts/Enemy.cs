using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 50;
    [SerializeField] int hitPoints = 100;
    [SerializeField] int damagePerHit = 25;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other) 
    {
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints -= damagePerHit;
        GameObject hitvfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        if(hitPoints <= 0)
        {
            GameObject explosionvfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            explosionvfx.transform.parent = parent;
            Destroy(gameObject);
        }
    }
}
