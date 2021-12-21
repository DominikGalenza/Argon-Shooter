using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float newXPosition = transform.localPosition.x + xOffset;

        float yOffset = yThrow * Time.deltaTime * moveSpeed;
        float newYPosition = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newXPosition, newYPosition, transform.localPosition.z);
    }
}
